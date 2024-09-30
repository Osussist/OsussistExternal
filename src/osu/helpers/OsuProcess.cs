using Osussist.src.utils;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace Osussist.src.osu.helpers
{
    public class OsuProcess
    {
        #region NativeImports
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern uint QueryFullProcessImageName([In] IntPtr hProcess, [In] uint dwFlags, [Out] StringBuilder lpExeName, [In, Out] ref uint lpdwSize);
        #endregion

        private Logger logger = Logger.LoggingInstance;
        public Process GameProcess { get; private set; }
        public ClientTypes ClientType { get; private set; }
        public string GameFolder { get; private set; }

        public OsuProcess(string ProcessName)
        {
            logger.Info("SDK.OsuProcess", "Waiting for Osu! to start...");

            while (Process.GetProcessesByName(ProcessName).Length == 0)
            {
                Thread.Sleep(10);
            }

            Thread.Sleep(3000);

            GameProcess = Process.GetProcessesByName(ProcessName).FirstOrDefault();
            logger.Info("SDK.OsuProcess", $"Found Osu! process with PID {GameProcess.Id.ToString()}");
            ClientType = DetermineClientType();
            logger.Info("SDK.OsuProcess", $"Client type is {ClientType.ToString()}");
            GameFolder = GetGameFolder();
            logger.Info("SDK.OsuProcess", $"Game folder is {GameFolder}");
        }

        public ClientTypes DetermineClientType()
        {
            try
            {
                FileVersionInfo fileInfo = GameProcess.MainModule.FileVersionInfo;
                logger.Debug("SDK.OsuManager", $"Product name is {fileInfo.ProductName}");
                if (fileInfo.ProductName != null && fileInfo.ProductName.Contains("osu!(lazer)"))
                {
                    return ClientTypes.Lazer;
                }
                else
                {
                    return ClientTypes.Stable;
                }
            }
            catch (Exception e)
            {
                if (e is System.ComponentModel.Win32Exception)
                {
                    logger.Error("SDK.OsuManager", $"Client is most likely Lazer since its a 64 bit process");
                    return ClientTypes.Lazer;
                }
                else
                {
                    logger.Error("SDK.OsuManager", $"An error occurred while getting the client type: {e.Message}");
                    return ClientTypes.Stable;
                }
            }
        }

        public string GetGameFolder()
        {
            try
            {
                if (ClientType == ClientTypes.Stable)
                {
                    return GameProcess.MainModule.FileName.Replace("osu!.exe", "");
                }
                else
                {
                    int buffer = 1024;
                    var fileNameBuilder = new StringBuilder(buffer);
                    uint bufferLength = (uint)fileNameBuilder.Capacity + 1;
                    return QueryFullProcessImageName(GameProcess.Handle, 0, fileNameBuilder, ref bufferLength) != 0 ?
                        fileNameBuilder.ToString().Replace("osu!.exe", "") :
                        null;
                }
            }
            catch (Exception e)
            {
                logger.Error("SDK.OsuManager", $"An error occurred while getting the game folder: {e.Message}");
                return "";
            }
        }

        public enum ClientTypes
        {
            Stable,
            Lazer
            // TODO: Add support for other clients
        }
    }
}
