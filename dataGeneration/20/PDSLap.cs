using System;
using System.Globalization;
using System.IO;
using TelemetryViewer.Packets.f120.Lap;

namespace TelemetryViewer.GeneratePDS.f120.Lap
{
    public class PDSLapData : PDSExport<PacketLapData> // Herda de PDSExport<PacketLapData>
    {
        public override void ExportToPds(PacketLapData lapData, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Escrever a seção de dados da volta
                writer.WriteLine("# Lap Data");
                writer.WriteLine("# Columns: Car Position, Current Lap, Current Lap Time, Best Lap Time, Total Distance, Safety Car Delta, Pit Status, Sector");

                // Iterar por todos os carros
                for (int i = 0; i < lapData.m_lapData.Length; i++)
                {
                    var carLapData = lapData.m_lapData[i];

                    // Escrever os dados de cada carro
                    writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                        "{0}, {1}, {2:F3}, {3:F3}, {4:F2}, {5:F3}, {6}, {7}",
                        carLapData.m_carPosition,
                        carLapData.m_currentLapNum,
                        carLapData.m_currentLapTime,
                        carLapData.m_bestLapTime,
                        carLapData.m_totalDistance,
                        carLapData.m_safetyCarDelta,
                        carLapData.m_pitStatus,
                        carLapData.m_sector
                    ));
                }
            }

            Console.WriteLine($"Dados das voltas exportados para: {filePath}");
        }
    }
}
