using System;
using System.Globalization;
using System.IO;
using TelemetryViewer.Packets.f121.CarStatus;

namespace TelemetryViewer.GeneratePDS.f121.CarStatus
{
    public class PDSCarStatus : PDSExport<PacketCarStatus>
    {
        public override void ExportPdsHeader(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath, append: true))
            {
                // Escrever o cabeçalho do arquivo CSV
                writer.WriteLine("\n# Car Status Data (F121)");
                writer.WriteLine("# Columns: Car Index, Traction Control, ABS, Fuel Mix, Front Brake Bias (%), Pit Limiter, Fuel in Tank, Fuel Capacity, " +
                                    "Fuel Remaining Laps, Max RPM, Idle RPM, Max Gears, DRS Allowed, DRS Activation Distance, Tyres Wear RL, Tyres Wear RR, Tyres Wear FL, Tyres Wear FR, " +
                                    "Actual Tyre Compound, Visual Tyre Compound, Tyres Age (laps), Tyres Damage RL, Tyres Damage RR, Tyres Damage FL, Tyres Damage FR, " +
                                    "Front Left Wing Damage (%), Front Right Wing Damage (%), Rear Wing Damage (%), DRS Fault, Engine Damage (%), " +
                                    "Gearbox Damage (%), FIA Flags, ERS Store Energy (J), ERS Deploy Mode, ERS Harvested Lap MGU-K (J), " +
                                    "ERS Harvested Lap MGU-H (J), ERS Deployed Lap (J)");
            }
        }
        public override void ExportToPds(PacketCarStatus packetData, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath, append: true))
            {
                // Iterar sobre os dados de status de todos os carros e exportar para o CSV
                for (int i = 0; i < packetData.m_carStatusData.Length; i++)
                {
                    var carStatus = packetData.m_carStatusData[i];

                    // Escrever os dados formatados para cada carro
                    writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                        "{0}, {1}, {2}, {3}, {4}, {5}, {6:F2}, {7:F2}, {8:F2}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20}, {21}, {22}, {23}, {24}, {25}, {26}, {27}, {28}, {29}, {30}, {31}, {32}, {33:F2}, {34}, {35:F2}, {36:F2}, {37:F2}",
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
                        carStatus.m_tyresWear[0],
                        carStatus.m_tyresWear[1],
                        carStatus.m_tyresWear[2],
                        carStatus.m_tyresWear[3],
                        carStatus.m_actualTyreCompound,
                        carStatus.m_tyreVisualCompound,
                        carStatus.m_tyresAgeLaps,
                        carStatus.m_tyresDamage[0],
                        carStatus.m_tyresDamage[1],
                        carStatus.m_tyresDamage[2],
                        carStatus.m_tyresDamage[3],
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
                        carStatus.m_ersDeployedThisLap
                    ));
                }
            }

            Console.WriteLine($"PacketCarStatusData F121 Sucesso: {filePath}");
        }
    }
}
