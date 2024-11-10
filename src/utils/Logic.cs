using Osussist.src.config;
using Osussist.src.osu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using WindowsInput.Native;

namespace Osussist.src.utils
{
    public class Logic
    {
        #region NativeImports
        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(int vKey);
        #endregion

        OsuSDK SDK { get; set; }

        public static bool isHoldingKeys
        {
            get
            {
                return GetAsyncKeyState((int)Config.config.keybindings.primarykey) != 0 
                    || GetAsyncKeyState((int)Config.config.keybindings.secondarykey) != 0;
            }
        }

        public static bool isAimbotEnabled
        {
            get
            {
                return (!Config.config.aimbotenabled && GetAsyncKeyState((int)Config.config.keybindings.aimbotkey) != 0
                    || Config.config.aimbotenabled && GetAsyncKeyState((int)Config.config.keybindings.aimbotkey) == 0);
            }
        }

        public static bool isHitKeyPressed
        {
            get
            {
                int relaxKey = (int)Config.config.keybindings.relaxkey;

                if (relaxKey == (int)VirtualKeyCode.CAPITAL)
                {
                    return (GetAsyncKeyState((int)VirtualKeyCode.CAPITAL) & 0x0001) != 0;
                }
                else if (relaxKey == (int)VirtualKeyCode.SCROLL)
                {
                    return (GetAsyncKeyState((int)VirtualKeyCode.SCROLL) & 0x0001) != 0;
                }
                else
                {
                    return GetAsyncKeyState(relaxKey) != 0;
                }
            }
        }
    }
}
