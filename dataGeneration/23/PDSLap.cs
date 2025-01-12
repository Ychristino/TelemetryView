using System;
using System.Globalization;
using System.IO;
using TelemetryViewer.Packets.f123.Lap;

namespace TelemetryViewer.GeneratePDS.f123.Lap
{
    public class PDSLapData : PDSExport<PacketLapData>
    {
        public override void ExportToPds(PacketLapData packetData, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Escrever o cabeçalho do arquivo CSV
                writer.WriteLine("\n# Lap Data (F123)"); // Atualizado para F123
                writer.WriteLine("# Columns: Car Position, Current Lap, Sector, Last Lap Time (ms), Current Lap Time (ms), Sector 1 Time (ms), Sector 1 Time (min), Sector 2 Time (ms), Sector 2 Time (min), Delta to Car in Front (ms), Delta to Race Leader (ms), Lap Distance (m), Total Distance (m), Safety Car Delta (s), Pit Status, Num Pit Stops, Current Lap Invalid, Penalties (s), Total Warnings, Corner Cutting Warnings, Unserved Drive Through Penalties, Unserved Stop Go Penalties, Grid Position, Driver Status, Result Status, Pit Lane Timer Active, Pit Lane Time (ms), Pit Stop Time (ms), Pit Stop Should Serve Penalty");

                // Processar os dados de cada carro e exportar para o CSV
                for (int i = 0; i < packetData.LapData.Length; i++)
                {
                    var lapData = packetData.LapData[i];
                    writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                        "{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20}, {21}, {22}, {23}, {24}, {25}, {26}, {27}",
                        lapData.CarPosition,
                        lapData.CurrentLapNum,
                        lapData.Sector,
                        lapData.LastLapTimeInMS,
                        lapData.CurrentLapTimeInMS,
                        lapData.Sector1TimeInMS,
                        lapData.Sector1TimeMinutes,
                        lapData.Sector2TimeInMS,
                        lapData.Sector2TimeMinutes,
                        lapData.DeltaToCarInFrontInMS,
                        lapData.DeltaToRaceLeaderInMS,
                        lapData.LapDistance,
                        lapData.TotalDistance,
                        lapData.SafetyCarDelta,
                        lapData.PitStatus,
                        lapData.NumPitStops,
                        lapData.CurrentLapInvalid,
                        lapData.Penalties,
                        lapData.TotalWarnings,
                        lapData.CornerCuttingWarnings,
                        lapData.NumUnservedDriveThroughPens,
                        lapData.NumUnservedStopGoPens,
                        lapData.GridPosition,
                        lapData.DriverStatus,
                        lapData.ResultStatus,
                        lapData.PitLaneTimerActive,
                        lapData.PitLaneTimeInLaneInMS,
                        lapData.PitStopTimerInMS,
                        lapData.PitStopShouldServePen));
                }
            }

            Console.WriteLine($"LapData F123 Sucesso: {filePath}");
        }
    }
}
