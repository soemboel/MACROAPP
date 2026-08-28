using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using MacroApp.Models;

namespace MacroApp.Services
{
    public class MacroRecorder : IDisposable
    {
        private const int WH_KEYBOARD_LL = 13;
        private const int WH_MOUSE_LL = 14;

        private const int WM_KEYDOWN = 0x0100;
        private const int WM_KEYUP = 0x0101;
        private const int WM_SYSKEYDOWN = 0x0104;
        private const int WM_SYSKEYUP = 0x0105;

        private const int WM_MOUSEMOVE = 0x0200;
        private const int WM_LBUTTONDOWN = 0x0201;
        private const int WM_LBUTTONUP = 0x0202;
        private const int WM_RBUTTONDOWN = 0x0204;
        private const int WM_RBUTTONUP = 0x0205;
        private const int WM_MBUTTONDOWN = 0x0207;
        private const int WM_MBUTTONUP = 0x0208;

        private const int MouseMoveThreshold = 5;

        private readonly LowLevelKeyboardProc keyboardProc;
        private readonly LowLevelMouseProc mouseProc;
        private readonly List<MacroAction> actions;

        private IntPtr keyboardHook = IntPtr.Zero;
        private IntPtr mouseHook = IntPtr.Zero;

        private Stopwatch stopwatch;
        private long lastEventTicks;
        private bool isRecording;

        private int lastMouseX = -1;
        private int lastMouseY = -1;

        public event Action<MacroAction> ActionRecorded;

        public bool IsRecording
        {
            get { return isRecording; }
        }

        public MacroRecorder(List<MacroAction> actions)
        {
            this.actions = actions;
            keyboardProc = KeyboardHookCallback;
            mouseProc = MouseHookCallback;
        }

        public void Start()
        {
            if (isRecording)
                return;

            IntPtr moduleHandle = GetModuleHandle(null);

            keyboardHook = SetWindowsHookEx(
                WH_KEYBOARD_LL,
                keyboardProc,
                moduleHandle,
                0);

            mouseHook = SetWindowsHookEx(
                WH_MOUSE_LL,
                mouseProc,
                moduleHandle,
                0);

            if (keyboardHook == IntPtr.Zero ||
                mouseHook == IntPtr.Zero)
            {
                Stop();
                throw new InvalidOperationException(
                    "Gagal memasang global hook untuk recording.");
            }

            lastMouseX = -1;
            lastMouseY = -1;
            lastEventTicks = 0;
            stopwatch = Stopwatch.StartNew();
            isRecording = true;
        }

        public void Stop()
        {
            isRecording = false;

            if (stopwatch != null)
            {
                stopwatch.Stop();
                stopwatch = null;
            }

            if (keyboardHook != IntPtr.Zero)
            {
                UnhookWindowsHookEx(keyboardHook);
                keyboardHook = IntPtr.Zero;
            }

            if (mouseHook != IntPtr.Zero)
            {
                UnhookWindowsHookEx(mouseHook);
                mouseHook = IntPtr.Zero;
            }
        }

        private void RecordAction(
            MacroActionType type,
            string parameter,
            int x,
            int y)
        {
            long elapsed = stopwatch.ElapsedMilliseconds;
            int delay = (int)(elapsed - lastEventTicks);
            lastEventTicks = elapsed;

            MacroAction action = new MacroAction
            {
                Type = type,
                Parameter = parameter,
                X = x,
                Y = y,
                Delay = delay
            };

            actions.Add(action);

            ActionRecorded?.Invoke(action);
        }

        private IntPtr KeyboardHookCallback(
            int nCode,
            IntPtr wParam,
            IntPtr lParam)
        {
            if (nCode >= 0 && isRecording)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                Keys key = (Keys)vkCode;

                if (IsFunctionKey(key))
                {
                    return CallNextHookEx(
                        keyboardHook,
                        nCode,
                        wParam,
                        lParam);
                }

                int message = wParam.ToInt32();

                if (message == WM_KEYDOWN ||
                    message == WM_SYSKEYDOWN)
                {
                    RecordAction(
                        MacroActionType.KeyDown,
                        key.ToString(),
                        0,
                        0);
                }
                else if (message == WM_KEYUP ||
                         message == WM_SYSKEYUP)
                {
                    RecordAction(
                        MacroActionType.KeyUp,
                        key.ToString(),
                        0,
                        0);
                }
            }

            return CallNextHookEx(
                keyboardHook,
                nCode,
                wParam,
                lParam);
        }

        private IntPtr MouseHookCallback(
            int nCode,
            IntPtr wParam,
            IntPtr lParam)
        {
            if (nCode >= 0 && isRecording)
            {
                MSLLHOOKSTRUCT hookStruct =
                    (MSLLHOOKSTRUCT)Marshal.PtrToStructure(
                        lParam,
                        typeof(MSLLHOOKSTRUCT));

                int message = wParam.ToInt32();
                int x = hookStruct.pt.x;
                int y = hookStruct.pt.y;

                switch (message)
                {
                    case WM_MOUSEMOVE:
                        if (lastMouseX < 0 ||
                            Math.Abs(x - lastMouseX) >= MouseMoveThreshold ||
                            Math.Abs(y - lastMouseY) >= MouseMoveThreshold)
                        {
                            lastMouseX = x;
                            lastMouseY = y;

                            RecordAction(
                                MacroActionType.MouseMove,
                                null,
                                x,
                                y);
                        }

                        break;

                    case WM_LBUTTONDOWN:
                        RecordAction(
                            MacroActionType.MouseLeftDown,
                            "Left",
                            x,
                            y);
                        break;

                    case WM_LBUTTONUP:
                        RecordAction(
                            MacroActionType.MouseLeftUp,
                            "Left",
                            x,
                            y);
                        break;

                    case WM_RBUTTONDOWN:
                        RecordAction(
                            MacroActionType.MouseRightDown,
                            "Right",
                            x,
                            y);
                        break;

                    case WM_RBUTTONUP:
                        RecordAction(
                            MacroActionType.MouseRightUp,
                            "Right",
                            x,
                            y);
                        break;

                    case WM_MBUTTONDOWN:
                        RecordAction(
                            MacroActionType.MouseMiddleDown,
                            "Middle",
                            x,
                            y);
                        break;

                    case WM_MBUTTONUP:
                        RecordAction(
                            MacroActionType.MouseMiddleUp,
                            "Middle",
                            x,
                            y);
                        break;
                }
            }

            return CallNextHookEx(
                mouseHook,
                nCode,
                wParam,
                lParam);
        }

        private static bool IsFunctionKey(Keys key)
        {
            return key >= Keys.F1 && key <= Keys.F24;
        }

        public void Dispose()
        {
            Stop();
        }

        private delegate IntPtr LowLevelKeyboardProc(
            int nCode,
            IntPtr wParam,
            IntPtr lParam);

        private delegate IntPtr LowLevelMouseProc(
            int nCode,
            IntPtr wParam,
            IntPtr lParam);

        [StructLayout(LayoutKind.Sequential)]
        private struct POINT
        {
            public int x;
            public int y;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct MSLLHOOKSTRUCT
        {
            public POINT pt;
            public uint mouseData;
            public uint flags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(
            int idHook,
            LowLevelKeyboardProc lpfn,
            IntPtr hMod,
            uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(
            int idHook,
            LowLevelMouseProc lpfn,
            IntPtr hMod,
            uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(
            IntPtr hhk,
            int nCode,
            IntPtr wParam,
            IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
    }
}
