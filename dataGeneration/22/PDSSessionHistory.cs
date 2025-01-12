using System;
using System.Globalization;
using System.IO;
using TelemetryViewer.Packets.f122.SessionHistory; // Alterado para o namespace f122.SessionHistory

namespace TelemetryViewer.GeneratePDS.f122.SessionHistory
{
    public class PDSLapHistoryData : PDSExport<PacketSessionHistoryData>
    {
        public override void ExportToPds(PacketSessionHistoryData packetData, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Escrever o cabeçalho do arquivo CSV
                writer.WriteLine("\n# Session History Data (F122)"); // Alterado para F122
                writer.WriteLine("# Columns: Car Index, Num Laps, Num Tyre Stints, Best Lap Time Lap Num, Best Sector 1 Lap Num, " +
                                 "Best Sector 2 Lap Num, Best Sector 3 Lap Num, Lap Time (ms), Sector 1 Time (ms), Sector 2 Time (ms), " +
                                 "Sector 3 Time (ms), Lap Valid Bit Flags, End Lap, Tyre Actual Compound, Tyre Visual Compound");

                // Escrever os dados das voltas no arquivo CSV
                for (int i = 0; i < packetData.m_numLaps; i++)
                {
                    LapHistoryData lapData = packetData.m_lapHistoryData[i];
                    writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                        "{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}",
                        packetData.m_carIdx,
                        packetData.m_numLaps,
                        packetData.m_numTyreStints,
                        packetData.m_bestLapTimeLapNum,
                        packetData.m_bestSector1LapNum,
                        packetData.m_bestSector2LapNum,
                        packetData.m_bestSector3LapNum,
                        lapData.m_lapTimeInMS,
                        lapData.m_sector1TimeInMS,
                        lapData.m_sector2TimeInMS,
                        lapData.m_sector3TimeInMS,
                        lapData.m_lapValidBitFlags
                    ));
                }

                // Escrever os dados dos stints de pneus no arquivo CSV
                for (int i = 0; i < packetData.m_numTyreStints; i++)
                {
                    TyreStintHistoryData tyreStintData = packetData.m_tyreStintsHistoryData[i];
                    writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                        "{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}",
                        packetData.m_carIdx,
                        packetData.m_numLaps,
                        packetData.m_numTyreStints,
                        packetData.m_bestLapTimeLapNum,
                        packetData.m_bestSector1LapNum,
                        packetData.m_bestSector2LapNum,
                        packetData.m_bestSector3LapNum,
                        tyreStintData.m_endLap,
                        tyreStintData.m_tyreActualCompound,
                        tyreStintData.m_tyreVisualCompound
                    ));
                }
            }

            Console.WriteLine($"PacketSessionHistoryData F122 Sucesso: {filePath}");
        }
    }
}
