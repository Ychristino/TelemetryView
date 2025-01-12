using System;
using System.Globalization;
using System.IO;
using TelemetryViewer.Packets.f123.MotionEx;

namespace TelemetryViewer.GeneratePDS.f123.MotionEx
{
    public class PDSMotionExData : PDSExport<PacketMotionExData>
    {
        public override void ExportToPds(PacketMotionExData packetData, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Escrever o cabeçalho do arquivo CSV
                writer.WriteLine("\n# Motion Ex Data (F123)"); // Atualizado para F123
                writer.WriteLine("# Columns: Suspension Position (RL, RR, FL, FR), Suspension Velocity (RL, RR, FL, FR), " +
                                  "Suspension Acceleration (RL, RR, FL, FR), Wheel Speed (RL, RR, FL, FR), " +
                                  "Wheel Slip Ratio (RL, RR, FL, FR), Wheel Slip Angle (RL, RR, FL, FR), " +
                                  "Wheel Lat Force (RL, RR, FL, FR), Wheel Long Force (RL, RR, FL, FR), " +
                                  "Height of COG Above Ground, Local Velocity X, Local Velocity Y, Local Velocity Z, " +
                                  "Angular Velocity X, Angular Velocity Y, Angular Velocity Z, " +
                                  "Angular Acceleration X, Angular Acceleration Y, Angular Acceleration Z, " +
                                  "Front Wheels Angle, Wheel Vert Force (RL, RR, FL, FR)");

                // Escrever os dados de motion ex
                writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                    "{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20}, {21}, {22}, {23}",
                    // Dados das suspensões
                    string.Join(", ", packetData.m_suspensionPosition),
                    string.Join(", ", packetData.m_suspensionVelocity),
                    string.Join(", ", packetData.m_suspensionAcceleration),
                    // Dados das rodas
                    string.Join(", ", packetData.m_wheelSpeed),
                    string.Join(", ", packetData.m_wheelSlipRatio),
                    string.Join(", ", packetData.m_wheelSlipAngle),
                    string.Join(", ", packetData.m_wheelLatForce),
                    string.Join(", ", packetData.m_wheelLongForce),
                    // Dados do centro de gravidade
                    packetData.m_heightOfCOGAboveGround,
                    // Dados de velocidade local
                    packetData.m_localVelocityX, packetData.m_localVelocityY, packetData.m_localVelocityZ,
                    // Dados de velocidade angular
                    packetData.m_angularVelocityX, packetData.m_angularVelocityY, packetData.m_angularVelocityZ,
                    // Dados de aceleração angular
                    packetData.m_angularAccelerationX, packetData.m_angularAccelerationY, packetData.m_angularAccelerationZ,
                    // Ângulo das rodas dianteiras
                    packetData.m_frontWheelsAngle,
                    // Dados das forças verticais nas rodas
                    string.Join(", ", packetData.m_wheelVertForce)
                ));
            }

            Console.WriteLine($"MotionExData F123 Sucesso: {filePath}");
        }
    }
}
