using System;
using System.Globalization;
using System.IO;
using TelemetryViewer.Dicts.f120.Buttons;
using TelemetryViewer.Dicts.f120.Surface;
using TelemetryViewer.Packets.f120.CarTelemetry;

namespace TelemetryViewer.GeneratePDS.f120.CarTelemetry
{
    public class PDSCarTelemetry : PDSExport<PacketCarTelemetry> // Herda de PDSExport<PacketCarTelemetryData>
    {
        public override void ExportPdsHeader(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath, append: true))
            {
                writer.WriteLine("\n# Car Telemetry Data");
                writer.WriteLine("# Columns: Car Index, Speed (km/h), Throttle, Steer, Brake, Clutch (%), Gear, Engine RPM, DRS, Rev Lights (%), " +
                                    "Brakes Temp RL, Brakes Temp RR, Brakes Temp FL, Brakes Temp FR, Tyres Surface Temp RL, Tyres Surface Temp RR, Tyres Surface Temp FL, Tyres Surface Temp FR, " +
                                    "Tyres Inner Temp RL, Tyres Inner Temp RR, Tyres Inner Temp FL, Tyres Inner Temp FR, " +
                                    "Engine Temp (C), Tyres Pressure RL, Tyres Pressure RR, Tyres Pressure FL, Tyres Pressure FR, Surface Type RL, Surface Type RR, Surface Type FL, Surface Type FR");
            }
        }
        public override void ExportToPds(PacketCarTelemetry telemetryData, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath, append: true))
            {
                for (int i = 0; i < telemetryData.m_carTelemetryData.Length; i++)
                {
                    var carTelemetry = telemetryData.m_carTelemetryData[i];
                    string brakesTemp = string.Join(", ", carTelemetry.m_brakesTemperature);
                    string tyresSurfaceTemp = string.Join(", ", carTelemetry.m_tyresSurfaceTemperature);
                    string tyresInnerTemp = string.Join(", ", carTelemetry.m_tyresInnerTemperature);
                    string tyresPressure = string.Join(", ", carTelemetry.m_tyresPressure);
                    string surfaceType = string.Join(", ", carTelemetry.m_surfaceType);

                    writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                        "{0}, {1}, {2:F2}, {3:F2}, {4:F2}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20}, {21}, {22}, {23}, {24}, {25}, {26}, {27}, {28}, {29}, {30}",
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
                        Surface.GetSurfaceName(carTelemetry.m_surfaceType[0]),
                        Surface.GetSurfaceName(carTelemetry.m_surfaceType[1]),
                        Surface.GetSurfaceName(carTelemetry.m_surfaceType[1]),
                        Surface.GetSurfaceName(carTelemetry.m_surfaceType[3])
                    ));
                }

                // Seção de status do painel MFD
                writer.WriteLine("\n# MFD Panel Status");
                writer.WriteLine("# Columns: Button Status, MFD Panel Index, MFD Panel Index Secondary Player, Suggested Gear");
                writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                    "{0}, {1}, {2}, {3}",
                    Button.GetPressedButtons(telemetryData.m_buttonStatus),
                    telemetryData.m_mfdPanelIndex,
                    telemetryData.m_mfdPanelIndexSecondaryPlayer,
                    telemetryData.m_suggestedGear));
            }

            Console.WriteLine($"Arquivo de telemetria salvo com sucesso em: {filePath}");
        }
    }
}
