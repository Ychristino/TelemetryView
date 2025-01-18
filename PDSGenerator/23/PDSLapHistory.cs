using System;
using System.Globalization;
using System.IO;
using TelemetryViewer.Packets.f123.SessionHistory;

namespace TelemetryViewer.GeneratePDS.f123.LapHistory
{
    public class PDSLapHistory : PDSExport<PacketSessionHistory>
    {
        public override void ExportPdsHeader(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath, append: true))
            {
                // Escrever o cabeçalho do arquivo CSV
                writer.WriteLine("\n# Session History Data (F123)"); // Atualizado para F123
                writer.WriteLine("# Columns: Car Index, Lap Number, Lap Time (ms), Sector 1 Time (ms), Sector 1 Time (min), Sector 2 Time (ms), Sector 2 Time (min), Sector 3 Time (ms), Sector 3 Time (min), Lap Valid Flags, Tyre Stints Data (End Lap, Actual Tyre Compound, Visual Tyre Compound), Best Lap Time Lap, Best Sector 1 Lap, Best Sector 2 Lap, Best Sector 3 Lap");
            }
        }
        public override void ExportToPds(PacketSessionHistory packetData, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath, append: true))
            {

                // Processar os dados de volta (LapHistoryData)
                for (int i = 0; i < packetData.m_lapHistoryData.Length; i++)
                {
                    var lapData = packetData.m_lapHistoryData[i];
                    writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                        "{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}",
                        packetData.m_carIdx,
                        i + 1, // Lap number, assuming the lap starts from 1
                        lapData.m_lapTimeInMS,
                        lapData.m_sector1TimeInMS,
                        lapData.m_sector1TimeMinutes,
                        lapData.m_sector2TimeInMS,
                        lapData.m_sector2TimeMinutes,
                        lapData.m_sector3TimeInMS,
                        lapData.m_sector3TimeMinutes,
                        lapData.m_lapValidBitFlags,
                        string.Join(" | ", ExportTyreStints(packetData.m_tyreStintsHistoryData)), // Export tyre stints as a string
                        packetData.m_bestLapTimeLapNum,
                        packetData.m_bestSector1LapNum,
                        packetData.m_bestSector2LapNum,
                        packetData.m_bestSector3LapNum
                    ));
                }
            }

            Console.WriteLine($"SessionHistoryData F123 Sucesso: {filePath}");
        }

        // Função auxiliar para exportar os dados dos estágios de pneus
        private string ExportTyreStints(TyreStintHistoryData[] tyreStintsHistory)
        {
            var tyreStintStrings = new string[tyreStintsHistory.Length];
            for (int i = 0; i < tyreStintsHistory.Length; i++)
            {
                var stint = tyreStintsHistory[i];
                tyreStintStrings[i] = $"{stint.m_endLap} | {stint.m_tyreActualCompound} | {stint.m_tyreVisualCompound}";
            }
            return string.Join(" ; ", tyreStintStrings);
        }
    }
}
