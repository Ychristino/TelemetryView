using System;
using System.Collections.Generic;

namespace TelemetryViewer.Dicts.f122.Buttons
{
    public class Button
    {
        private static readonly Dictionary<int, string> ButtonNames = new Dictionary<int, string>
        {
            { 1, "Cross or A" },
            { 2, "Triangle or Y" },
            { 4, "Circle or B" },
            { 8, "Square or X" },
            { 16, "D-pad Left" },
            { 32, "D-pad Right" },
            { 64, "D-pad Up" },
            { 128, "D-pad Down" },
            { 256, "Options or Menu" },
            { 512, "L1 or LB" },
            { 1024, "R1 or RB" },
            { 2048, "L2 or LT" },
            { 4096, "R2 or RT" },
            { 8192, "Left Stick Click" },
            { 16384, "Right Stick Click" },
            { 32768, "Right Stick Left" },
            { 65536, "Right Stick Right" },
            { 131072, "Right Stick Up" },
            { 262144, "Right Stick Down" },
            { 524288, "Special" },
            { 1048576, "UDP Action 1" },
            { 2097152, "UDP Action 2" },
            { 4194304, "UDP Action 3" },
            { 8388608, "UDP Action 4" },
            { 16777216, "UDP Action 5" },
            { 33554432, "UDP Action 6" },
            { 67108864, "UDP Action 7" },
            { 134217728, "UDP Action 8" },
            { 268435456, "UDP Action 9" },
            { 536870912, "UDP Action 10" },
            { 1073741824, "UDP Action 11" },
            { -2147483648, "UDP Action 12" } // Valor negativo para representar o último valor (o maior valor de uint)
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
