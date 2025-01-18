using System;
using System.Globalization;
using System.IO;
using TelemetryViewer.Packets.f122.Motion; // Alterado para o namespace f122.Motion

namespace TelemetryViewer.GeneratePDS.f122.Motion
{
    public class PDSCarMotion : PDSExport<PacketMotion>
    {
        public override void ExportPdsHeader(string filePath){
            using (StreamWriter writer = new StreamWriter(filePath, append: true))
            {
                // Escrever o cabeçalho do arquivo CSV
                writer.WriteLine("\n# Car Motion Data (F122)"); // Alterado para F122
                writer.WriteLine("# Columns: Car Index, World Position X, World Position Y, World Position Z, " +
                                    "World Velocity X, World Velocity Y, World Velocity Z, " +
                                    "World Forward Dir X, World Forward Dir Y, World Forward Dir Z, " +
                                    "World Right Dir X, World Right Dir Y, World Right Dir Z, " +
                                    "Lateral G-Force, Longitudinal G-Force, Vertical G-Force, " +
                                    "Yaw, Pitch, Roll");
            }
        }
        public override void ExportToPds(PacketMotion packetData, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath, append: true))
            {
                // Escrever os dados de movimento de cada carro
                for (int i = 0; i < packetData.m_carMotionData.Length; i++)
                {
                    var carMotion = packetData.m_carMotionData[i];

                    // Escrever os dados de movimento no arquivo CSV
                    writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                        "{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}",
                        i, // Índice do carro
                        carMotion.m_worldPositionX,
                        carMotion.m_worldPositionY,
                        carMotion.m_worldPositionZ,
                        carMotion.m_worldVelocityX,
                        carMotion.m_worldVelocityY,
                        carMotion.m_worldVelocityZ,
                        carMotion.m_worldForwardDirX,
                        carMotion.m_worldForwardDirY,
                        carMotion.m_worldForwardDirZ,
                        carMotion.m_worldRightDirX,
                        carMotion.m_worldRightDirY,
                        carMotion.m_worldRightDirZ,
                        carMotion.m_gForceLateral,
                        carMotion.m_gForceLongitudinal,
                        carMotion.m_gForceVertical,
                        carMotion.m_yaw,
                        carMotion.m_pitch,
                        carMotion.m_roll
                    ));
                }

                // Escrever os dados específicos para o carro do jogador
                writer.WriteLine("\n# Player Car Specific Data");
                writer.WriteLine("# Columns: Suspension Position, Suspension Velocity, Suspension Acceleration, " +
                                 "Wheel Speed, Wheel Slip, Local Velocity X, Local Velocity Y, Local Velocity Z, " +
                                 "Angular Velocity X, Angular Velocity Y, Angular Velocity Z, " +
                                 "Angular Acceleration X, Angular Acceleration Y, Angular Acceleration Z, Front Wheels Angle");

                // Dados do carro do jogador
                for (int i = 0; i < 4; i++) // Para as 4 rodas
                {
                    writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                        "{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}",
                        packetData.m_suspensionPosition[i],
                        packetData.m_suspensionVelocity[i],
                        packetData.m_suspensionAcceleration[i],
                        packetData.m_wheelSpeed[i],
                        packetData.m_wheelSlip[i],
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
            }

            Console.WriteLine($"PacketMotionData F122 Sucesso: {filePath}");
        }
    }
}
