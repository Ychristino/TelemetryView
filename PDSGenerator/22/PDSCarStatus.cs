using System;
using System.Globalization;
using System.IO;
using TelemetryViewer.Packets.f122.CarStatus;

namespace TelemetryViewer.GeneratePDS.f122.CarStatus
{
    public class PDSCarStatus : PDSExport<PacketCarStatus>
    {
        public override void ExportPdsHeader(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath, append: true))
            {
                // Escrever o cabeçalho do arquivo CSV
                writer.WriteLine("\n# Car Status Data (F122)");
                writer.WriteLine("# Columns: Car Index, Traction Control, Anti-Lock Brakes, Fuel Mix, Front Brake Bias, Pit Limiter Status, Fuel In Tank, " +
                                    "Fuel Capacity, Fuel Remaining Laps, Max RPM, Idle RPM, Max Gears, DRS Allowed, DRS Activation Distance, " +
                                    "Actual Tyre Compound, Visual Tyre Compound, Tyres Age Laps, Vehicle FIA Flags, ERS Stored Energy, ERS Deploy Mode, " +
                                    "ERS Harvested This Lap MGUK, ERS Harvested This Lap MGUH, ERS Deployed This Lap, Network Paused");
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
                        "{0}, {1}, {2}, {3}, {4}, {5}, {6:F2}, {7:F2}, {8:F2}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18:F2}, {19}, {20:F2}, {21:F2}, {22:F2}, {23}",
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
                        carStatus.m_actualTyreCompound,
                        carStatus.m_visualTyreCompound,
                        carStatus.m_tyresAgeLaps,
                        carStatus.m_vehicleFiaFlags,
                        carStatus.m_ersStoreEnergy,
                        carStatus.m_ersDeployMode,
                        carStatus.m_ersHarvestedThisLapMGUK,
                        carStatus.m_ersHarvestedThisLapMGUH,
                        carStatus.m_ersDeployedThisLap,
                        carStatus.m_networkPaused));
                }
            }

            Console.WriteLine($"PacketCarStatusData F122 Sucesso: {filePath}");
        }
    }
}
