using System;
using System.Globalization;
using System.IO;
using TelemetryViewer.Packets.f120.Motion;

namespace TelemetryViewer.GeneratePDS.f120.Motion
{
    public class PDSMotion : PDSExport<PacketMotion> // Herda de PDSExport<PacketMotionData>
    {
        public override void ExportPdsHeader(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath, append: true))
            {
                // Escrever a seção de dados de movimento dos carros
                writer.WriteLine("# Motion Data");
                writer.WriteLine("# Columns: Car Index, World Position X, World Position Y, World Position Z, " +
                                 "Velocity X, Velocity Y, Velocity Z, G-Force Lateral, G-Force Longitudinal, G-Force Vertical, Yaw, Pitch, Roll");
            }
        }
        public override void ExportToPds(PacketMotion motionData, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath, append: true))
            {
                // Iterar por todos os carros
                for (int i = 0; i < motionData.m_carMotionData.Length; i++)
                {
                    var carData = motionData.m_carMotionData[i];

                    // Escrever os dados de movimento de cada carro
                    writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                        "Car {0}: Position {1:F3}, {2:F3}, {3:F3}, Velocity {4:F3}, {5:F3}, {6:F3}, " +
                        "G-Force {7:F3}, G-Force {8:F3}, G-Force {9:F3}, Yaw {10:F3}, Pitch {11:F3}, Roll {12:F3}",
                        i,
                        carData.m_worldPositionX, carData.m_worldPositionY, carData.m_worldPositionZ,
                        carData.m_worldVelocityX, carData.m_worldVelocityY, carData.m_worldVelocityZ,
                        carData.m_gForceLateral, carData.m_gForceLongitudinal, carData.m_gForceVertical,
                        carData.m_yaw, carData.m_pitch, carData.m_roll
                    ));
                }

                // Escrever dados adicionais do carro do jogador (Suspensão, Velocidade das rodas, etc.)
                writer.WriteLine("\n# Player Car Additional Data");

                // Suspensão
                writer.WriteLine("Suspension Position RL, Suspension Position RR, Suspension Position FL, Suspension Position FR: " + string.Join(", ", motionData.m_suspensionPosition));
                writer.WriteLine("Suspension Velocity RL, Suspension Velocity RR, Suspension Velocity FL, Suspension Velocity FR: " + string.Join(", ", motionData.m_suspensionVelocity));
                writer.WriteLine("Suspension Acceleration RL, Suspension Acceleration RR, Suspension Acceleration FL, Suspension Acceleration FR: " + string.Join(", ", motionData.m_suspensionAcceleration));

                // Velocidade das rodas
                writer.WriteLine("Wheel Speed RL, Wheel Speed RR, Wheel Speed FL, Wheel Speed FR: " + string.Join(", ", motionData.m_wheelSpeed));

                // Deslizamento das rodas
                writer.WriteLine("Wheel Slip RL, Wheel Slip RR, Wheel Slip FL, Wheel Slip FR: " + string.Join(", ", motionData.m_wheelSlip));

                // Velocidade e aceleração angular
                writer.WriteLine("Angular Velocity X, Angular Velocity Y, Angular Velocity Z: " +
                    $"{motionData.m_angularVelocityX:F3}, {motionData.m_angularVelocityY:F3}, {motionData.m_angularVelocityZ:F3}");
                writer.WriteLine("Angular Acceleration X, Angular Acceleration Y, Angular Acceleration Z: " +
                    $"{motionData.m_angularAccelerationX:F3}, {motionData.m_angularAccelerationY:F3}, {motionData.m_angularAccelerationZ:F3}");

                // Velocidade local
                writer.WriteLine("Local Velocity X, Local Velocity Y, Local Velocity Z: " +
                    $"{motionData.m_localVelocityX:F3}, {motionData.m_localVelocityY:F3}, {motionData.m_localVelocityZ:F3}");

                // Ângulo das rodas dianteiras
                writer.WriteLine("Front Wheels Angle: " + motionData.m_frontWheelsAngle.ToString("F3"));
            }

            Console.WriteLine($"Dados de movimento exportados para: {filePath}");
        }
    }
}
