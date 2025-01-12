using System;
using System.Collections.Generic;

namespace TelemetryViewer.Dicts.f120.Team
{
    public class Team
    {
        private static readonly Dictionary<int, string> TeamNames = new Dictionary<int, string>
        {
            { 0, "Mercedes" },
            { 20, "McLaren 2008" },
            { 63, "Ferrari 1990" },
            { 1, "Ferrari" },
            { 21, "Red Bull 2010" },
            { 64, "McLaren 2010" },
            { 2, "Red Bull Racing" },
            { 31, "McLaren 1990" },
            { 65, "Ferrari 2010" },
            { 3, "Williams" },
            { 38, "Williams 2003" },
            { 255, "My Team" },
            { 4, "Racing Point" },
            { 39, "Brawn 2009" },
            { 5, "Renault" },
            { 41, "F1 Generic car" },
            { 6, "AlphaTauri" },
            { 42, "ART Grand Prix" },
            { 7, "Haas" },
            { 43, "Campos Racing" },
            { 8, "McLaren" },
            { 44, "Carlin" },
            { 9, "Alfa Romeo" },
            { 45, "Sauber Junior Team by Charouz" },
            { 10, "McLaren 1988" },
            { 46, "DAMS" },
            { 11, "McLaren 1991" },
            { 47, "UNI-Virtuosi" },
            { 12, "Williams 1992" },
            { 48, "MP Motorsport" },
            { 13, "Ferrari 1995" },
            { 49, "PREMA Racing" },
            { 14, "Williams 1996" },
            { 50, "Trident" },
            { 15, "McLaren 1998" },
            { 51, "BWT Arden" },
            { 16, "Ferrari 2002" },
            { 53, "Benetton 1994" },
            { 17, "Ferrari 2004" },
            { 54, "Benetton 1995" },
            { 18, "Renault 2006" },
            { 55, "Ferrari 2000" },
            { 19, "Ferrari 2007" },
            { 56, "Jordan 1991" }
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
