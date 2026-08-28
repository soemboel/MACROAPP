namespace MacroApp.Models
{
    public enum MacroActionType
    {
        KeyDown,
        KeyUp,
        KeyPress,
        MouseMove,
        MouseLeftDown,
        MouseLeftUp,
        MouseRightDown,
        MouseRightUp,
        MouseMiddleDown,
        MouseMiddleUp,
        MouseWheel,
        MouseClick,
        Delay
    }

    public class MacroAction
    {
        public MacroActionType Type { get; set; }

        public string Parameter { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public int Delay { get; set; }
    }
}
