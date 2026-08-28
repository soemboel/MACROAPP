using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MacroApp.Services
{
    public class HotkeyService
    {
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(
            IntPtr hWnd,
            int id,
            uint fsModifiers,
            uint vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(
            IntPtr hWnd,
            int id);

        public const int START_HOTKEY = 1;
        public const int STOP_HOTKEY = 2;
        public const int RECORD_START_HOTKEY = 3;
        public const int RECORD_STOP_HOTKEY = 4;

        public const uint MOD_NONE = 0;

        public bool Register(
            IntPtr handle,
            int id,
            Keys key)
        {
            return RegisterHotKey(
                handle,
                id,
                MOD_NONE,
                (uint)key);
        }

        public void Unregister(
            IntPtr handle,
            int id)
        {
            UnregisterHotKey(handle, id);
        }
    }
}