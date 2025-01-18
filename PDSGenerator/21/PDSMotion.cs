using System;
using System.Globalization;
using System.IO;
using System.Text;
using TelemetryViewer.Packets.f121.Motion;

namespace TelemetryViewer.GeneratePDS.f121.Motion
{
    public class PDSCarMotion : PDSExport<PacketMotion>
    {
        public override void ExportPdsHeader(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath, append: true))
            {
                // Escrever o cabeçalho do arquivo CSV
                writer.WriteLine("\n# Car Motion Data (F121)");
                writer.WriteLine("# Columns: Car Index, World Position X, World Position Y, World Position Z, Velocity X, Velocity Y, Velocity Z, Direction Forward, Direction Right, G-Force Lateral, G-Force Longitudinal, G-Force Vertical, Angles Yaw, Angles Pitch, Angles Roll");
            }
        }
        public override void ExportToPds(PacketMotion packetData, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath, append: true))
            {
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
                writer.WriteLine("# Columns: Suspension Position RL, Suspension Position RR, Suspension Position FL, Suspension Position FR, " +
                                 "Suspension Velocity RL, Suspension Velocity RR, Suspension Velocity FL, Suspension Velocity FR, Wheel Speed RL, " +
                                 "Wheel Speed RR, Wheel Speed FL, Wheel Speed FR, Wheel Slip RL, Wheel Slip RR, Wheel Slip FL, Wheel Slip FR, " +
                                 "Local Velocity X, Local Velocity Y, Local Velocity Z, Angular Velocity X, Angular Velocity Y, Angular Velocity Z, " +
                                 "Angular Acceleration X, Angular Acceleration Y, Angular Acceleration Z, Front Wheels Angle");
                // Assumindo que os dados adicionais do jogador estão no primeiro índice (índice 0)
                writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                    "{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20}, {21}, {22}, {23}, {24}, {25}",
                    packetData.m_suspensionPosition[0],
                    packetData.m_suspensionPosition[1],
                    packetData.m_suspensionPosition[2],
                    packetData.m_suspensionPosition[3],
                    packetData.m_suspensionVelocity[0],
                    packetData.m_suspensionVelocity[1],
                    packetData.m_suspensionVelocity[2],
                    packetData.m_suspensionVelocity[3],
                    packetData.m_wheelSpeed[0],
                    packetData.m_wheelSpeed[1],
                    packetData.m_wheelSpeed[2],
                    packetData.m_wheelSpeed[3],
                    packetData.m_wheelSlip[0],
                    packetData.m_wheelSlip[1],
                    packetData.m_wheelSlip[2],
                    packetData.m_wheelSlip[3],
                    packetData.m_localVelocityX, 
                    packetData.m_localVelocityY, 
                    packetData.m_localVelocityZ,
                    packetData.m_angularVelocityX, 
                    packetData.m_angularVelocityY, 
                    packetData.m_angularVelocityZ,
                    packetData.m_angularAccelerationX, 
                    packetData.m_angularAccelerationY, 
                    packetData.m_angularAccelerationZ,
                    packetData.m_frontWheelsAngle
                ));
            }

            Console.WriteLine($"CarMotion F121 Exportado com sucesso: {filePath}");
        }
    }
}
