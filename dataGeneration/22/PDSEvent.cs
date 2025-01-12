using System;
using System.Globalization;
using System.IO;
using TelemetryViewer.Packets.f122.Event;

namespace TelemetryViewer.GeneratePDS.f122.Event
{
    public class PDSPacketEventData : PDSExport<PacketEventData>
    {
        public override void ExportToPds(PacketEventData packetData, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Escrever o cabeçalho do arquivo CSV
                writer.WriteLine("\n# Event Data (F122)");
                writer.WriteLine("# Columns: Event Type, Vehicle Index, Lap Time (Fastest Lap), Penalty Type, Infringement Type, " +
                                    "Other Vehicle Index, Time, Lap Number, Places Gained, Speed Trap Info, " +
                                    "Start Lights, Flashback Frame Identifier, Flashback Session Time, Button Status");

                // Interpretando o tipo de evento
                if (packetData.m_eventStringCode != null)
                {
                    string eventType = System.Text.Encoding.UTF8.GetString(packetData.m_eventStringCode);

                    // Verificar o tipo de evento e exportar os dados correspondentes
                    switch (eventType)
                    {
                        case "FastestLap":
                            var fastestLap = packetData.m_eventDetails.fastestLap;
                            writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                                "FastestLap, {0}, {1:F2}, , , , , , , , , , , ",
                                fastestLap.vehicleIdx, fastestLap.lapTime));
                            break;

                        case "Retirement":
                            var retirement = packetData.m_eventDetails.retirement;
                            writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                                "Retirement, {0}, , , , , , , , , , , , ",
                                retirement.vehicleIdx));
                            break;

                        case "TeamMateInPits":
                            var teamMateInPits = packetData.m_eventDetails.teamMateInPits;
                            writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                                "TeamMateInPits, {0}, , , , , , , , , , , , ",
                                teamMateInPits.vehicleIdx));
                            break;

                        case "RaceWinner":
                            var raceWinner = packetData.m_eventDetails.raceWinner;
                            writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                                "RaceWinner, {0}, , , , , , , , , , , , ",
                                raceWinner.vehicleIdx));
                            break;

                        case "Penalty":
                            var penalty = packetData.m_eventDetails.penalty;
                            writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                                "Penalty, {0}, , {1}, {2}, {3}, {4}, {5}, , , , ",
                                penalty.vehicleIdx, penalty.penaltyType, penalty.infringementType,
                                penalty.otherVehicleIdx, penalty.time, penalty.lapNum));
                            break;

                        case "SpeedTrap":
                            var speedTrap = packetData.m_eventDetails.speedTrap;
                            writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                                "SpeedTrap, {0}, , , , , , , , {1:F2}, {2}, {3}, {4:F2}, {5}, ",
                                speedTrap.vehicleIdx, speedTrap.speed, speedTrap.isOverallFastestInSession,
                                speedTrap.isDriverFastestInSession, speedTrap.fastestSpeedInSession));
                            break;

                        case "StartLights":
                            var startLights = packetData.m_eventDetails.startLights;
                            writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                                "StartLights, , , , , , , , , , , , {0}, ",
                                startLights.numLights));
                            break;

                        case "DriveThroughPenaltyServed":
                            var driveThroughPenaltyServed = packetData.m_eventDetails.driveThroughPenaltyServed;
                            writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                                "DriveThroughPenaltyServed, {0}, , , , , , , , , , , , ",
                                driveThroughPenaltyServed.vehicleIdx));
                            break;

                        case "StopGoPenaltyServed":
                            var stopGoPenaltyServed = packetData.m_eventDetails.stopGoPenaltyServed;
                            writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                                "StopGoPenaltyServed, {0}, , , , , , , , , , , , ",
                                stopGoPenaltyServed.vehicleIdx));
                            break;

                        case "Flashback":
                            var flashback = packetData.m_eventDetails.flashback;
                            writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                                "Flashback, , , , , , , , , , , {0}, {1:F2}, ",
                                flashback.flashbackFrameIdentifier, flashback.flashbackSessionTime));
                            break;

                        case "Buttons":
                            var buttons = packetData.m_eventDetails.buttons;
                            writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                                "Buttons, , , , , , , , , , , , {0}, ",
                                buttons.m_buttonStatus));
                            break;

                        default:
                            writer.WriteLine("Unknown event type");
                            break;
                    }
                }
            }

            Console.WriteLine($"PacketEventData F122 Sucesso: {filePath}");
        }
    }
}
