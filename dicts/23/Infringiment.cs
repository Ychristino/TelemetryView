using System;
using System.Collections.Generic;

namespace TelemetryViewer.Dicts.f123.Infringements
{
    public class Infringement
    {
        private static readonly Dictionary<int, string> InfringementMeanings = new Dictionary<int, string>
        {
            { 0, "Blocking by slow driving" },
            { 1, "Blocking by wrong way driving" },
            { 2, "Reversing off the start line" },
            { 3, "Big Collision" },
            { 4, "Small Collision" },
            { 5, "Collision failed to hand back position single" },
            { 6, "Collision failed to hand back position multiple" },
            { 7, "Corner cutting gained time" },
            { 8, "Corner cutting overtake single" },
            { 9, "Corner cutting overtake multiple" },
            { 10, "Crossed pit exit lane" },
            { 11, "Ignoring blue flags" },
            { 12, "Ignoring yellow flags" },
            { 13, "Ignoring drive through" },
            { 14, "Too many drive throughs" },
            { 15, "Drive through reminder serve within n laps" },
            { 16, "Drive through reminder serve this lap" },
            { 17, "Pit lane speeding" },
            { 18, "Parked for too long" },
            { 19, "Ignoring tyre regulations" },
            { 20, "Too many penalties" },
            { 21, "Multiple warnings" },
            { 22, "Approaching disqualification" },
            { 23, "Tyre regulations select single" },
            { 24, "Tyre regulations select multiple" },
            { 25, "Lap invalidated corner cutting" },
            { 26, "Lap invalidated running wide" },
            { 27, "Corner cutting ran wide gained time minor" },
            { 28, "Corner cutting ran wide gained time significant" },
            { 29, "Corner cutting ran wide gained time extreme" },
            { 30, "Lap invalidated wall riding" },
            { 31, "Lap invalidated flashback used" },
            { 32, "Lap invalidated reset to track" },
            { 33, "Blocking the pitlane" },
            { 34, "Jump start" },
            { 35, "Safety car to car collision" },
            { 36, "Safety car illegal overtake" },
            { 37, "Safety car exceeding allowed pace" },
            { 38, "Virtual safety car exceeding allowed pace" },
            { 39, "Formation lap below allowed speed" },
            { 40, "Formation lap parking" },
            { 41, "Retired mechanical failure" },
            { 42, "Retired terminally damaged" },
            { 43, "Safety car falling too far back" },
            { 44, "Black flag timer" },
            { 45, "Unserved stop go penalty" },
            { 46, "Unserved drive through penalty" },
            { 47, "Engine component change" },
            { 48, "Gearbox change" },
            { 49, "Parc Fermé change" },
            { 50, "League grid penalty" },
            { 51, "Retry penalty" },
            { 52, "Illegal time gain" },
            { 53, "Mandatory pitstop" },
            { 54, "Attribute assigned" }
        };

        public static string GetInfringementMeaning(int infringementId)
        {
            if (InfringementMeanings.ContainsKey(infringementId))
            {
                return InfringementMeanings[infringementId];
            }
            else
            {
                return "Unknown Infringement";
            }
        }
    }
}
