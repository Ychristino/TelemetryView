using System;
using System.Globalization;
using System.IO;
using TelemetryViewer.Packets.f121.CarTelemetry;

namespace TelemetryViewer.GeneratePDS.f121.CarTelemetry
{
    public class PDSCarTelemetry : PDSExport<PacketCarTelemetryData>
    {
        public override void ExportToPds(PacketCarTelemetryData packetData, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Escrever o cabeçalho do arquivo CSV
                writer.WriteLine("\n# Car Telemetry Data (F121)");
                writer.WriteLine("# Columns: Car Index, Speed (km/h), Throttle (%), Steer, Brake (%), Clutch (%), Gear, Engine RPM, DRS, Rev Lights (%), " +
                                    "Brakes Temperature (FL, FR, RL, RR), Tyres Surface Temperature (FL, FR, RL, RR), " +
                                    "Tyres Inner Temperature (FL, FR, RL, RR), Engine Temperature, Tyres Pressure (FL, FR, RL, RR), Surface Type, " +
                                    "Button Status, MFD Panel Index, MFD Panel Index (Secondary Player), Suggested Gear");

                // Iterar sobre os dados de telemetria de todos os carros e exportar para o CSV
                for (int i = 0; i < packetData.m_carTelemetryData.Length; i++)
                {
                    var carTelemetry = packetData.m_carTelemetryData[i];

                    // Converter as temperaturas dos pneus e das superfícies para strings
                    string brakeTemperatures = string.Join(", ", carTelemetry.m_brakesTemperature);
                    string tyresSurfaceTemp = string.Join(", ", carTelemetry.m_tyresSurfaceTemperature);
                    string tyresInnerTemp = string.Join(", ", carTelemetry.m_tyresInnerTemperature);
                    string tyresPressure = string.Join(", ", carTelemetry.m_tyresPressure);
                    string surfaceType = string.Join(", ", carTelemetry.m_surfaceType);

                    // Escrever os dados formatados para cada carro
                    writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                        "{0}, {1}, {2:F2}, {3:F2}, {4:F2}, {5}, {6}, {7}, {8}, {9:F2}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20}, {21}, {22}, {23}",
                        i, // Índice do carro
                        carTelemetry.m_speed,
                        carTelemetry.m_throttle * 100,  // Convertendo throttle para porcentagem
                        carTelemetry.m_steer,
                        carTelemetry.m_brake * 100,  // Convertendo brake para porcentagem
                        carTelemetry.m_clutch,
                        carTelemetry.m_gear,
                        carTelemetry.m_engineRPM,
                        carTelemetry.m_drs,
                        carTelemetry.m_revLightsPercent,
                        brakeTemperatures,
                        tyresSurfaceTemp,
                        tyresInnerTemp,
                        carTelemetry.m_engineTemperature,
                        tyresPressure,
                        surfaceType,
                        packetData.m_buttonStatus, // Aqui
                        packetData.m_mfdPanelIndex, // Acessando de PacketCarTelemetryData
                        packetData.m_mfdPanelIndexSecondaryPlayer, // Acessando de PacketCarTelemetryData
                        packetData.m_suggestedGear // Acessando de PacketCarTelemetryData
                    ));
                }

                Console.WriteLine($"PacketCarTelemetryData F121 Sucesso: {filePath}");
            }
        }
    }
}
