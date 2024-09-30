using Osussist.src.osu;
using Osussist.src.utils;
using System.Drawing;
using System.Numerics;
using System.Runtime.InteropServices;
using static Osussist.src.osu.helpers.OsuProcess;

namespace Osussist.src.osu.helpers
{
    public class OsuManager
    {
        private Logger logger = Logger.LoggingInstance;
        public OsuProcess ProcessManager { get; private set; }
        public OsuWindow WindowManager { get; private set; }
        public OsuIPC IPCManager { get; private set; }
        public OsuMemory MemoryManager { get; private set; }
        public OsuData DataManager { get; private set; }

        public OsuManager(string ProcessName)
        {
            ProcessManager = new OsuProcess(ProcessName);
            WindowManager = new OsuWindow(ProcessManager.GameProcess.MainWindowHandle);

            if (ProcessManager.ClientType == ClientTypes.Stable)
            {
                DataManager = new OsuData(ProcessManager);
                IPCManager = new OsuIPC(ProcessManager.GameProcess);
                MemoryManager = new OsuMemory(ProcessManager.GameProcess);
                logger.Info("SDK.OsuManager", "Memory reading and IPC have been enabled");
            }
            else
            {
                logger.Info("SDK.OsuManager", $"Client type {ProcessManager.ClientType.ToString()} does not support IPC and Memory reading");
                logger.Warning("SDK.OsuManager", $"Relax has been disabled on this client, Will fix this eventually ;_;");
            }
        }
    }
}
