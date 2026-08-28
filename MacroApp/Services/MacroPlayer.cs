using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using MacroApp.Models;

namespace MacroApp.Services
{
    public class MacroPlayer
    {
        private readonly InputService inputService;

        public bool IsRunning { get; private set; }

        public MacroPlayer()
        {
            inputService = new InputService();
        }

        public void Play(
            List<MacroAction> actions,
            bool repeat)
        {
            if (IsRunning)
                return;

            IsRunning = true;

            ThreadPool.QueueUserWorkItem(_ =>
            {
                try
                {
                    do
                    {
                        foreach (MacroAction action in actions)
                        {
                            if (!IsRunning)
                                return;

                            if (action.Delay > 0)
                                Thread.Sleep(action.Delay);

                            if (!IsRunning)
                                return;

                            ExecuteAction(action);
                        }
                    }
                    while (repeat && IsRunning);
                }
                finally
                {
                    IsRunning = false;
                }
            });
        }

        public void Stop()
        {
            IsRunning = false;
        }

        private void ExecuteAction(MacroAction action)
        {
            switch (action.Type)
            {
                case MacroActionType.KeyDown:
                    inputService.KeyDown(ParseKey(action.Parameter));
                    break;

                case MacroActionType.KeyUp:
                    inputService.KeyUp(ParseKey(action.Parameter));
                    break;

                case MacroActionType.KeyPress:
                    inputService.PressKey(ParseKey(action.Parameter));
                    break;

                case MacroActionType.MouseMove:
                    inputService.MoveMouse(action.X, action.Y);
                    break;

                case MacroActionType.MouseLeftDown:
                    inputService.MoveMouse(action.X, action.Y);
                    inputService.MouseLeftDown();
                    break;

                case MacroActionType.MouseLeftUp:
                    inputService.MoveMouse(action.X, action.Y);
                    inputService.MouseLeftUp();
                    break;

                case MacroActionType.MouseRightDown:
                    inputService.MoveMouse(action.X, action.Y);
                    inputService.MouseRightDown();
                    break;

                case MacroActionType.MouseRightUp:
                    inputService.MoveMouse(action.X, action.Y);
                    inputService.MouseRightUp();
                    break;

                case MacroActionType.MouseMiddleDown:
                    inputService.MoveMouse(action.X, action.Y);
                    inputService.MouseMiddleDown();
                    break;

                case MacroActionType.MouseMiddleUp:
                    inputService.MoveMouse(action.X, action.Y);
                    inputService.MouseMiddleUp();
                    break;

                case MacroActionType.MouseWheel:
                    inputService.MoveMouse(action.X, action.Y);
                    inputService.MouseWheel(int.Parse(action.Parameter));
                    break;

                case MacroActionType.MouseClick:
                    inputService.MoveMouse(action.X, action.Y);

                    if (string.Equals(
                            action.Parameter,
                            "Right",
                            StringComparison.OrdinalIgnoreCase))
                    {
                        inputService.MouseRightDown();
                        inputService.MouseRightUp();
                    }
                    else if (string.Equals(
                                 action.Parameter,
                                 "Middle",
                                 StringComparison.OrdinalIgnoreCase))
                    {
                        inputService.MouseMiddleDown();
                        inputService.MouseMiddleUp();
                    }
                    else
                    {
                        inputService.LeftClick();
                    }

                    break;

                case MacroActionType.Delay:
                    break;
            }
        }

        private static ushort ParseKey(string parameter)
        {
            return (ushort)Enum.Parse(typeof(Keys), parameter);
        }
    }
}
