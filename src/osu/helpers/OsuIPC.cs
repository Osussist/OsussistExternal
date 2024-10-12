using Osussist.src.utils;
using System.Diagnostics;
using System.Reflection;

namespace Osussist.src.osu.helpers
{
    public class OsuIPC
    {
        private static Logger logger = Logger.LoggingInstance;
        public object OsuInterProcess { get; private set; }
        public MethodInfo BulkDataMethod { get; private set; }

        public OsuIPC(Process GameProcess)
        {
            logger.Info("SDK.OsuIPC", $"Connecting to Osu!'s IPC...");

            string assemblyPath = GameProcess.MainModule.FileName;
            logger.Debug("SDK.OsuIPC", $"Assembly path is {assemblyPath}");

            var assembly = Assembly.LoadFrom(assemblyPath);
            var interProcessOsuType = assembly.ExportedTypes.First(a => a.FullName == "osu.Helpers.InterProcessOsu");
            logger.Debug("SDK.OsuIPC", $"Found InterProcessOsu type");

            AppDomain.CurrentDomain.AssemblyResolve += (sender, eventArgs) => eventArgs.Name.Contains("osu!") ? Assembly.LoadFrom(assemblyPath) : null;

            OsuInterProcess = Activator.GetObject(interProcessOsuType, "ipc://osu!/loader");
            BulkDataMethod = interProcessOsuType.GetMethod("GetBulkClientData");
            logger.Info("SDK.OsuIPC", $"Connected to Osu!'s IPC successfully");
        }
    }
}
