using System;
using System.Runtime.InteropServices;

namespace MacroApp.Services
{
    public class InputService
    {
        [DllImport("user32.dll")]
        private static extern uint SendInput(
            uint nInputs,
            INPUT[] pInputs,
            int cbSize);

        [DllImport("user32.dll")]
        private static extern bool SetCursorPos(int X, int Y);

        private const uint INPUT_KEYBOARD = 1;
        private const uint INPUT_MOUSE = 0;

        private const uint KEYEVENTF_KEYUP = 0x0002;

        private const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const uint MOUSEEVENTF_LEFTUP = 0x0004;
        private const uint MOUSEEVENTF_RIGHTDOWN = 0x0008;
        private const uint MOUSEEVENTF_RIGHTUP = 0x0010;
        private const uint MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        private const uint MOUSEEVENTF_MIDDLEUP = 0x0040;
        private const uint MOUSEEVENTF_WHEEL = 0x0800;

        [StructLayout(LayoutKind.Sequential)]
        private struct INPUT
        {
            public uint type;
            public InputUnion U;
        }

        [StructLayout(LayoutKind.Explicit)]
        private struct InputUnion
        {
            [FieldOffset(0)]
            public KEYBDINPUT ki;

            [FieldOffset(0)]
            public MOUSEINPUT mi;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct KEYBDINPUT
        {
            public ushort wVk;
            public ushort wScan;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct MOUSEINPUT
        {
            public int dx;
            public int dy;
            public uint mouseData;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        public void KeyDown(ushort key)
        {
            SendKeyboardInput(key, 0);
        }

        public void KeyUp(ushort key)
        {
            SendKeyboardInput(key, KEYEVENTF_KEYUP);
        }

        public void PressKey(ushort key)
        {
            KeyDown(key);
            KeyUp(key);
        }

        private void SendKeyboardInput(ushort key, uint flags)
        {
            INPUT[] inputs = new INPUT[1];

            inputs[0].type = INPUT_KEYBOARD;
            inputs[0].U.ki.wVk = key;
            inputs[0].U.ki.dwFlags = flags;

            SendInput(
                (uint)inputs.Length,
                inputs,
                Marshal.SizeOf(typeof(INPUT)));
        }

        public void MoveMouse(int x, int y)
        {
            SetCursorPos(x, y);
        }

        public void LeftClick()
        {
            MouseLeftDown();
            MouseLeftUp();
        }

        public void MouseLeftDown()
        {
            SendMouseInput(MOUSEEVENTF_LEFTDOWN);
        }

        public void MouseLeftUp()
        {
            SendMouseInput(MOUSEEVENTF_LEFTUP);
        }

        public void MouseRightDown()
        {
            SendMouseInput(MOUSEEVENTF_RIGHTDOWN);
        }

        public void MouseRightUp()
        {
            SendMouseInput(MOUSEEVENTF_RIGHTUP);
        }

        public void MouseMiddleDown()
        {
            SendMouseInput(MOUSEEVENTF_MIDDLEDOWN);
        }

        public void MouseMiddleUp()
        {
            SendMouseInput(MOUSEEVENTF_MIDDLEUP);
        }

        public void MouseWheel(int delta)
        {
            INPUT[] inputs = new INPUT[1];

            inputs[0].type = INPUT_MOUSE;
            inputs[0].U.mi.mouseData = (uint)delta;
            inputs[0].U.mi.dwFlags = MOUSEEVENTF_WHEEL;

            SendInput(
                (uint)inputs.Length,
                inputs,
                Marshal.SizeOf(typeof(INPUT)));
        }

        private void SendMouseInput(uint flags)
        {
            INPUT[] inputs = new INPUT[1];

            inputs[0].type = INPUT_MOUSE;
            inputs[0].U.mi.dwFlags = flags;

            SendInput(
                (uint)inputs.Length,
                inputs,
                Marshal.SizeOf(typeof(INPUT)));
        }
    }
}
