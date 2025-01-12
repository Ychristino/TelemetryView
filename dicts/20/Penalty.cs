using System;
using System.Collections.Generic;

namespace TelemetryViewer.Dicts.f120.Penalties
{
    public class Penalty
    {
        private static readonly Dictionary<int, string> PenaltyMeanings = new Dictionary<int, string>
        {
            { 0, "Drive through" },
            { 1, "Stop Go" },
            { 2, "Grid penalty" },
            { 3, "Penalty reminder" },
            { 4, "Time penalty" },
            { 5, "Warning" },
            { 6, "Disqualified" },
            { 7, "Removed from formation lap" },
            { 8, "Parked too long timer" },
            { 9, "Tyre regulations" },
            { 10, "This lap invalidated" },
            { 11, "This and next lap invalidated" },
            { 12, "This lap invalidated without reason" },
            { 13, "This and next lap invalidated without reason" },
            { 14, "This lap invalidated" },
            { 15, "This and previous lap invalidated without reason" },
            { 16, "Retired" },
            { 17, "Black flag timer" }
        };

        public static string GetPenaltyMeaning(int penaltyId)
        {
            if (PenaltyMeanings.ContainsKey(penaltyId))
            {
                return PenaltyMeanings[penaltyId];
            }
            else
            {
                return "Unknown Penalty";
            }
        }
    }
}
