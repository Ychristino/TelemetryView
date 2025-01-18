using System;
using System.Globalization;
using System.IO;
using TelemetryViewer.Packets.f123.Status; // Alterado para o namespace f123.Status

namespace TelemetryViewer.GeneratePDS.f123.Status
{
    public class PDSCarStatus : PDSExport<PacketCarStatus>
    {
        public override void ExportPdsHeader(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath, append: true))
            {
                // Escrever o cabeçalho do arquivo CSV
                writer.WriteLine("\n# Car Status Data (F123)"); // Atualizado para F123
                writer.WriteLine("# Columns: Car Index, Traction Control, Anti-Lock Brakes, Fuel Mix, Front Brake Bias, " +
                                    "Pit Limiter Status, Fuel in Tank, Fuel Capacity, Fuel Remaining Laps, Max RPM, Idle RPM, " +
                                    "Max Gears, DRS Allowed, DRS Activation Distance, Actual Tyre Compound, Visual Tyre Compound, " +
                                    "Tyre Age Laps, Vehicle FIA Flags, Engine Power ICE, Engine Power MGU-K, ERS Stored Energy, " +
                                    "ERS Deploy Mode, ERS Harvested This Lap MGU-K, ERS Harvested This Lap MGU-H, ERS Deployed This Lap, Network Paused");
            }
        }
        public override void ExportToPds(PacketCarStatus packetData, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath, append: true))
            {
                // Escrever os dados de status para cada carro
                for (int i = 0; i < packetData.m_carStatusData.Length; i++)
                {
                    CarStatusData carStatus = packetData.m_carStatusData[i];
                    writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                        "{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20}, {21}, {22}, {23}, {24}, {25}",
                        i, // Índice do carro (assumindo que é a posição no array)
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
                        carStatus.m_enginePowerICE,
                        carStatus.m_enginePowerMGUK,
                        carStatus.m_ersStoreEnergy,
                        carStatus.m_ersDeployMode,
                        carStatus.m_ersHarvestedThisLapMGUK,
                        carStatus.m_ersHarvestedThisLapMGUH,
                        carStatus.m_ersDeployedThisLap,
                        carStatus.m_networkPaused
                    ));
                }
            }

            Console.WriteLine($"PacketCarStatusData F123 Sucesso: {filePath}");
        }
    }
}
