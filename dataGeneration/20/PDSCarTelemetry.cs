using System;
using System.Globalization;
using System.IO;
using TelemetryViewer.Packets.f120.CarTelemetry;

namespace TelemetryViewer.GeneratePDS.f120.CarTelemetry
{
    public class PDSCarTelemetry : PDSExport<PacketCarTelemetryData> // Herda de PDSExport<PacketCarTelemetryData>
    {
        public override void ExportToPds(PacketCarTelemetryData telemetryData, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine("\n# Car Telemetry Data");
                writer.WriteLine("# Columns: Car Index, Speed (km/h), Throttle, Steer, Brake, Clutch (%), Gear, Engine RPM, DRS, Rev Lights (%), " +
                                    "Brakes Temp (FL, FR, RL, RR), Tyres Surface Temp (FL, FR, RL, RR), Tyres Inner Temp (FL, FR, RL, RR), " +
                                    "Engine Temp (C), Tyres Pressure (FL, FR, RL, RR), Surface Type (FL, FR, RL, RR)");

                for (int i = 0; i < telemetryData.m_carTelemetryData.Length; i++)
                {
                    var carTelemetry = telemetryData.m_carTelemetryData[i];
                    string brakesTemp = string.Join(", ", carTelemetry.m_brakesTemperature);
                    string tyresSurfaceTemp = string.Join(", ", carTelemetry.m_tyresSurfaceTemperature);
                    string tyresInnerTemp = string.Join(", ", carTelemetry.m_tyresInnerTemperature);
                    string tyresPressure = string.Join(", ", carTelemetry.m_tyresPressure);
                    string surfaceType = string.Join(", ", carTelemetry.m_surfaceType);

                    writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                        "{0}, {1}, {2:F2}, {3:F2}, {4:F2}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}",
                        i,
                        carTelemetry.m_speed,
                        carTelemetry.m_throttle,
                        carTelemetry.m_steer,
                        carTelemetry.m_brake,
                        carTelemetry.m_clutch,
                        carTelemetry.m_gear,
                        carTelemetry.m_engineRPM,
                        carTelemetry.m_drs,
                        carTelemetry.m_revLightsPercent,
                        brakesTemp,
                        tyresSurfaceTemp,
                        tyresInnerTemp,
                        carTelemetry.m_engineTemperature,
                        tyresPressure,
                        surfaceType));
                }

                // Seção de status do painel MFD
                writer.WriteLine("\n# MFD Panel Status");
                writer.WriteLine("# Columns: Button Status, MFD Panel Index, MFD Panel Index Secondary Player, Suggested Gear");
                writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                    "{0}, {1}, {2}, {3}",
                    telemetryData.m_buttonStatus,
                    telemetryData.m_mfdPanelIndex,
                    telemetryData.m_mfdPanelIndexSecondaryPlayer,
                    telemetryData.m_suggestedGear));
            }

            Console.WriteLine($"Arquivo de telemetria salvo com sucesso em: {filePath}");
        }
    }
}
