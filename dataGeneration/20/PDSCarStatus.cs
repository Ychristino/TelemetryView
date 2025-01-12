using System;
using System.Globalization;
using System.IO;
using TelemetryViewer.Packets.f120.CarStatus;

namespace TelemetryViewer.GeneratePDS.f120.CarStatus
{
    public class PDSCarStatus : PDSExport<PacketCarStatusData> // Herda de PDSExport<PacketCarStatusData>
    {
        public override void ExportToPds(PacketCarStatusData packetData, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine("\n# Car Status Data");
                writer.WriteLine("# Columns: Car Index, Traction Control, ABS, Fuel Mix, Front Brake Bias (%), Pit Limiter, Fuel in Tank, Fuel Capacity, " +
                                    "Fuel Remaining Laps, Max RPM, Idle RPM, Max Gears, DRS Allowed, DRS Activation Distance, Tyres Wear (% FL, FR, RL, RR), " +
                                    "Actual Tyre Compound, Visual Tyre Compound, Tyres Age (laps), Tyres Damage (% FL, FR, RL, RR), " +
                                    "Front Left Wing Damage (%), Front Right Wing Damage (%), Rear Wing Damage (%), DRS Fault, Engine Damage (%), " +
                                    "Gearbox Damage (%), FIA Flags, ERS Store Energy (J), ERS Deploy Mode, ERS Harvested Lap MGU-K (J), " +
                                    "ERS Harvested Lap MGU-H (J), ERS Deployed Lap (J)");

                // Iterar sobre os dados de status de carros
                for (int i = 0; i < packetData.m_carStatusData.Length; i++)
                {
                    var carStatus = packetData.m_carStatusData[i];

                    // Converte os arrays de pneus em strings formatadas
                    string tyresWear = string.Join(", ", carStatus.m_tyresWear);
                    string tyresDamage = string.Join(", ", carStatus.m_tyresDamage);

                    // Escreve os dados formatados
                    writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                        "{0}, {1}, {2}, {3}, {4}, {5}, {6:F2}, {7:F2}, {8:F2}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20}, {21}, {22}, {23}, {24}, {25}, {26}, {27:F2}, {28}, {29:F2}, {30:F2}, {31:F2}",
                        i, // Índice do carro
                        carStatus.m_tractionControl,
                        carStatus.m_antiLockBrakes,
                        carStatus.m_fuelMix,
                        carStatus.m_frontBrakeBias,
                        carStatus.m_pitLimiterStatus,
                        carStatus.m_fuelInTank,
                        carStatus.m_fuelCapacity,
                        carStatus.m_fuelRemainingLaps,
                        carStatus.m_maxRPM,
                        carStatus.m_idleRPM,
                        carStatus.m_maxGears,
                        carStatus.m_drsAllowed,
                        carStatus.m_drsActivationDistance,
                        tyresWear,
                        carStatus.m_actualTyreCompound,
                        carStatus.m_tyreVisualCompound,
                        carStatus.m_tyresAgeLaps,
                        tyresDamage,
                        carStatus.m_frontLeftWingDamage,
                        carStatus.m_frontRightWingDamage,
                        carStatus.m_rearWingDamage,
                        carStatus.m_drsFault,
                        carStatus.m_engineDamage,
                        carStatus.m_gearBoxDamage,
                        carStatus.m_vehicleFiaFlags,
                        carStatus.m_ersStoreEnergy,
                        carStatus.m_ersDeployMode,
                        carStatus.m_ersHarvestedThisLapMGUK,
                        carStatus.m_ersHarvestedThisLapMGUH,
                        carStatus.m_ersDeployedThisLap));
                }
            }

            Console.WriteLine($"PacketCarStatusData Succesfully Saved: {filePath}");
        }
    }
}
