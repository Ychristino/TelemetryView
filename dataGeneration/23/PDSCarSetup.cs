using System;
using System.Globalization;
using System.IO;
using TelemetryViewer.Packets.f123.CarSetup; // Alterado para o namespace f123.CarSetup

namespace TelemetryViewer.GeneratePDS.f123.CarSetup
{
    public class PDSCarSetupData : PDSExport<PacketCarSetupData>
    {
        public override void ExportToPds(PacketCarSetupData packetData, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Escrever o cabeçalho do arquivo CSV
                writer.WriteLine("\n# Car Setup Data (F123)"); // Atualizado para F123
                writer.WriteLine("# Columns: Car Index, Front Wing, Rear Wing, On Throttle, Off Throttle, " +
                                 "Front Camber, Rear Camber, Front Toe, Rear Toe, Front Suspension, Rear Suspension, " +
                                 "Front Anti-Roll Bar, Rear Anti-Roll Bar, Front Suspension Height, Rear Suspension Height, " +
                                 "Brake Pressure, Brake Bias, Rear Left Tyre Pressure, Rear Right Tyre Pressure, " +
                                 "Front Left Tyre Pressure, Front Right Tyre Pressure, Ballast, Fuel Load");

                // Escrever os dados de configuração para cada carro
                for (int i = 0; i < packetData.m_carSetups.Length; i++)
                {
                    CarSetupData carSetup = packetData.m_carSetups[i];
                    writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                        "{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20}, {21}",
                        i, // Índice do carro (assumindo que é a posição no array)
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

            Console.WriteLine($"PacketCarSetupData F123 Sucesso: {filePath}");
        }
    }
}
