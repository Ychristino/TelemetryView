using System;
using System.Globalization;
using System.IO;
using TelemetryViewer.Packets.f123.Motion;

namespace TelemetryViewer.GeneratePDS.f123.Motion
{
    public class PDSMotionData : PDSExport<PacketMotionData>
    {
        public override void ExportToPds(PacketMotionData packetData, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Escrever o cabeçalho do arquivo CSV
                writer.WriteLine("\n# Motion Data (F123)"); // Atualizado para F123
                writer.WriteLine("# Columns: Car Index, World Position (X, Y, Z), World Velocity (X, Y, Z), World Direction (Forward X, Forward Y, Forward Z, Right X, Right Y, Right Z), G-Forces (Lateral, Longitudinal, Vertical), Yaw, Pitch, Roll");

                // Processar os dados de movimento dos carros
                for (int i = 0; i < packetData.CarMotionData.Length; i++)
                {
                    var carData = packetData.CarMotionData[i];

                    // Escrever as informações do carro para o arquivo CSV
                    writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                        "{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}",
                        i + 1, // Índice do carro (começando de 1)
                        carData.WorldPositionX, carData.WorldPositionY, carData.WorldPositionZ, // Posição do carro (X, Y, Z)
                        carData.WorldVelocityX, carData.WorldVelocityY, carData.WorldVelocityZ, // Velocidade do carro (X, Y, Z)
                        carData.WorldForwardDirX, carData.WorldForwardDirY, carData.WorldForwardDirZ, // Direção do carro (Forward)
                        carData.WorldRightDirX, carData.WorldRightDirY, carData.WorldRightDirZ, // Direção do carro (Right)
                        carData.GForceLateral, carData.GForceLongitudinal, carData.GForceVertical, // Forças G (Lateral, Longitudinal, Vertical)
                        carData.Yaw, carData.Pitch, carData.Roll // Ângulos de Yaw, Pitch e Roll
                    ));
                }
            }

            Console.WriteLine($"MotionData F123 Sucesso: {filePath}");
        }
    }
}
