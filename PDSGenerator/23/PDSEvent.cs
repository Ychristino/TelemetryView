using System;
using System.Globalization;
using System.IO;
using TelemetryViewer.Dicts.f123.Buttons;
using TelemetryViewer.Dicts.f123.Event;
using TelemetryViewer.Dicts.f123.Infringements;
using TelemetryViewer.Dicts.f123.Penalties;
using TelemetryViewer.Packets.f123.Event;

namespace TelemetryViewer.GeneratePDS.f123.Event
{
    public class PDSEvent : PDSExport<PacketEvent>
    {
        public override void ExportPdsHeader(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath, append: true))
            {
                // Escrever o cabeçalho do arquivo CSV
                writer.WriteLine("\n# Event Data (F123)");
                writer.WriteLine("# Columns: Event Type, Vehicle Index, Lap Time (Fastest Lap), Penalty Type, Infringement Type, " +
                                    "Other Vehicle Index, Time, Lap Number, Places Gained, Speed Trap Info, " +
                                    "Start Lights, Flashback Frame Identifier, Flashback Session Time, Button Status");
            }
        }
        public override void ExportToPds(PacketEvent packetData, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath, append: true))
            {
                // Interpretando o tipo de evento
                if (packetData.EventStringCode != null)
                {
                    string eventType = System.Text.Encoding.UTF8.GetString(packetData.EventStringCode);

                    // Verificar o tipo de evento e exportar os dados correspondentes
                    switch (eventType)
                    {
                        case "FastestLap":
                            var fastestLap = packetData.EventDetails.fastestLap;
                            writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                                "FastestLap, {0}, {1:F2}, , , , , , , , , , , ",
                                fastestLap.VehicleIdx, fastestLap.LapTime));
                            break;

                        case "Retirement":
                            var retirement = packetData.EventDetails.retirement;
                            writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                                "Retirement, {0}, , , , , , , , , , , , ",
                                retirement.VehicleIdx));
                            break;

                        case "TeamMateInPits":
                            var teamMateInPits = packetData.EventDetails.teamMateInPits;
                            writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                                "TeamMateInPits, {0}, , , , , , , , , , , , ",
                                teamMateInPits.VehicleIdx));
                            break;

                        case "RaceWinner":
                            var raceWinner = packetData.EventDetails.raceWinner;
                            writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                                "RaceWinner, {0}, , , , , , , , , , , , ",
                                raceWinner.VehicleIdx));
                            break;

                        case "Penalty":
                            var penalty = packetData.EventDetails.penalty;
                            writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                                "Penalty, {0}, , {1}, {2}, {3}, {4}, {5}, , , , ",
                                penalty.VehicleIdx, Penalty.GetPenaltyMeaning(penalty.PenaltyType), Infringement.GetInfringementMeaning(penalty.InfringementType),
                                penalty.OtherVehicleIdx, penalty.Time, penalty.LapNum));
                            break;

                        case "SpeedTrap":
                            var speedTrap = packetData.EventDetails.speedTrap;
                            writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                                "SpeedTrap, {0}, , , , , , , , {1:F2}, {2}, {3}, {4:F2}, {5}, ",
                                speedTrap.VehicleIdx, speedTrap.Speed, speedTrap.IsOverallFastestInSession,
                                speedTrap.IsDriverFastestInSession, speedTrap.FastestSpeedInSession));
                            break;

                        case "StartLights":
                            var startLights = packetData.EventDetails.startLights;
                            writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                                "StartLights, , , , , , , , , , , , {0}, ",
                                startLights.NumLights));
                            break;

                        case "DriveThroughPenaltyServed":
                            var driveThroughPenaltyServed = packetData.EventDetails.driveThroughPenaltyServed;
                            writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                                "DriveThroughPenaltyServed, {0}, , , , , , , , , , , , ",
                                driveThroughPenaltyServed.VehicleIdx));
                            break;

                        case "StopGoPenaltyServed":
                            var stopGoPenaltyServed = packetData.EventDetails.stopGoPenaltyServed;
                            writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                                "StopGoPenaltyServed, {0}, , , , , , , , , , , , ",
                                stopGoPenaltyServed.VehicleIdx));
                            break;

                        case "Flashback":
                            var flashback = packetData.EventDetails.flashback;
                            writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                                "Flashback, , , , , , , , , , , {0}, {1:F2}, ",
                                flashback.FlashbackFrameIdentifier, flashback.FlashbackSessionTime));
                            break;

                        case "Buttons":
                            var buttons = packetData.EventDetails.buttons;
                            writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                                "Buttons, , , , , , , , , , , , {0}, ",
                                Button.GetPressedButtons(buttons.ButtonStatus)));
                            break;

                        case "Overtake":
                            var overtake = packetData.EventDetails.overtake;
                            writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                                "Overtake, {0}, , , , , , , , , , , , ",
                                overtake.OvertakingVehicleIdx));
                            break;

                        default:
                            writer.WriteLine("Unknown event type");
                            break;
                    }
                }
            }

            Console.WriteLine($"PacketEventData F123 Sucesso: {filePath}");
        }
    }
}
