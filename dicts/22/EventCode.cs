using System;
using System.Collections.Generic;

namespace TelemetryViewer.Dicts.f122.Event
{
    public class EventCode
    {
        // Dicionário com os códigos de evento e suas descrições correspondentes
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
            { "BUTN", "Button status changed" },
            { "RDFL", "Red flag shown" }, // Novo evento: Bandeira vermelha
            { "OVTK", "Overtake occurred" } // Novo evento: Ultrapassagem ocorrida
        };

        // Método para obter a descrição de um código de evento
        public static string GetEventDescription(string eventCode)
        {
            if (EventDescriptions.ContainsKey(eventCode))
            {
                return EventDescriptions[eventCode];
            }
            else
            {
                return "Unknown Event Code"; // Retorna uma mensagem padrão se o código não for encontrado
            }
        }
    }
}
