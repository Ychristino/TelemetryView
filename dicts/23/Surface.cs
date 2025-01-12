using System;
using System.Collections.Generic;

namespace TelemetryViewer.Dicts.f123.Surface
{
    public class Surface
    {
        private static readonly Dictionary<int, string> SurfaceNames = new Dictionary<int, string>
        {
            { 0, "Tarmac" },
            { 1, "Rumble strip" },
            { 2, "Concrete" },
            { 3, "Rock" },
            { 4, "Gravel" },
            { 5, "Mud" },
            { 6, "Sand" },
            { 7, "Grass" },
            { 8, "Water" },
            { 9, "Cobblestone" },
            { 10, "Metal" },
            { 11, "Ridged" }
        };

        public static string GetSurfaceName(int surfaceId)
        {
            if (SurfaceNames.ContainsKey(surfaceId))
            {
                return SurfaceNames[surfaceId];
            }
            else
            {
                return "Unknown Surface";
            }
        }
    }
}
