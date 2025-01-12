using System;
using System.Globalization;
using System.IO;
using TelemetryViewer.Packets.f122.Classification;

namespace TelemetryViewer.GeneratePDS.f122.Classification
{
    public class PDSPacketFinalClassificationData : PDSExport<PacketFinalClassificationData>
    {
        public override void ExportToPds(PacketFinalClassificationData packetData, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Escrever o cabeçalho do arquivo CSV
                writer.WriteLine("\n# Final Classification Data (F122)");
                writer.WriteLine("# Columns: Position, Grid Position, Laps Completed, Points, Pit Stops, Result Status, Best Lap Time (ms), " +
                                    "Total Race Time (s), Penalties Time (s), Number of Penalties, Tyre Stints, " +
                                    "Tyre Stints (Visual), Tyre Stints End Laps");

                // Percorrer os dados de classificação dos carros
                for (int i = 0; i < packetData.m_numCars; i++)
                {
                    FinalClassificationData carData = packetData.m_classificationData[i];

                    // Preparar os dados dos pneus (reais, visuais e voltas de término)
                    string tyreStintsActual = string.Join(", ", carData.m_tyreStintsActual);
                    string tyreStintsVisual = string.Join(", ", carData.m_tyreStintsVisual);
                    string tyreStintsEndLaps = string.Join(", ", carData.m_tyreStintsEndLaps);

                    // Escrever os dados do carro no CSV
                    writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                        "{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7:F2}, {8:F2}, {9}, {10}, {11}, {12}",
                        carData.m_position,                // Posição final
                        carData.m_gridPosition,            // Posição de largada
                        carData.m_numLaps,                 // Número de voltas completadas
                        carData.m_points,                  // Número de pontos ganhos
                        carData.m_numPitStops,             // Número de pit stops
                        carData.m_resultStatus,            // Status do resultado
                        carData.m_bestLapTimeInMS,         // Melhor tempo de volta em ms
                        carData.m_totalRaceTime,           // Tempo total da corrida em segundos
                        carData.m_penaltiesTime,           // Tempo total de penalidades em segundos
                        carData.m_numPenalties,            // Número de penalidades
                        tyreStintsActual,                  // Pneus reais usados
                        tyreStintsVisual,                  // Pneus visuais usados
                        tyreStintsEndLaps                  // Voltas de término dos pneus
                    ));
                }
            }

            Console.WriteLine($"PacketFinalClassificationData F122 Sucesso: {filePath}");
        }
    }
}
