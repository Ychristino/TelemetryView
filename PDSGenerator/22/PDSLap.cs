using System;
using System.Globalization;
using System.IO;
using TelemetryViewer.Packets.f122.Lap; // Alterado para o namespace f122

namespace TelemetryViewer.GeneratePDS.f122.Lap
{
    public class PDSLap : PDSExport<PacketLap>
    {
        public override void ExportPdsHeader(string filePath){
            using (StreamWriter writer = new StreamWriter(filePath, append: true))
            {
                // Escrever o cabeçalho do arquivo CSV
                writer.WriteLine("\n# Lap Data (F122)"); // Alterado para F122
                writer.WriteLine("# Columns: Last Lap Time, Current Lap Time, Sector 1 Time, Sector 2 Time, Lap Distance, " + 
                                 "Total Distance, Safety Car Delta, Car Position, Current Lap Num, Pit Status, Pit Stops, " + 
                                 "Sector, Current Lap Invalid, Penalties, Warnings, Unserved Drive Through Pens, Unserved Stop Go Pens, " +
                                 "Grid Position, Driver Status, Result Status, Pit Lane Timer Active, Pit Lane Time in Lane, " +
                                 "Pit Stop Timer, Pit Stop Should Serve Pen");
            }
        }
        public override void ExportToPds(PacketLap packetData, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath, append: true))
            {
                // Escrever os dados de cada carro
                foreach (var lap in packetData.m_lapData)
                {
                    writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                        "{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20}, {21}",
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

                // Escrever dados de Time Trial
                writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                    "\nTime Trial Data: {0}, {1}",
                    packetData.m_timeTrialPBCarIdx,
                    packetData.m_timeTrialRivalCarIdx
                ));
            }

            Console.WriteLine($"PacketLapData F122 Sucesso: {filePath}");
        }
    }
}
