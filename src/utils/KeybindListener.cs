using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WindowsInput.Native;

namespace Osussist.src.utils
{
    public class KeybindListener
    {
        #region NativeImports
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
        #endregion

        private static Logger logger = Logger.LoggingInstance;

        private static IntPtr hookID = IntPtr.Zero;
        private static LowLevelKeyboardProc proc = HookCallback;
        private static VirtualKeyCode capturedKey;
        private static Action<VirtualKeyCode> onKeyCaptured;

        public static void StartListening(out VirtualKeyCode key, Action<VirtualKeyCode> callback)
        {
            onKeyCaptured = callback;
            hookID = SetHook(proc);
            key = capturedKey;
        }

        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                capturedKey = (VirtualKeyCode)vkCode;
                logger.Info("KeybindListener", $"Key {capturedKey} has been captured");
                UnhookWindowsHookEx(hookID);
                onKeyCaptured?.Invoke(capturedKey);
            }
            return CallNextHookEx(hookID, nCode, wParam, lParam);
        }
    }
}
