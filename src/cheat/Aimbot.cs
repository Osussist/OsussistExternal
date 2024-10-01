using Osussist.src.cheat.aimbot;
using Osussist.src.config;
using Osussist.src.osu;
using Osussist.src.utils;
using System.Numerics;
using System.Windows.Forms;
using static Osussist.src.osu.helpers.OsuProcess;

namespace Osussist.src.cheat
{
    public class Aimbot
    {
        private Logger logger = Logger.LoggingInstance;
        private OsuSDK SDK { get; set; }

        public Aimbot(OsuSDK givenSDK)
        {
            SDK = givenSDK;
        }

        public void Loop()
        {
            while (true)
            {
                if (Logic.isAimbotEnabled)
                {
                    if ((SDK.OsuManager.ProcessManager.ClientType == ClientTypes.Stable && !Config.config.overrides.overrideaimbot))
                    {
                        new Stable(SDK).Loop();
                    }
                    else if (SDK.OsuManager.ProcessManager.ClientType == ClientTypes.Lazer 
                        || (SDK.OsuManager.ProcessManager.ClientType == ClientTypes.Stable && Config.config.overrides.overrideaimbot))
                    {
                        new Lazer(SDK).Loop();
                    }
                }
            }
        }
    }
}
