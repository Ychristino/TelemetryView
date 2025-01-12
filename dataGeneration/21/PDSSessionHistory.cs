using System;
using System.Globalization;
using System.IO;
using System.Text;
using TelemetryViewer.Packets.f121.SessionHistory;

namespace TelemetryViewer.GeneratePDS.f121.SessionHistory
{
    public class PDSSessionHistory : PDSExport<PacketSessionHistoryData>
    {
        public override void ExportToPds(PacketSessionHistoryData packetData, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Escrever o cabeçalho do arquivo CSV
                writer.WriteLine("\n# Session History Data (F121)");
                writer.WriteLine("# Columns: Lap Number, Lap Time (ms), Sector 1 Time (ms), Sector 2 Time (ms), Sector 3 Time (ms), Lap Valid Flags");

                // Escrever os dados das voltas
                for (int i = 0; i < packetData.m_numLaps; i++)
                {
                    var lapData = packetData.m_lapHistoryData[i];
                    writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                        "{0}, {1}, {2}, {3}, {4}, {5}",
                        i + 1, // Número da volta (1-based index)
                        lapData.m_lapTimeInMS,
                        lapData.m_sector1TimeInMS,
                        lapData.m_sector2TimeInMS,
                        lapData.m_sector3TimeInMS,
                        lapData.m_lapValidBitFlags
                    ));
                }

                // Escrever os dados de stints de pneus
                writer.WriteLine("# Tyre Stint History");
                for (int i = 0; i < packetData.m_numTyreStints; i++)
                {
                    var tyreStintData = packetData.m_tyreStintsHistoryData[i];
                    writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                        "{0}, {1}, {2}",
                        tyreStintData.m_endLap,
                        tyreStintData.m_tyreActualCompound,
                        tyreStintData.m_tyreVisualCompound
                    ));
                }
            }

            Console.WriteLine($"Session History Data F121 Exportado com sucesso: {filePath}");
        }
    }
}
