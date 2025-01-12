using System;
using System.Globalization;
using System.IO;
using TelemetryViewer.Packets.f120.FinalClassification;

namespace TelemetryViewer.GeneratePDS.f120.FinalClassification
{
    public class PDSFinalClassification : PDSExport<PacketFinalClassificationData> // Herda de PDSExport<PacketFinalClassificationData>
    {
        public override void ExportToPds(PacketFinalClassificationData classificationData, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Escrever a seção de classificação final
                writer.WriteLine("# Final Classification Data");
                writer.WriteLine("# Columns: Position, Grid Position, Points, Best Lap Time, Total Race Time, Penalties, Tyre Stints");

                // Iterar por todos os carros na classificação final
                for (int i = 0; i < classificationData.m_numCars; i++)
                {
                    var carData = classificationData.m_classificationData[i];

                    // Escrever os dados de cada carro
                    writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                        "{0}, {1}, {2}, {3:F3}, {4:F2}, {5}, Tyre Stints: {6}",
                        carData.m_position,
                        carData.m_gridPosition,
                        carData.m_points,
                        carData.m_bestLapTime,
                        carData.m_totalRaceTime,
                        carData.m_numPenalties,
                        string.Join(", ", carData.m_tyreStintsActual)
                    ));
                }
            }

            Console.WriteLine($"Dados da classificação final exportados para: {filePath}");
        }
    }
}
