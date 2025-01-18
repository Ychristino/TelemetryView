using System;
using System.Globalization;
using System.IO;
using TelemetryViewer.Packets.f121.CarTelemetry;

namespace TelemetryViewer.GeneratePDS.f121.CarTelemetry
{
    public class PDSCarTelemetry : PDSExport<PacketCarTelemetry>
    {
        public override void ExportPdsHeader(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath, append: true))
            {
                // Escrever o cabeçalho do arquivo CSV
                writer.WriteLine("\n# Car Telemetry Data (F121)");
                writer.WriteLine("# Columns: Car Index, Speed (km/h), Throttle (%), Steer, Brake (%), Clutch (%), Gear, Engine RPM, DRS, Rev Lights (%), " +
                                    "Brakes Temperature RL, Brakes Temperature RR, Brakes Temperature FL, Brakes Temperature FR), " +
                                    "Tyres Surface Temperature RL, Tyres Surface Temperature RR, Tyres Surface Temperature FL, Tyres Surface Temperature FR, " +
                                    "Tyres Inner Temperature RL, Tyres Inner Temperature RR, Tyres Inner Temperature FL, Tyres Inner Temperature FR, " +
                                    "Engine Temperature, Tyres Pressure RL, Tyres Pressure RR, Tyres Pressure FL, Tyres Pressure FR, Surface Type, " +
                                    "Button Status, MFD Panel Index, MFD Panel Index (Secondary Player), Suggested Gear");
            }
        }
        public override void ExportToPds(PacketCarTelemetry packetData, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath, append: true))
            {
                // Iterar sobre os dados de telemetria de todos os carros e exportar para o CSV
                for (int i = 0; i < packetData.m_carTelemetryData.Length; i++)
                {
                    var carTelemetry = packetData.m_carTelemetryData[i];
                    // Escrever os dados formatados para cada carro
                    writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                        "{0}, {1}, {2:F2}, {3:F2}, {4:F2}, {5}, {6}, {7}, {8}, {9:F2}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20}, {21}, {22}, {23}, {24}, {25}, {26}, {27}, {28}, {29}, {30}",
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
                        carTelemetry.m_brakesTemperature[0],
                        carTelemetry.m_brakesTemperature[1],
                        carTelemetry.m_brakesTemperature[2],
                        carTelemetry.m_brakesTemperature[3],
                        carTelemetry.m_tyresSurfaceTemperature[0],
                        carTelemetry.m_tyresSurfaceTemperature[1],
                        carTelemetry.m_tyresSurfaceTemperature[2],
                        carTelemetry.m_tyresSurfaceTemperature[3],
                        carTelemetry.m_tyresInnerTemperature[0],
                        carTelemetry.m_tyresInnerTemperature[1],
                        carTelemetry.m_tyresInnerTemperature[2],
                        carTelemetry.m_tyresInnerTemperature[3],
                        carTelemetry.m_engineTemperature,
                        carTelemetry.m_tyresPressure[0],
                        carTelemetry.m_tyresPressure[1],
                        carTelemetry.m_tyresPressure[2],
                        carTelemetry.m_tyresPressure[3],
                        carTelemetry.m_surfaceType[0],   
                        carTelemetry.m_surfaceType[1],   
                        carTelemetry.m_surfaceType[2],   
                        carTelemetry.m_surfaceType[3],   
                        packetData.m_buttonStatus,      
                        packetData.m_mfdPanelIndex,     
                        packetData.m_mfdPanelIndexSecondaryPlayer, 
                        packetData.m_suggestedGear
                    ));
                }

                Console.WriteLine($"PacketCarTelemetryData F121 Sucesso: {filePath}");
            }
        }
    }
}
