using OsuParsers.Beatmaps;
using OsuParsers.Beatmaps.Objects;
using Osussist.src.config;
using Osussist.src.config.objects;
using Osussist.src.osu;
using Osussist.src.osu.helpers;
using Osussist.src.utils;
using System.Numerics;

namespace Osussist.src.cheat.aimbot
{
    public class Stable
    {
        private Logger logger { get; set; }
        private OsuSDK SDK { get; set; }
        private Mouse Mouse { get; set; }

        private int HitWin50;
        private int HitWin300;
        private int SongIndex;
        private int LastHitTime;
        private Beatmap CurrentBeatmap;
        private int LastBeatmapId = -99;
        private HitObject CurrentHitObject;
        private Vector2 LastOnNotePos = Vector2.Zero;

        public Stable(OsuSDK givenSDK)
        {
            SDK = givenSDK;
            Mouse = new Mouse(SDK);
            logger = Logger.LoggingInstance;
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

        public void Loop()
        {
            while (SDK.isGameFocused && !SDK.isPaused)
            {
                if (SDK.isPlaying)
                {
                    CurrentBeatmap = Relax.CurrentBeatmap;
                    if (CurrentBeatmap == null)
                    {
                        logger.Info("Aimbot.Stable", "No beatmap loaded, stopping aimbot");
                        ResetLoop();
                    }
                    else if (LastBeatmapId != CurrentBeatmap.MetadataSection.BeatmapID)
                    {
                        LastBeatmapId = CurrentBeatmap.MetadataSection.BeatmapID;
                        logger.Info("Aimbot.Stable", $"Loaded beatmap: {CurrentBeatmap.MetadataSection.Artist} - {CurrentBeatmap.MetadataSection.Title} [{CurrentBeatmap.MetadataSection.Version}]");
                    }
                    HitWin50 = SDK.HitWindow50(CurrentBeatmap.DifficultySection.OverallDifficulty);
                    HitWin300 = SDK.HitWindow300(CurrentBeatmap.DifficultySection.OverallDifficulty);

                    ResetLoop();

                    while ((SDK.isGameFocused && !SDK.isPaused) && SongIndex < CurrentBeatmap.HitObjects.Count)
                    {
                        if (!SDK.isPlaying)
                        {
                            logger.Info("Aimbot.Stable", "Game is not playing, stopping aimbot");
                            ResetLoop();
                        }
                        else if (SDK.isPaused || !SDK.isGameFocused)
                        {
                            logger.Info("Aimbot.Stable", "Game is paused or not focused, stopping aimbot");
                            ResetLoop();
                        }
                        else
                        {
                            int possibleTime = SDK.CurrentTime + Config.config.osusettings.audiooffset;
                            if (possibleTime < LastHitTime)
                            {
                                logger.Debug("Aimbot.Stable", "Detected time travel, resetting aimbot");
                                ResetLoop();
                            }
                            else
                            {
                                if (CurrentHitObject != null && SDK != null)
                                {
                                    if (possibleTime >= CurrentHitObject.StartTime - HitWin50)
                                    {
                                        if (possibleTime <= CurrentHitObject.StartTime + HitWin300)
                                        {
                                            Vector2 hitObject;
                                            if (Config.config.aimbotsettings.hardrockenabled)
                                                hitObject = SDK.GetHRHitObjectPos(CurrentHitObject);
                                            else
                                                hitObject = SDK.GetRealHitObjectPos(CurrentHitObject);

                                            logger.Debug("Aimbot.Stable", $"Hitobject found at {hitObject.X}, {hitObject.Y}");
                                            if (!Logic.isHoldingKeys && Logic.isAimbotEnabled && SDK.GetRealMousePosition().LengthRelativeTo(hitObject) <= Config.config.aimbotsettings.fovsize)
                                            {
                                                LastOnNotePos = hitObject;
                                                PerformMove(hitObject);
                                            }
                                        }
                                        else
                                        {
                                            logger.Debug("Aimbot.Stable", "Missed hitobject, going to next object");
                                            NextObject();
                                        }
                                    }
                                }
                                else
                                {
                                    logger.Debug("Aimbot.Stable", "No hitobject found, resetting aimbot");
                                    ResetLoop();
                                }
                            }
                        }
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
                CurrentHitObject = CurrentBeatmap.HitObjects[SongIndex];
                LastHitTime = -CurrentBeatmap.GeneralSection.AudioLeadIn;
            }
            catch (Exception e)
            {
                logger.Error("Aimbot.Stable", $"Failed to reset loop: {e.Message}");
            }
        }

        private void NextObject()
        {
            int tempIndex = SongIndex;
            SongIndex = tempIndex + 1;
            if (SongIndex < CurrentBeatmap.HitObjects.Count)
            {
                CurrentHitObject = CurrentBeatmap.HitObjects[SongIndex];
            }
        }

        private void PerformMove(Vector2 hitObject)
        {
            if (Config.config.aimbotsettings.algorithm is MouseAlgorithms.Steps)
                Mouse.MoveAlgorithmSteps(hitObject);
            else if (Config.config.aimbotsettings.algorithm is MouseAlgorithms.Bezier)
                Mouse.MoveAlgorithmBezier(hitObject);
            else if (Config.config.aimbotsettings.algorithm is MouseAlgorithms.Linear)
                Mouse.MoveAlgorithmLinear(hitObject);
            else if (Config.config.aimbotsettings.algorithm is MouseAlgorithms.Flick)
                Mouse.MoveAlgorithmFlick(hitObject);
            else
            {
                logger.Warning("Aimbot.Stable", "Invalid mouse algorithm, defaulting to steps.");
                Mouse.MoveAlgorithmSteps(hitObject);
            }
        }
    }
}
