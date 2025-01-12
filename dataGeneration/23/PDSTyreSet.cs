using System;
using System.Globalization;
using System.IO;
using TelemetryViewer.Packets.f123.TyreSets;

namespace TelemetryViewer.GeneratePDS.f123.TyreSets
{
    public class PDSTyreSetsData : PDSExport<PacketTyreSetsData>
    {
        public override void ExportToPds(PacketTyreSetsData packetData, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Escrever o cabeçalho do arquivo CSV
                writer.WriteLine("\n# Tyre Sets Data (F123)"); // Atualizado para F123
                writer.WriteLine("# Columns: Car Index, Tyre Set Index, Actual Tyre Compound, Visual Tyre Compound, Wear, Available, " +
                                  "Recommended Session, Life Span, Usable Life, Lap Delta Time, Fitted");

                // Escrever os dados de conjuntos de pneus
                for (int i = 0; i < packetData.m_tyreSetData.Length; i++)
                {
                    var tyreSet = packetData.m_tyreSetData[i];

                    // Escrever os dados de cada conjunto de pneus
                    writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                        "{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}",
                        packetData.m_carIdx,                   // Índice do carro
                        i,                                     // Índice do conjunto de pneus
                        tyreSet.m_actualTyreCompound,          // Composto real do pneu
                        tyreSet.m_visualTyreCompound,          // Composto visual do pneu
                        tyreSet.m_wear,                        // Desgaste do pneu (percentagem)
                        tyreSet.m_available,                   // Se o conjunto está disponível
                        tyreSet.m_recommendedSession,          // Sessão recomendada para o conjunto
                        tyreSet.m_lifeSpan,                    // Voltas restantes no conjunto
                        tyreSet.m_usableLife,                  // Número máximo de voltas recomendadas para o composto
                        tyreSet.m_lapDeltaTime,                // Tempo de delta de volta comparado ao conjunto montado
                        tyreSet.m_fitted                       // Se o conjunto está montado ou não
                    ));
                }
            }

            Console.WriteLine($"TyreSetsData F123 Sucesso: {filePath}");
        }
    }
}
