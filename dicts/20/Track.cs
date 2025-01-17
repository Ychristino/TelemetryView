using System;
using System.Collections.Generic;

namespace TelemetryViewer.Dicts.f120.Track
{
    public class Track
    {
        private static readonly Dictionary<int, string> TrackNames = new Dictionary<int, string>
        {
            { 0, "Melbourne" },
            { 1, "Paul Ricard" },
            { 2, "Shanghai" },
            { 3, "Sakhir (Bahrain)" },
            { 4, "Catalunya" },
            { 5, "Monaco" },
            { 6, "Montreal" },
            { 7, "Silverstone" },
            { 9, "Hungaroring" },
            { 10, "Spa" },
            { 11, "Monza" },
            { 12, "Singapore" },
            { 13, "Suzuka" },
            { 14, "Abu Dhabi" },
            { 15, "Texas" },
            { 16, "Brazil" },
            { 17, "Austria" },
            { 18, "Sochi" },
            { 19, "Mexico" },
            { 20, "Baku (Azerbaijan)" },
            { 21, "Sakhir Short" },
            { 22, "Silverstone Short" },
            { 23, "Texas Short" },
            { 24, "Suzuka Short" },
            { 25, "Hanoi" },
            { 26, "Zandvoort" }
        };

        public static string GetTrackName(int trackId)
        {
            if (TrackNames.ContainsKey(trackId))
            {
                return TrackNames[trackId];
            }
            else
            {
                return "Unknown Track";
            }
        }
    }
}
