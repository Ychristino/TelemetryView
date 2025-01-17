using System;
using System.Collections.Generic;

namespace TelemetryViewer.Dicts.f120.Buttons
{
    public class Button
    {
        private static readonly Dictionary<int, string> ButtonNames = new Dictionary<int, string>
        {
            { 0x0001, "Cross or A" },
            { 0x0002, "Triangle or Y" },
            { 0x0004, "Circle or B" },
            { 0x0008, "Square or X" },
            { 0x0010, "D-pad Left" },
            { 0x0020, "D-pad Right" },
            { 0x0040, "D-pad Up" },
            { 0x0080, "D-pad Down" },
            { 0x0100, "Options or Menu" },
            { 0x0200, "L1 or LB" },
            { 0x0400, "R1 or RB" },
            { 0x0800, "L2 or LT" },
            { 0x1000, "R2 or RT" },
            { 0x2000, "Left Stick Click" },
            { 0x4000, "Right Stick Click" }
        };

        public static List<string> GetPressedButtons(uint buttonFlags)
        {
            var pressedButtons = new List<string>();

            foreach (var button in ButtonNames)
            {
                if ((buttonFlags & button.Key) == button.Key)
                {
                    pressedButtons.Add(button.Value);
                }
            }

            return pressedButtons;
        }
    }
}
