using System;
using System.Globalization;
using System.IO;
using TelemetryViewer.Packets.f123.Classification; // Alterado para o namespace f123.Classification

namespace TelemetryViewer.GeneratePDS.f123.Classification
{
    public class PDSPacketFinalClassificationData : PDSExport<PacketFinalClassificationData>
    {
        public override void ExportToPds(PacketFinalClassificationData packetData, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Escrever o cabeçalho do arquivo CSV
                writer.WriteLine("\n# Final Classification Data (F123)"); // Atualizado para F123
                writer.WriteLine("# Columns: Position, Grid Position, Laps, Points, Pit Stops, Result Status, Best Lap Time, Total Race Time, Penalties Time, Number of Penalties, Number of Tyre Stints, Tyre Stints Actual, Tyre Stints Visual, Tyre Stints End Laps");

                // Processar a classificação final e exportar os dados para cada carro
                for (int i = 0; i < packetData.m_numCars; i++)
                {
                    FinalClassificationData carData = packetData.m_classificationData[i];

                    string tyreStintsActual = string.Join(",", carData.m_tyreStintsActual); // Convertendo a lista de pneus reais para string
                    string tyreStintsVisual = string.Join(",", carData.m_tyreStintsVisual); // Convertendo a lista de pneus visuais para string
                    string tyreStintsEndLaps = string.Join(",", carData.m_tyreStintsEndLaps); // Convertendo a lista de voltas de término de pneus para string

                    writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                        "{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}",
                        carData.m_position, 
                        carData.m_gridPosition, 
                        carData.m_numLaps, 
                        carData.m_points, 
                        carData.m_numPitStops, 
                        carData.m_resultStatus, 
                        carData.m_bestLapTimeInMS / 1000.0, // Convertendo o tempo da melhor volta para segundos
                        carData.m_totalRaceTime, 
                        carData.m_penaltiesTime, 
                        carData.m_numPenalties, 
                        carData.m_numTyreStints, 
                        tyreStintsActual, 
                        tyreStintsVisual, 
                        tyreStintsEndLaps));
                }
            }

            Console.WriteLine($"PacketFinalClassificationData F123 Sucesso: {filePath}");
        }
    }
}
