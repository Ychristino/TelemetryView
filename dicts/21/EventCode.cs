using System;
using System.Collections.Generic;

namespace TelemetryViewer.Dicts.f121.Event
{
    public class EventCode
    {
        // Dictionary to store event codes and their descriptions
        private static readonly Dictionary<string, string> EventDescriptions = new Dictionary<string, string>
        {
            { "SSTA", "Session Started" },
            { "SEND", "Session Ended" },
            { "FTLP", "Fastest Lap" },
            { "RTMT", "Retirement" },
            { "DRSE", "DRS enabled" },
            { "DRSD", "DRS disabled" },
            { "TMPT", "Team mate in pits" },
            { "CHQF", "Chequered flag" },
            { "RCWN", "Race Winner" },
            { "PENA", "Penalty issued" },
            { "SPTP", "Speed trap triggered" },
            { "STLG", "Start lights" },
            { "LGOT", "Lights out" },
            { "DTSV", "Drive through penalty served" },
            { "SGSV", "Stop go penalty served" },
            { "FLBK", "Flashback activated" },
            { "BUTN", "Button status changed" }
        };

        // Method to get the event description based on event code
        public static string GetEventDescription(string eventCode)
        {
            if (EventDescriptions.ContainsKey(eventCode))
            {
                return EventDescriptions[eventCode];
            }
            else
            {
                return "Unknown Event Code";  // Return a default message if the code is not found
            }
        }
    }
}
