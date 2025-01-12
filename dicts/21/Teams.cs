using System;
using System.Collections.Generic;

namespace TelemetryViewer.Dicts.f121.Team
{
    public class Team
    {
        private static readonly Dictionary<int, string> TeamNames = new Dictionary<int, string>
        {
            { 0, "Mercedes" },
            { 1, "Ferrari" },
            { 2, "Red Bull Racing" },
            { 3, "Williams" },
            { 4, "Aston Martin" },
            { 5, "Alpine" },
            { 6, "Alpha Tauri" },
            { 7, "Haas" },
            { 8, "McLaren" },
            { 9, "Alfa Romeo" },
            { 42, "ART GP '19" },
            { 43, "Campos '19" },
            { 44, "Carlin '19" },
            { 45, "Sauber Junior Charouz '19" },
            { 46, "Dams '19" },
            { 47, "Uni-Virtuosi '19" },
            { 48, "MP Motorsport '19" },
            { 49, "Prema '19" },
            { 50, "Trident '19" },
            { 51, "Arden '19" },
            { 70, "ART GP '20" },
            { 71, "Campos '20" },
            { 72, "Carlin '20" },
            { 73, "Charouz '20" },
            { 74, "Dams '20" },
            { 75, "Uni-Virtuosi '20" },
            { 76, "MP Motorsport '20" },
            { 77, "Prema '20" },
            { 78, "Trident '20" },
            { 79, "BWT '20" },
            { 80, "Hitech '20" },
            { 85, "Mercedes 2020" },
            { 86, "Ferrari 2020" },
            { 87, "Red Bull 2020" },
            { 88, "Williams 2020" },
            { 89, "Racing Point 2020" },
            { 90, "Renault 2020" },
            { 91, "Alpha Tauri 2020" },
            { 92, "Haas 2020" },
            { 93, "McLaren 2020" },
            { 94, "Alfa Romeo 2020" }
        };

        public static string GetTeamName(int teamId)
        {
            if (TeamNames.ContainsKey(teamId))
            {
                return TeamNames[teamId];
            }
            else
            {
                return "Unknown Team";
            }
        }
    }
}
