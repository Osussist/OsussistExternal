using OsuParsers.Beatmaps;
using OsuParsers.Beatmaps.Objects;
using OsuParsers.Enums;
using Osussist.src.config;
using Osussist.src.config.objects;
using Osussist.src.osu;
using Osussist.src.osu.enums;
using Osussist.src.osu.helpers;
using Osussist.src.utils;
using System.Numerics;
using System.Runtime.InteropServices;
using WindowsInput;
using WindowsInput.Native;

namespace Osussist.src.cheat
{
    public class Relax
    {
        #region NativeImports
        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(int vKey);
        #endregion

        private Logger logger = Logger.LoggingInstance;
        private OsuSDK SDK { get; set; }

        public static Beatmap CurrentBeatmap { get; private set; }
        private PlayStyles PlayStyle;
        private int HitWin50;
        private int HitWin100;
        private int HitWin300;

        private float HitScanMultiplier;
        private int HitScanMaxDistance;
        private float HitScanRadiusAdd;

        private float MaxBPM;
        private bool ShouldAlternate;
        private bool ShouldStartAlternate;

        private InputSimulator InputSim;
        private VirtualKeyCode PrimaryKey;
        private VirtualKeyCode SecondaryKey;

        private int SongIndex;
        private bool IsHit;
        private VirtualKeyCode CurrentKey;
        private HitObject CurrentHitObject;
        private int LastHitTime;
        private int LastHitScan;
        private Vector2 LastOnNotePos = Vector2.Zero;
        private ValueTuple<int, int> HitObjectTimings;

        private bool WasReleased = false;
        private int LastBeatmapId = -99;
        private static readonly Random random = new Random();

        private float HitObjectRadius
        {
            get
            {
                return SDK.GetHitObjectRadius(CurrentBeatmap);
            }
        }

        private int ClosestHitObjectIndex
        {
            get
            {
                int currentTime = SDK.CurrentTime;
                for (int i = 0; i < CurrentBeatmap.HitObjects.Count; i++)
                {
                    if (CurrentBeatmap.HitObjects[i].StartTime >= currentTime)
                    {
                        return i;
                    }
                }
                return CurrentBeatmap.HitObjects.Count;
            }
        }

        public Relax(OsuSDK givenSDK)
        {
            SDK = givenSDK;
        }

        public void Loop()
        {
            while (true)
            {
                if (SDK.isPlaying)
                {
                    CurrentBeatmap = SDK.CurrentBeatmap;
                    if (LastBeatmapId != CurrentBeatmap.MetadataSection.BeatmapID)
                    {
                        LastBeatmapId = CurrentBeatmap.MetadataSection.BeatmapID;
                        logger.Info("Relax", $"Loaded beatmap: {CurrentBeatmap.MetadataSection.Artist} - {CurrentBeatmap.MetadataSection.Title} [{CurrentBeatmap.MetadataSection.Version}]");
                    }

                    PlayStyle = Config.config.relaxsettings.playstyle;
                    HitWin50 = SDK.HitWindow50(CurrentBeatmap.DifficultySection.OverallDifficulty);
                    HitWin100 = SDK.HitWindow100(CurrentBeatmap.DifficultySection.OverallDifficulty);
                    HitWin300 = SDK.HitWindow300(CurrentBeatmap.DifficultySection.OverallDifficulty);
                    HitScanMultiplier = Config.config.relaxsettings.hitscanmultiplier;
                    HitScanMaxDistance = Config.config.relaxsettings.hitscanmaxdistance;
                    HitScanRadiusAdd = (float)Config.config.relaxsettings.hitscanradiusadd;

                    float bpmModifier = (SDK.CurrentMods.HasFlag(Mods.DoubleTime) || 
                        SDK.CurrentMods.HasFlag(Mods.Nightcore)) ? 1.5f : (SDK.CurrentMods.HasFlag(Mods.HalfTime) ? 0.75f : 1f);
                    MaxBPM = (float)Config.config.relaxsettings.maxsingletapbpm / (bpmModifier / 2f);

                    InputSim = new InputSimulator();
                    PrimaryKey = Config.config.keybindings.primarykey;
                    SecondaryKey = Config.config.keybindings.secondarykey;

                    ResetLoop();

                    int actualTime = 0;

                    while ((SDK.isGameFocused && !SDK.isPaused) && SongIndex < CurrentBeatmap.HitObjects.Count)
                    {
                        if (WasReleased)
                            WasReleased = false;

                        Thread.Sleep(1);
                        if (SDK.isPaused || !SDK.isGameFocused)
                        {
                            logger.Info("Relax", "Game is paused or not focused, stopping relax");
                            if (IsHit)
                            {
                                IsHit = false;
                                ReleaseKeys();
                            }
                        }
                        else if (!Config.config.relaxenabled)
                        {
                            logger.Info("Relax", "Relax is disabled, pausing relax");
                            if (IsHit)
                            {
                                IsHit = false;
                                ReleaseKeys();
                            }
                        }
                        else if (!SDK.isPlaying)
                        {
                            logger.Info("Relax", "Game is not playing, stopping relax");
                            IsHit = false;
                            ResetLoop();
                            ReleaseKeys();
                        }
                        else
                        {
                            int possibleTime = SDK.CurrentTime + Config.config.osusettings.audiooffset;
                            if (possibleTime < LastHitTime)
                            {
                                logger.Debug("Relax", "Detected time travel, resetting relax");
                                ResetLoop();
                                ReleaseKeys();
                            }
                            else
                            {
                                if (possibleTime >= CurrentHitObject.StartTime - HitWin50)
                                {
                                    logger.Debug("Relax", $"Hit hitobject at {CurrentHitObject.StartTime}ms");
                                    HitScanResult hitScanResult = GetHitScan(SongIndex);

                                    if (!IsHit && ((possibleTime >= CurrentHitObject.StartTime + HitObjectTimings.Item1
                                        && hitScanResult == HitScanResult.CanHit) || hitScanResult == HitScanResult.ShouldHit))
                                    {
                                        logger.Debug("Relax", $"Hit object hit: {CurrentHitObject.StartTime}");
                                        IsHit = true;
                                        actualTime = possibleTime;
                                        if (PlayStyle == PlayStyles.MouseOnly)
                                        {
                                            if (CurrentKey == PrimaryKey)
                                            {
                                                logger.Debug("Relax", "Left mouse button down");
                                                InputSim.Mouse.LeftButtonDown();
                                            }
                                            else
                                            {
                                                logger.Debug("Relax", "Right mouse button down");
                                                InputSim.Mouse.RightButtonDown();
                                            }
                                        }
                                        else if (PlayStyle == PlayStyles.TapX && !ShouldAlternate && !ShouldStartAlternate)
                                        {
                                            InputSim.Mouse.LeftButtonDown();
                                            CurrentKey = PrimaryKey;
                                            logger.Debug("Relax", $"Left mouse button down and current key is {CurrentKey}");
                                        }
                                        else
                                        {
                                            logger.Debug("Relax", $"Key down: {CurrentKey}");
                                            InputSim.Keyboard.KeyDown(CurrentKey);
                                        }
                                    }
                                    else if (IsHit && possibleTime >= ((CurrentHitObject is HitCircle) ? actualTime : CurrentHitObject.EndTime) + HitObjectTimings.Item2)
                                    {
                                        logger.Debug("Relax", "Hit object released");
                                        IsHit = false;
                                        NextObject();
                                        ReleaseKeys();
                                    }
                                    else if (!IsHit && hitScanResult == HitScanResult.Wait && possibleTime >= ((CurrentHitObject is HitCircle) ? CurrentHitObject.StartTime : (CurrentHitObject.EndTime + HitWin50)))
                                    {
                                        logger.Debug("Relax", "Missed hit object");
                                        NextObject();
                                    }
                                    LastHitTime = possibleTime;
                                }
                            }
                        }
                    }
                    if (!WasReleased)
                    {
                        ReleaseKeys();
                        WasReleased = true;
                    }
                    while (!SDK.isPaused || !SDK.isGameFocused)
                    {
                        Thread.Sleep(5);
                    }
                }
            }
        }

        private void ResetLoop()
        {
            try
            {
                SongIndex = ClosestHitObjectIndex;
                IsHit = false;
                CurrentKey = PrimaryKey;
                CurrentHitObject = CurrentBeatmap.HitObjects[SongIndex];
                LastHitTime = -CurrentBeatmap.GeneralSection.AudioLeadIn;
                UpdateAlternate();
                HitObjectTimings = RandomizeHitObjectTimings(SongIndex);
            }
            catch (Exception e)
            {
                logger.Error("Relax", $"Failed to reset loop: {e.Message}");
            }
        }

        private void UpdateAlternate()
        {
            HitObject hitObject = (SongIndex > 0) ? CurrentBeatmap.HitObjects[SongIndex - 1] : null;
            HitObject hitObject2 = (SongIndex + 1 < CurrentBeatmap.HitObjects.Count) ? CurrentBeatmap.HitObjects[SongIndex + 1] : null;
            ShouldStartAlternate = (hitObject != null && (float)(6000 / (CurrentHitObject.StartTime - hitObject.EndTime)) >= MaxBPM);
            ShouldAlternate = (hitObject != null && (float)(60000 / (CurrentHitObject.StartTime - hitObject.EndTime)) >= MaxBPM);
            if (ShouldAlternate || PlayStyle == PlayStyles.Alternate)
            {
                CurrentKey = ((CurrentKey == PrimaryKey) ? SecondaryKey : PrimaryKey);
                return;
            }
            CurrentKey = PrimaryKey;
        }

        private void NextObject()
        {
            int tempIndex = SongIndex;
            SongIndex = tempIndex + 1;
            if (SongIndex < CurrentBeatmap.HitObjects.Count)
            {
                CurrentHitObject = CurrentBeatmap.HitObjects[SongIndex];
                UpdateAlternate();
                HitObjectTimings = RandomizeHitObjectTimings(SongIndex);
            }
        }

        private void ReleaseKeys()
        {
            InputSim.Keyboard.KeyUp(PrimaryKey);
            InputSim.Keyboard.KeyUp(SecondaryKey);
            InputSim.Mouse.LeftButtonUp();
            InputSim.Mouse.RightButtonUp();
        }

        private HitScanResult GetHitScan(int index)
        {
            HitObject hitObject = CurrentBeatmap.HitObjects[index];
            if (Config.config.relaxsettings.hardrockenabled || hitObject is Spinner)
                return HitScanResult.CanHit;

            if (LastHitScan != index)
            {
                LastHitScan = index;
                LastOnNotePos = Vector2.Zero;
            }

            float disnumPlayField = SDK.GetOsuMousePosition().LengthRelativeTo(hitObject.Position * SDK.OsuManager.WindowManager.PlayfieldRatio);
            float disnumNormal = SDK.GetOsuMousePosition().LengthRelativeTo(LastOnNotePos);
            if (disnumPlayField <= HitObjectRadius * HitScanMultiplier)
            {
                LastOnNotePos = SDK.GetOsuMousePosition();
                return HitScanResult.CanHit;
            }
            else if (LastOnNotePos != Vector2.Zero && disnumNormal <= (float)HitScanMaxDistance)
            {
                return HitScanResult.ShouldHit;
            }
            else if (hitObject is Slider && SDK.CurrentTime > hitObject.StartTime + HitWin50)
            {
                return HitScanResult.ShouldHit;
            }
            else if (disnumPlayField <= HitObjectRadius + HitScanRadiusAdd)
            {
                return HitScanResult.CanHit;
            }
            return HitScanResult.Wait;
        }

        private ValueTuple<int, int> RandomizeHitObjectTimings(int index)
        {
            float timingAdjustmentFactor = random.NextFloat(1.1f, 1.8f);
            int timingOffset;
            if (Logic.isHitKeyPressed)
            {
                timingOffset = random.Next(-HitWin100 / 2, HitWin100 / 3 + 1);
            }
            else
            {
                int range = HitWin300 / (int)timingAdjustmentFactor;
                timingOffset = random.Next(-range, range + 1) - (range / 4);
                if (random.Next(0, 100) < 50)
                {
                    timingOffset -= random.Next(0, range / 2);
                }
            }
            int timingValue = random.Next(HitWin300, HitWin300 * 2);
            int additionalTiming = (CurrentBeatmap.HitObjects[index] is HitCircle)
                ? timingValue
                : random.Next(-HitWin300 / 2, HitWin300 * 2 + 1);
            additionalTiming += random.Next(-HitWin300 / 4, HitWin300 / 4 + 1);
            return (timingOffset, additionalTiming);
        }
    }
}
