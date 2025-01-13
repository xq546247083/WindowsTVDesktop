using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using WindowsTVDesktop.Enum;
using WindowsTVDesktop.Models;

namespace WindowsTVDesktop.Managers
{
    public static class GlobalHotKeyManager
    {
        [DllImport("User32.dll")]
        private static extern bool RegisterHotKey(
            [In] IntPtr hWnd,
            [In] int id,
            [In] MainHostKey fsModifiers,
            [In] SubHostKey vk);

        [DllImport("User32.dll")]
        private static extern bool UnregisterHotKey(
            [In] IntPtr hWnd,
            [In] int id);

        private static HwndSource hwndSource;
        private static WindowInteropHelper windowInteropHelper;
        private static HotKeyInfo homeHotKeyInfo = new HotKeyInfo(MainHostKey.Ctrl, SubHostKey.H);

        public static void Init(WindowInteropHelper _windowInteropHelper)
        {
            windowInteropHelper = _windowInteropHelper;
            hwndSource = HwndSource.FromHwnd(windowInteropHelper.Handle);

            hwndSource.AddHook(HwndHook);
            RegisterHotKey(homeHotKeyInfo);
        }

        public static void UnInit()
        {
            hwndSource.RemoveHook(HwndHook);
            hwndSource = null;
            UnregisterHotKey(homeHotKeyInfo.ToHotKeyID());
        }

        private static void RegisterHotKey(HotKeyInfo hotKeyInfo)
        {
            if (RegisterHotKey(windowInteropHelper.Handle, hotKeyInfo.ToHotKeyID(), hotKeyInfo.MainHostKey, hotKeyInfo.SubHostKey))
            {
                AppGlobal.MainWindowViewModel.GlobalHotKeyMsg = "主页：Ctrl+H";
            }
            else
            {
                AppGlobal.MainWindowViewModel.GlobalHotKeyMsg = "";
            }
        }

        private static void UnregisterHotKey(int hostKeyID)
        {
            UnregisterHotKey(windowInteropHelper.Handle, hostKeyID);
        }

        private static IntPtr HwndHook(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            const int WM_HOTKEY = 0x0312;
            switch (msg)
            {
                case WM_HOTKEY:
                    int lParamInt32 = lParam.ToInt32();
                    byte mainHostKey = (byte)(lParamInt32 & 0Xffff);
                    byte subHostKey = (byte)(lParamInt32 >> 16);
                    OnHotKeyPressed((MainHostKey)mainHostKey, (SubHostKey)subHostKey);
                    handled = true;
                    break;
            }

            return IntPtr.Zero;
        }

        private static void OnHotKeyPressed(MainHostKey mainHostKey, SubHostKey subHostKey)
        {
            if (mainHostKey == MainHostKey.Ctrl && subHostKey == SubHostKey.H) 
            {
                Application.Current.MainWindow.Show();
                Application.Current.MainWindow.Activate();
            }
        }
    }
}