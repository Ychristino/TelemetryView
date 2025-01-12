using System;
using System.Globalization;
using System.IO;
using TelemetryViewer.Packets.f121.FinalClassification;

namespace TelemetryViewer.GeneratePDS.f121.FinalClassification
{
    public class PDSFinalClassificationData : PDSExport<PacketFinalClassificationData>
    {
        public override void ExportToPds(PacketFinalClassificationData packetData, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Escrever o cabeçalho do arquivo CSV
                writer.WriteLine("\n# Final Classification Data (F121)");
                writer.WriteLine("# Columns: Position, Grid Position, Points, Laps, Pit Stops, Result Status, Best Lap Time, Total Race Time, Penalties Time, Tyre Stints");

                // Iterar sobre todos os dados de classificação final e exportá-los para o CSV
                for (int i = 0; i < packetData.m_numCars; i++)
                {
                    var classification = packetData.m_classificationData[i];

                    // Escrever os dados para o arquivo CSV
                    writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                        "{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}",
                        classification.m_position,
                        classification.m_gridPosition,
                        classification.m_points,
                        classification.m_numLaps,
                        classification.m_numPitStops,
                        classification.m_resultStatus,
                        classification.m_bestLapTime,
                        classification.m_totalRaceTime,
                        classification.m_penaltiesTime,
                        GetTyreStints(classification.m_tyreStintsActual)
                    ));
                }
            }

            Console.WriteLine($"PacketFinalClassificationData F121 Sucesso: {filePath}");
        }

        private string GetTyreStints(byte[] tyreStints)
        {
            return string.Join(",", tyreStints);
        }
    }
}
