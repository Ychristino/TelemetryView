using System;
using System.Globalization;
using System.IO;
using TelemetryViewer.Packets.f123.Telemetry; // Alterado para o namespace f123.Telemetry

namespace TelemetryViewer.GeneratePDS.f123.Telemetry
{
    public class PDSCarTelemetry : PDSExport<PacketCarTelemetry>
    {
        public override void ExportPdsHeader(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath, append: true))
            {
                // Escrever o cabeçalho do arquivo CSV
                writer.WriteLine("\n# Car Telemetry Data (F123)"); // Atualizado para F123
                writer.WriteLine("# Columns: Car Index, Speed, Throttle, Steer, Brake, Clutch, Gear, Engine RPM, DRS, Rev Lights Percent, Rev Lights Bit Value, " +
                                    "Brakes Temperature RL, Brakes Temperature RR, Brakes Temperature FL, Brakes Temperature FR, " +
                                    "Tyres Surface Temp RL, Tyres Surface Temp RR, Tyres Surface Temp FL, Tyres Surface Temp FR, " +
                                    "Tyres Inner Temp RL, Tyres Inner Temp RR, Tyres Inner Temp FL, Tyres Inner Temp FR, Engine Temp, " +
                                    "Tyres Pressure RL, Tyres Pressure RR, Tyres Pressure FL, Tyres Pressure FR, " +
                                    "Surface Type RL, Surface Type RR, Surface Type FL, Surface Type FR, " +
                                    "MFD Panel Index, MFD Panel Index Secondary Player, Suggested Gear");
            }
        }
        public override void ExportToPds(PacketCarTelemetry packetData, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath, append: true))
            {
                // Escrever os dados de telemetria para cada carro
                for (int i = 0; i < packetData.m_carTelemetryData.Length; i++)
                {
                    CarTelemetryData carTelemetry = packetData.m_carTelemetryData[i];

                    // Dados de telemetria de cada carro
                    writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                        "{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, " +
                        "{11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20}, " +
                        "{21}, {22}, {23}, {24}, {25}, {26}, {27}, {28}, {29}, {30}, {31}",
                        i, // Índice do carro (assumindo que é a posição no array)
                        carTelemetry.m_speed,
                        carTelemetry.m_throttle,
                        carTelemetry.m_steer,
                        carTelemetry.m_brake,
                        carTelemetry.m_clutch,
                        carTelemetry.m_gear,
                        carTelemetry.m_engineRPM,
                        carTelemetry.m_drs,
                        carTelemetry.m_revLightsPercent,
                        carTelemetry.m_revLightsBitValue,
                        carTelemetry.m_brakesTemperature[0], carTelemetry.m_brakesTemperature[1], carTelemetry.m_brakesTemperature[2], carTelemetry.m_brakesTemperature[3],
                        carTelemetry.m_tyresSurfaceTemperature[0], carTelemetry.m_tyresSurfaceTemperature[1], carTelemetry.m_tyresSurfaceTemperature[2], carTelemetry.m_tyresSurfaceTemperature[3],
                        carTelemetry.m_tyresInnerTemperature[0], carTelemetry.m_tyresInnerTemperature[1], carTelemetry.m_tyresInnerTemperature[2], carTelemetry.m_tyresInnerTemperature[3],
                        carTelemetry.m_engineTemperature,
                        carTelemetry.m_tyresPressure[0], carTelemetry.m_tyresPressure[1], carTelemetry.m_tyresPressure[2], carTelemetry.m_tyresPressure[3],
                        carTelemetry.m_surfaceType[0], carTelemetry.m_surfaceType[1], carTelemetry.m_surfaceType[2], carTelemetry.m_surfaceType[3],
                        packetData.m_mfdPanelIndex,
                        packetData.m_mfdPanelIndexSecondaryPlayer,
                        packetData.m_suggestedGear
                    ));
                }
            }

            Console.WriteLine($"PacketCarTelemetryData F123 Sucesso: {filePath}");
        }
    }
}
