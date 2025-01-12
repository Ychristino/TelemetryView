using System;
using System.Globalization;
using System.IO;
using TelemetryViewer.Packets.f121.CarSetup;

namespace TelemetryViewer.GeneratePDS.f121.CarSetup
{
    public class PDSCarSetup : PDSExport<PacketCarSetupData>
    {
        public override void ExportToPds(PacketCarSetupData packetData, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Escrever a seção de dados de configuração do carro
                writer.WriteLine("\n# Car Setup Data (F121)");
                writer.WriteLine("# Columns: Car Index, Front Wing, Rear Wing, On Throttle (%), Off Throttle (%), " +
                                    "Front Camber, Rear Camber, Front Toe, Rear Toe, Front Suspension, Rear Suspension, " +
                                    "Front Anti-Roll Bar, Rear Anti-Roll Bar, Front Suspension Height, Rear Suspension Height, " +
                                    "Brake Pressure (%), Brake Bias (%), Rear Left Tyre Pressure (PSI), Rear Right Tyre Pressure (PSI), " +
                                    "Front Left Tyre Pressure (PSI), Front Right Tyre Pressure (PSI), Ballast, Fuel Load");

                // Iterar sobre os dados de configuração do carro e escrever os dados
                for (int i = 0; i < packetData.m_carSetups.Length; i++)
                {
                    var carSetup = packetData.m_carSetups[i];
                    writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                        "{0}, {1}, {2}, {3}, {4}, {5:F2}, {6:F2}, {7:F2}, {8:F2}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16:F2}, {17:F2}, {18:F2}, {19:F2}, {20:F2}, {21:F2}, {22:F2}",
                        i, // Índice do carro
                        carSetup.m_frontWing,
                        carSetup.m_rearWing,
                        carSetup.m_onThrottle,
                        carSetup.m_offThrottle,
                        carSetup.m_frontCamber,
                        carSetup.m_rearCamber,
                        carSetup.m_frontToe,
                        carSetup.m_rearToe,
                        carSetup.m_frontSuspension,
                        carSetup.m_rearSuspension,
                        carSetup.m_frontAntiRollBar,
                        carSetup.m_rearAntiRollBar,
                        carSetup.m_frontSuspensionHeight,
                        carSetup.m_rearSuspensionHeight,
                        carSetup.m_brakePressure,
                        carSetup.m_brakeBias,
                        carSetup.m_rearLeftTyrePressure,
                        carSetup.m_rearRightTyrePressure,
                        carSetup.m_frontLeftTyrePressure,
                        carSetup.m_frontRightTyrePressure,
                        carSetup.m_ballast,
                        carSetup.m_fuelLoad
                    ));
                }
            }

            Console.WriteLine($"PacketCarSetupData F121 Sucesso: {filePath}");
        }
    }
}
