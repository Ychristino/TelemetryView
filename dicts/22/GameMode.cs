using System;
using System.Collections.Generic;

namespace TelemetryViewer.Dicts.f122.Mode
{
    public class Mode
    {
        private static readonly Dictionary<int, string> ModeNames = new Dictionary<int, string>
        {
            { 0, "Event Mode" },
            { 3, "Grand Prix" },
            { 5, "Time Trial" },
            { 6, "Splitscreen" },
            { 7, "Online Custom" },
            { 8, "Online League" },
            { 11, "Career Invitational" },
            { 12, "Championship Invitational" },
            { 13, "Championship" },
            { 14, "Online Championship" },
            { 15, "Online Weekly Event" },
            { 19, "Career '22" },
            { 20, "Career '22 Online" },
            { 127, "Benchmark" }
        };

        public static string GetModeName(int modeId)
        {
            if (ModeNames.ContainsKey(modeId))
            {
                return ModeNames[modeId];
            }
            else
            {
                return "Unknown Mode";
            }
        }
    }
}