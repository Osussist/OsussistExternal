using System.Drawing;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;

namespace Osussist.src.osu.helpers
{
    public class OsuWindow
    {
        #region NativeImports
        [DllImport("user32.dll")]
        private static extern bool GetClientRect(IntPtr hwnd, out Rect rectangle);

        [DllImport("user32.dll")]
        private static extern bool ClientToScreen(IntPtr hwnd, out Point point);

        [DllImport("user32.dll")]
        public static extern int GetSystemMetrics(int nIndex);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll")]
        private static extern int GetWindowTextLength(IntPtr hWnd);

        private struct Rect
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }
        #endregion

        private IntPtr WindowHandle { get; set; }

        public Vector2 WindowSize
        {
            get
            {
                GetClientRect(WindowHandle, out Rect rect);
                return new Vector2(rect.Right, rect.Bottom);
            }
        }

        public Vector2 WindowPosition // rel to screen
        {
            get
            {
                ClientToScreen(WindowHandle, out var OsuPosition);
                return new Vector2(OsuPosition.X, OsuPosition.Y);
            }
        }

        public float WindowRatio
        {
            get => WindowSize.Y / 480;
        }

        public Vector2 PlayfieldSize
        {
            get
            {
                float width = 512 * WindowRatio;
                float height = 384 * WindowRatio;
                return new Vector2(width, height);
            }
        }

        public Vector2 PlayfieldPosition // rel to win
        {
            get
            {
                var WindowCentre = WindowSize / 2;
                float x = WindowCentre.X - PlayfieldSize.X / 2;
                float y = WindowCentre.Y - PlayfieldSize.Y / 2;
                return new Vector2(x, y);
            }
        }

        public float PlayfieldRatio
        {
            get => PlayfieldSize.Y / 384;
        }

        public Vector2 ScreenMetrics
        {
            get
            {
                return new Vector2(GetSystemMetrics(0), GetSystemMetrics(1));
            }
        }

        public OsuWindow(IntPtr windowHandle)
        {
            WindowHandle = windowHandle;
        }

        public string GetActiveWindowTitle()
        {
            IntPtr hWnd = GetForegroundWindow();
            int length = GetWindowTextLength(hWnd);
            StringBuilder sb = new StringBuilder(length + 1);
            GetWindowText(hWnd, sb, sb.Capacity);
            return sb.ToString();
        }

        public string GetGameWindowTitle()
        {
            int length = GetWindowTextLength(WindowHandle);
            StringBuilder sb = new StringBuilder(length + 1);
            GetWindowText(WindowHandle, sb, sb.Capacity);
            return sb.ToString();
        }
    }
}
