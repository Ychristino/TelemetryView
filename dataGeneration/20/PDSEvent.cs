using System;
using System.Globalization;
using System.IO;
using TelemetryViewer.Packets.f120.Event;

namespace TelemetryViewer.GeneratePDS.f120.Event
{
    public class PDSCarTelemetry : PDSExport<PacketEventData> // Herda de PDSExport<PacketEventData>
    {
        public override void ExportToPds(PacketEventData eventData, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Escrever a seção de eventos
                writer.WriteLine("# Event Data");
                writer.WriteLine("# Columns: Event Type, Event String Code, Event Details");

                // Obter o código do evento como string
                string eventCode = System.Text.Encoding.ASCII.GetString(eventData.m_eventStringCode);

                // Determinar o tipo de evento e seus detalhes
                switch (eventData.m_eventDetails.eventType)
                {
                    case EventType.FastestLap:
                        writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                            "{0}, {1}, VehicleIdx: {2}, LapTime: {3:F3} seconds",
                            "FastestLap",
                            eventCode,
                            eventData.m_eventDetails.fastestLap.vehicleIdx,
                            eventData.m_eventDetails.fastestLap.lapTime));
                        break;

                    case EventType.Retirement:
                        writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                            "{0}, {1}, VehicleIdx: {2}",
                            "Retirement",
                            eventCode,
                            eventData.m_eventDetails.retirement.vehicleIdx));
                        break;

                    case EventType.TeamMateInPits:
                        writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                            "{0}, {1}, VehicleIdx: {2}",
                            "TeamMateInPits",
                            eventCode,
                            eventData.m_eventDetails.teamMateInPits.vehicleIdx));
                        break;

                    case EventType.RaceWinner:
                        writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                            "{0}, {1}, VehicleIdx: {2}",
                            "RaceWinner",
                            eventCode,
                            eventData.m_eventDetails.raceWinner.vehicleIdx));
                        break;

                    case EventType.Penalty:
                        writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                            "{0}, {1}, PenaltyType: {2}, InfringementType: {3}, VehicleIdx: {4}, OtherVehicleIdx: {5}, " +
                            "Time: {6}, LapNum: {7}, PlacesGained: {8}",
                            "Penalty",
                            eventCode,
                            eventData.m_eventDetails.penalty.penaltyType,
                            eventData.m_eventDetails.penalty.infringementType,
                            eventData.m_eventDetails.penalty.vehicleIdx,
                            eventData.m_eventDetails.penalty.otherVehicleIdx,
                            eventData.m_eventDetails.penalty.time,
                            eventData.m_eventDetails.penalty.lapNum,
                            eventData.m_eventDetails.penalty.placesGained));
                        break;

                    case EventType.SpeedTrap:
                        writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                            "{0}, {1}, VehicleIdx: {2}, Speed: {3:F2} km/h",
                            "SpeedTrap",
                            eventCode,
                            eventData.m_eventDetails.speedTrap.vehicleIdx,
                            eventData.m_eventDetails.speedTrap.speed));
                        break;

                    default:
                        writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                            "Unknown, {0}, Details not available", eventCode));
                        break;
                }
            }

            Console.WriteLine($"Dados do evento exportados para: {filePath}");
        }
    }
}
