using System;
using System.Collections.Generic;

namespace TelemetryViewer.Dicts.f122.Team
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
            { 85, "Mercedes 2020" },
            { 86, "Ferrari 2020" },
            { 87, "Red Bull 2020" },
            { 88, "Williams 2020" },
            { 89, "Racing Point 2020" },
            { 90, "Renault 2020" },
            { 91, "Alpha Tauri 2020" },
            { 92, "Haas 2020" },
            { 93, "McLaren 2020" },
            { 94, "Alfa Romeo 2020" },
            { 95, "Aston Martin DB11 V12" },
            { 96, "Aston Martin Vantage F1 Edition" },
            { 97, "Aston Martin Vantage Safety Car" },
            { 98, "Ferrari F8 Tributo" },
            { 99, "Ferrari Roma" },
            { 100, "McLaren 720S" },
            { 101, "McLaren Artura" },
            { 102, "Mercedes AMG GT Black Series Safety Car" },
            { 103, "Mercedes AMG GTR Pro" },
            { 104, "F1 Custom Team" },
            { 106, "Prema ‘21" },
            { 107, "Uni-Virtuosi ‘21" },
            { 108, "Carlin ‘21" },
            { 109, "Hitech ‘21" },
            { 110, "Art GP ‘21" },
            { 111, "MP Motorsport ‘21" },
            { 112, "Charouz ‘21" },
            { 113, "Dams ‘21" },
            { 114, "Campos ‘21" },
            { 115, "BWT ‘21" },
            { 116, "Trident ‘21" },
            { 117, "Mercedes AMG GT Black Series" },
            { 118, "Mercedes ‘22" },
            { 119, "Ferrari ‘22" },
            { 120, "Red Bull Racing ‘22" },
            { 121, "Williams ‘22" },
            { 122, "Aston Martin ‘22" },
            { 123, "Alpine ‘22" },
            { 124, "Alpha Tauri ‘22" },
            { 125, "Haas ‘22" },
            { 126, "McLaren ‘22" },
            { 127, "Alfa Romeo ‘22" },
            { 128, "Konnersport ‘22" },
            { 129, "Konnersport" },
            { 130, "Prema ‘22" },
            { 131, "Virtuosi ‘22" },
            { 132, "Carlin ‘22" },
            { 133, "MP Motorsport ‘22" },
            { 134, "Charouz ‘22" },
            { 135, "Dams ‘22" },
            { 136, "Campos ‘22" },
            { 137, "Van Amersfoort Racing ‘22" },
            { 138, "Trident ‘22" },
            { 139, "Hitech ‘22" }
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
