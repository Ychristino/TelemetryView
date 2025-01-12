using System;
using System.Globalization;
using System.IO;
using TelemetryViewer.Packets.f121.Lap;

namespace TelemetryViewer.GeneratePDS.f121.Lap
{
    public class PDSLapData : PDSExport<PacketLapData>
    {
        public override void ExportToPds(PacketLapData packetData, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Escrever o cabeçalho do arquivo CSV
                writer.WriteLine("\n# Lap Data (F121)");
                writer.WriteLine("# Columns: Last Lap Time (ms), Current Lap Time (ms), Sector 1 Time (ms), Sector 2 Time (ms), " +
                                 "Lap Distance (m), Total Distance (m), Safety Car Delta (s), Car Position, Current Lap, " +
                                 "Pit Status, Num Pit Stops, Sector, Invalid Lap, Penalties (s), Warnings, Unserved Drive-Through Penalties, " +
                                 "Unserved Stop-Go Penalties, Grid Position, Driver Status, Result Status, Pit Lane Active, " +
                                 "Pit Lane Time (ms), Pit Stop Time (ms), Pit Stop Serve Penalty");

                // Escrever os dados de cada carro
                foreach (var lap in packetData.m_lapData)
                {
                    writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                        "{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20}, {21}, {22}",
                        lap.m_lastLapTimeInMS,
                        lap.m_currentLapTimeInMS,
                        lap.m_sector1TimeInMS,
                        lap.m_sector2TimeInMS,
                        lap.m_lapDistance,
                        lap.m_totalDistance,
                        lap.m_safetyCarDelta,
                        lap.m_carPosition,
                        lap.m_currentLapNum,
                        lap.m_pitStatus,
                        lap.m_numPitStops,
                        lap.m_sector,
                        lap.m_currentLapInvalid,
                        lap.m_penalties,
                        lap.m_warnings,
                        lap.m_numUnservedDriveThroughPens,
                        lap.m_numUnservedStopGoPens,
                        lap.m_gridPosition,
                        lap.m_driverStatus,
                        lap.m_resultStatus,
                        lap.m_pitLaneTimerActive,
                        lap.m_pitLaneTimeInLaneInMS,
                        lap.m_pitStopTimerInMS,
                        lap.m_pitStopShouldServePen
                    ));
                }
            }

            Console.WriteLine($"LapData F121 Exportado com sucesso: {filePath}");
        }
    }
}
