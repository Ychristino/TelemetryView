using System;
using System.Globalization;
using System.IO;
using System.Text;
using TelemetryViewer.Packets.f121.Motion;

namespace TelemetryViewer.GeneratePDS.f121.Motion
{
    public class PDSCarMotion : PDSExport<PacketMotionData>
    {
        public override void ExportToPds(PacketMotionData packetData, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Escrever o cabeçalho do arquivo CSV
                writer.WriteLine("\n# Car Motion Data (F121)");
                writer.WriteLine("# Columns: Car Index, World Position (X, Y, Z), Velocity (X, Y, Z), Direction (Forward, Right), G-Force (Lateral, Longitudinal, Vertical), Angles (Yaw, Pitch, Roll)");

                // Escrever os dados de cada carro no pacote
                for (int i = 0; i < packetData.m_carMotionData.Length; i++)
                {
                    var carData = packetData.m_carMotionData[i];

                    writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                        "{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}",
                        i,
                        carData.m_worldPositionX, carData.m_worldPositionY, carData.m_worldPositionZ,
                        carData.m_worldVelocityX, carData.m_worldVelocityY, carData.m_worldVelocityZ,
                        carData.m_worldForwardDirX, carData.m_worldForwardDirY, carData.m_worldForwardDirZ,
                        carData.m_worldRightDirX, carData.m_worldRightDirY, carData.m_worldRightDirZ,
                        carData.m_gForceLateral, carData.m_gForceLongitudinal, carData.m_gForceVertical,
                        carData.m_yaw, carData.m_pitch, carData.m_roll
                    ));
                }

                // Escrever dados adicionais do carro do jogador
                writer.WriteLine("\n# Player Car Data:");
                writer.WriteLine("# Columns: Suspension Position (RL, RR, FL, FR), Suspension Velocity (RL, RR, FL, FR), Wheel Speed (RL, RR, FL, FR), Wheel Slip (RL, RR, FL, FR), Local Velocity (X, Y, Z), Angular Velocity (X, Y, Z), Angular Acceleration (X, Y, Z), Front Wheels Angle");

                // Assumindo que os dados adicionais do jogador estão no primeiro índice (índice 0)
                writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                    "{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}",
                    string.Join(", ", packetData.m_suspensionPosition),
                    string.Join(", ", packetData.m_suspensionVelocity),
                    string.Join(", ", packetData.m_wheelSpeed),
                    string.Join(", ", packetData.m_wheelSlip),
                    packetData.m_localVelocityX, packetData.m_localVelocityY, packetData.m_localVelocityZ,
                    packetData.m_angularVelocityX, packetData.m_angularVelocityY, packetData.m_angularVelocityZ,
                    packetData.m_angularAccelerationX, packetData.m_angularAccelerationY, packetData.m_angularAccelerationZ,
                    packetData.m_frontWheelsAngle
                ));
            }

            Console.WriteLine($"CarMotion F121 Exportado com sucesso: {filePath}");
        }
    }
}
