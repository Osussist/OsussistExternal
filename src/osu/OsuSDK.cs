using OsuParsers.Beatmaps;
using OsuParsers.Beatmaps.Objects;
using OsuParsers.Database.Objects;
using OsuParsers.Decoders;
using OsuParsers.Enums;
using Osussist.src.config;
using Osussist.src.osu.helpers;
using Osussist.src.utils;
using System.Numerics;
using System.Runtime.InteropServices;
using static Osussist.src.osu.helpers.OsuProcess;

namespace Osussist.src.osu
{
    public class OsuSDK
    {
        #region NativeImports
        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;
        }

        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out POINT lpPoint);

        #endregion

        private Logger logger = Logger.LoggingInstance;
        public OsuManager OsuManager { get; private set; }

        public static OsuSDK Instance { get; private set; }

        public OsuSDK(string gameName, bool preferIPC)
        {
            Instance = this;
            OsuManager = new OsuManager(gameName);
            if (OsuManager.ProcessManager.ClientType == ClientTypes.Stable)
            {
                OsuManager.MemoryManager.BuildMemorySDK(this);
            }
        }

        // Properties
        public Mods CurrentMods { get; set; } = Mods.None;

        public int CurrentTime
        {
            get
            {
                if (OsuManager.ProcessManager.ClientType == ClientTypes.Stable)
                {
                    var data = OsuManager.IPCManager.BulkDataMethod.Invoke(OsuManager.IPCManager.OsuInterProcess, null);
                    return (int)data.GetType().GetField("MenuTime").GetValue(data);
                }
                else
                {
                    //TODO: Add lazer support
                    return 0;
                }
            }
        }

        public bool isPlaying
        {
            get
            {
                if (OsuManager.ProcessManager.ClientType == ClientTypes.Stable)
                {
                    string processName = OsuManager.WindowManager.GetGameWindowTitle();
                    return processName.Contains("-");
                }
                else
                {
                    // TODO: Add lazer support
                    return true;
                }
            }
        }

        public bool isPaused
        {
            get
            {
                if (OsuManager.ProcessManager.ClientType == ClientTypes.Stable)
                {
                    var data = OsuManager.IPCManager.BulkDataMethod.Invoke(OsuManager.IPCManager.OsuInterProcess, null);
                    return !(bool)data.GetType().GetField("AudioPlaying").GetValue(data);
                }
                else
                {
                    return false;
                }
            }
        }

        public bool isGameFocused
        {
            get
            {
                return OsuManager.WindowManager.GetActiveWindowTitle().Contains("osu!");
            }
        }

        public string SongsPath
        {
            get
            {
                if (OsuManager.ProcessManager.ClientType == ClientTypes.Stable)
                {
                    return OsuManager.ProcessManager.GameFolder + "Songs\\";
                }
                else
                {
                    //TODO: Add lazer support
                    return "";
                }
            }
        }

        public string MapHash
        {
            get
            {
                if (OsuManager.ProcessManager.ClientType == ClientTypes.Stable)
                {
                    var data = OsuManager.IPCManager.BulkDataMethod.Invoke(OsuManager.IPCManager.OsuInterProcess, null);
                    return (string)data.GetType().GetField("BeatmapChecksum").GetValue(data);
                }
                else
                {
                    //TODO: Add lazer support
                    return "";
                }
            }
        }

        public Beatmap CurrentBeatmap
        {
            get
            {
                OsuManager.DataManager.UpdateDatabase();
                DbBeatmap dbBeatmap = OsuManager.DataManager.Database.Beatmaps.Find((DbBeatmap b) => b.MD5Hash == MapHash);
                if (dbBeatmap != null)
                {
                    return BeatmapDecoder.Decode(SongsPath + dbBeatmap.FolderName + "\\" + dbBeatmap.FileName);
                }
                else
                {
                    return null;
                }
            }
        }

        //Functions
        public Vector2 GetRealHitObjectPos(HitObject hitObject)
        {
            Vector2 hitObjectCoords = new Vector2(hitObject.Position.X, hitObject.Position.Y);
            Vector2 scaledCoords = hitObjectCoords * OsuManager.WindowManager.PlayfieldRatio;
            return OsuManager.WindowManager.PlayfieldPosition + scaledCoords;
        }

        public Vector2 GetHRHitObjectPos(HitObject hitObject)
        {
            Vector2 scale = new Vector2(
                OsuManager.WindowManager.PlayfieldSize.X / 512f, 
                OsuManager.WindowManager.PlayfieldSize.Y / 384f
            );

            Vector2 realPos = new Vector2(
                hitObject.Position.X * scale.X,
                (384f - hitObject.Position.Y) * scale.Y
            );
            return OsuManager.WindowManager.PlayfieldPosition + realPos;
        }

        public float GetHitObjectRadius(Beatmap beatmap)
        {
            return (float)((double)(OsuManager.WindowManager.PlayfieldSize.X / 8f) * (1.0 - 0.699999988079071 * AdjustDifficulty((double)beatmap.DifficultySection.CircleSize))) / 2f / OsuManager.WindowManager.PlayfieldRatio * 1.00041f;
        }

        public int HitWindow300(double od)
        {
            return (int)DifficultyRange(od, 80.0, 50.0, 20.0);
        }

        public int HitWindow100(double od)
        {
            return (int)DifficultyRange(od, 140.0, 100.0, 60.0);
        }

        public int HitWindow50(double od)
        {
            return (int)DifficultyRange(od, 200.0, 150.0, 100.0);
        }

        public double AdjustDifficulty(double difficulty)
        {
            return (this.ApplyModsToDifficulty(difficulty, 1.3) - 5.0) / 5.0;
        }

        public double ApplyModsToDifficulty(double difficulty, double hardrockFactor)
        {
            if (Config.config.relaxsettings.hardrockenabled)
            {
                difficulty = Math.Min(10.0, difficulty * hardrockFactor);
            }
            return difficulty;
        }

        public Vector2 GetRealMousePosition()
        {
            POINT point;
            if (GetCursorPos(out point))
            {
                return new Vector2(point.X, point.Y);
            }
            throw new Exception("Failed to get cursor position");
        }

        public Vector2 GetOsuMousePosition()
        {
            POINT point;
            if (GetCursorPos(out point))
            {
                return new Vector2(point.X, point.Y) - (OsuManager.WindowManager.WindowPosition + OsuManager.WindowManager.PlayfieldPosition);
            }
            throw new Exception("Failed to get cursor position");
        }

        public double DifficultyRange(double difficulty, double min, double mid, double max)
        {
            difficulty = ApplyModsToDifficulty(difficulty, 1.4);
            if (difficulty > 5.0)
            {
                return mid + (max - mid) * (difficulty - 5.0) / 5.0;
            }
            if (difficulty < 5.0)
            {
                return mid - (mid - min) * (5.0 - difficulty) / 5.0;
            }
            return mid;
        }
    }
}
