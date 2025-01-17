using System;
using System.Globalization;
using System.IO;
using TelemetryViewer.Packets.f122.CarTelemetry;

namespace TelemetryViewer.GeneratePDS.f122.CarTelemetry
{
    public class PDSCarTelemetry : PDSExport<PacketCarTelemetry>
    {
        public override void ExportPdsHeader(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath, append: true))
            {
                // Escrever o cabeçalho do arquivo CSV
                writer.WriteLine("\n# Car Telemetry Data (F122)");
                writer.WriteLine("# Columns: Car Index, Speed (km/h), Throttle, Steer, Brake, Clutch, Gear, Engine RPM, DRS, " +
                                    "Rev Lights Percent, Rev Lights Bit Value, Brake Temperatures RL, Brake Temperatures RR, Brake Temperatures FL, Brake Temperatures FR, " +
                                    "Tyre Surface Temperatures RL, Tyre Surface Temperatures RR, Tyre Surface Temperatures FL, Tyre Surface Temperatures FR, " + 
                                    "Tyre Inner Temperatures RL, Tyre Inner Temperatures RR, Tyre Inner Temperatures FL, Tyre Inner Temperatures FL, Engine Temperature, " +
                                    "Tyre Pressures RL, Tyre Pressures RR, Tyre Pressures FL, Tyre Pressures FR, Surface Types, MFD Panel Index, MFD Panel Index Secondary Player, Suggested Gear");
            }
        }
        public override void ExportToPds(PacketCarTelemetry packetData, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath, append: true))
            {
                // Iterar sobre os dados de telemetria de todos os carros e exportar para o CSV
                for (int i = 0; i < packetData.m_carTelemetryData.Length; i++)
                {
                    var telemetry = packetData.m_carTelemetryData[i];

                    // Formatar e escrever os dados para cada carro
                    writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                        "{0}, {1}, {2:F2}, {3:F2}, {4:F2}, {5}, {6}, {7}, {8}, {9}, {10}, " +
                        "{11}, {12}, {13}, {14}, {15:F2}, {16:F2}, {17:F2}, {18:F2}, {19:F2}, {20}, {21}, {22}",
                        i, // Índice do carro
                        telemetry.m_speed,
                        telemetry.m_throttle,
                        telemetry.m_steer,
                        telemetry.m_brake,
                        telemetry.m_clutch,
                        telemetry.m_gear,
                        telemetry.m_engineRPM,
                        telemetry.m_drs,
                        telemetry.m_revLightsPercent,
                        telemetry.m_revLightsBitValue,
                        string.Join(", ", telemetry.m_brakesTemperature),
                        string.Join(", ", telemetry.m_tyresSurfaceTemperature),
                        string.Join(", ", telemetry.m_tyresInnerTemperature),
                        telemetry.m_engineTemperature,
                        string.Join(", ", telemetry.m_tyresPressure),
                        string.Join(", ", telemetry.m_surfaceType),
                        packetData.m_mfdPanelIndex,
                        packetData.m_mfdPanelIndexSecondaryPlayer,
                        packetData.m_suggestedGear));
                }
            }

            Console.WriteLine($"PacketCarTelemetryData F122 Sucesso: {filePath}");
        }
    }
}
