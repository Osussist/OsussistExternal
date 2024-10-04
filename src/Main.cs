using Osussist.src.cheat;
using Osussist.src.cheat.aimbot;
using Osussist.src.config;
using Osussist.src.gui;
using Osussist.src.osu;
using Osussist.src.utils;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static Osussist.src.osu.helpers.OsuProcess;

namespace Osussist
{
    class Program
    {
        #region NativeImports
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;
        #endregion

        [STAThread]
        static void Main(string[] args)
        {
            Logger logger = new Logger(true, "osussist.log", (int)LogLevels.INFO);

            AppDomain currentDomain = default(AppDomain);
            currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += GlobalUnhandledExceptionHandler;
            Application.ThreadException += GlobalThreadExceptionHandler;

            try
            {
                var consoleHandle = GetConsoleWindow();

                if (args.Length > 0)
                {
                    if (args.Contains("--showconsole") || args.Contains("-sc"))
                        ShowWindow(consoleHandle, SW_SHOW);
                    else
                        ShowWindow(consoleHandle, SW_HIDE);

                    if (args.Contains("--debug") || args.Contains("-dbg"))
                        logger.UpdateLogLevel((int)LogLevels.DEBUG);

                    logger.Info("Main", "Starting Osussist...");
                }
                else
                {
                    ShowWindow(consoleHandle, SW_HIDE);
                }

                Config config = new Config();
                if (!config.Load("config.json"))
                    config.Save("config.json");

                Thread guiThread = new Thread(new ThreadStart(RenderGUI));
                guiThread.SetApartmentState(ApartmentState.STA);
                guiThread.Start();
                logger.Info("Main", "GUI has been initialized successfully");

                OsuSDK SDK = new OsuSDK("osu!", true);
                logger.Info("Main", "SDK has been initialized successfully");

                Relax relax = new Relax(SDK);
                Aimbot aimbot = new Aimbot(SDK);
                logger.Info("Main", "Cheats have been initialized successfully");

                MainLoop(SDK, aimbot, relax);
            }
            catch (Exception e)
            {
                logger.Error("Main", e.Message);
            }
        }

        public static void RenderGUI()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainGUI());
            Environment.Exit(0);
        }

        public static void MainLoop(OsuSDK SDK, Aimbot aimbotModule, Relax relaxModule)
        {
            try
            {
                Thread aimbotThread = new Thread(new ThreadStart(aimbotModule.Loop));
                aimbotThread.Start();

                if (SDK.OsuManager.ProcessManager.ClientType == ClientTypes.Stable)
                {
                    Thread relaxThread = new Thread(new ThreadStart(relaxModule.Loop));
                    relaxThread.Start();
                }
            }
            catch (Exception e)
            {
                Logger logger = Logger.LoggingInstance;
                logger.Error("Main", e.Message);
            }
        }

        private static void GlobalUnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = default(Exception);
            ex = (Exception)e.ExceptionObject;
            Logger logger = Logger.LoggingInstance;
            logger.Error("Main", $"{ex.Message} on line {ex.StackTrace}");
            MessageBox.Show($"Fatal error occurred: {ex.Message}", "Error, please report this to the developer!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private static void GlobalThreadExceptionHandler(object sender, ThreadExceptionEventArgs e)
        {
            Exception ex = default(Exception);
            ex = e.Exception;
            Logger logger = Logger.LoggingInstance;
            logger.Error("Main", $"{ex.Message} on line {ex.StackTrace}");
            MessageBox.Show($"Fatal error occurred: {ex.Message}", "Error, please report this to the developer!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}