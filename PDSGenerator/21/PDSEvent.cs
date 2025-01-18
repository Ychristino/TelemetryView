using System;
using System.Globalization;
using System.IO;
using System.Text;
using TelemetryViewer.Dicts.f121.Infringements;
using TelemetryViewer.Dicts.f121.Penalties;
using TelemetryViewer.Packets.f121.Event;

namespace TelemetryViewer.GeneratePDS.f121.Event
{
    public class PDSEvent : PDSExport<PacketEvent>
    {
        public override void ExportPdsHeader(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath, append: true))
            {
                // Escrever o cabeçalho do arquivo CSV
                writer.WriteLine("\n# Event Data (F121)");
                writer.WriteLine("# Columns: Event Type, Vehicle Index, Event Details (specific to event type)");
            }
        }
        public override void ExportToPds(PacketEvent packetData, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath, append: true))
            {
                // Escrever os dados do evento
                writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                    "{0}, {1}, {2}",
                    packetData.m_eventStringCode != null ? Encoding.ASCII.GetString(packetData.m_eventStringCode) : "N/A", 
                    packetData.m_eventDetails));

                // Dependendo do tipo de evento, escreva detalhes adicionais
                switch (packetData.m_eventDetails.eventType)
                {
                    case EventType.FastestLap:
                        writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                            "FastestLap Event: Vehicle Index {0}, Lap Time: {1}",
                            packetData.m_eventDetails.fastestLap.vehicleIdx,
                            packetData.m_eventDetails.fastestLap.lapTime));
                        break;
                    case EventType.Retirement:
                        writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                            "Retirement Event: Vehicle Index {0}",
                            packetData.m_eventDetails.retirement.vehicleIdx));
                        break;
                    case EventType.TeamMateInPits:
                        writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                            "TeamMateInPits Event: Vehicle Index {0}",
                            packetData.m_eventDetails.teamMateInPits.vehicleIdx));
                        break;
                    case EventType.RaceWinner:
                        writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                            "RaceWinner Event: Vehicle Index {0}",
                            packetData.m_eventDetails.raceWinner.vehicleIdx));
                        break;
                    case EventType.Penalty:
                        writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                            "Penalty Event: Vehicle Index {0}, Penalty Type: {1}, Infringement Type: {2}, Time: {3}s, Lap: {4}, Places Gained: {5}",
                            packetData.m_eventDetails.penalty.vehicleIdx,
                            Penalty.GetPenaltyMeaning(packetData.m_eventDetails.penalty.penaltyType),
                            Infringement.GetInfringementMeaning(packetData.m_eventDetails.penalty.infringementType),
                            packetData.m_eventDetails.penalty.time,
                            packetData.m_eventDetails.penalty.lapNum,
                            packetData.m_eventDetails.penalty.placesGained));
                        break;
                    case EventType.SpeedTrap:
                        writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                            "SpeedTrap Event: Vehicle Index {0}, Speed: {1} km/h, Overall Fastest: {2}, Driver Fastest: {3}",
                            packetData.m_eventDetails.speedTrap.vehicleIdx,
                            packetData.m_eventDetails.speedTrap.speed,
                            packetData.m_eventDetails.speedTrap.overallFastestInSession == 1 ? "Yes" : "No",
                            packetData.m_eventDetails.speedTrap.driverFastestInSession == 1 ? "Yes" : "No"));
                        break;
                }
            }

            Console.WriteLine($"PacketEventData F121 Sucesso: {filePath}");
        }
    }
}
