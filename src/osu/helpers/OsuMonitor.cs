using Osussist.src.utils;
using System.Diagnostics;

namespace Osussist.src.osu.helpers
{
    public class OsuMonitor
    {
        private Logger logger = Logger.LoggingInstance;
        private CancellationTokenSource _cancellationTokenSource;
        private readonly int _checkIntervalMs;

        public OsuMonitor(int checkIntervalMs = 1000)
        {
            _checkIntervalMs = checkIntervalMs;
        }

        public void StartMonitoring()
        {
            _cancellationTokenSource = new CancellationTokenSource();

            Task.Run(async () =>
            {
                while (!_cancellationTokenSource.Token.IsCancellationRequested)
                {
                    if (Process.GetProcessesByName("osu!").Length == 0)
                    {
                        logger.Info("OsuMonitor", "osu! process not found. Exiting...");
                        Environment.Exit(0);
                    }

                    await Task.Delay(_checkIntervalMs, _cancellationTokenSource.Token);
                }
            }, _cancellationTokenSource.Token);
        }

        public void StopMonitoring()
        {
            _cancellationTokenSource?.Cancel();
        }
    }
}
