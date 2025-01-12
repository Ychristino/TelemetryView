using System;
using System.Runtime.InteropServices;
using TelemetryViewer.Packets.f123.Header;

namespace TelemetryViewer.Packets.f123.Status
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct CarStatusData
    {
        public byte m_tractionControl;                 // Controle de tração - 0 = off, 1 = médio, 2 = total
        public byte m_antiLockBrakes;                  // 0 = off, 1 = on
        public byte m_fuelMix;                         // Mistura de combustível - 0 = lean, 1 = standard, 2 = rich, 3 = max
        public byte m_frontBrakeBias;                  // Bias de frenagem frontal (percentual)
        public byte m_pitLimiterStatus;                // Status do limitador de pit - 0 = off, 1 = on
        public float m_fuelInTank;                     // Massa de combustível atual
        public float m_fuelCapacity;                   // Capacidade de combustível
        public float m_fuelRemainingLaps;              // Combustível restante em termos de voltas
        public ushort m_maxRPM;                        // RPM máximo do carro, ponto do limitador de RPM
        public ushort m_idleRPM;                       // RPM em marcha lenta
        public byte m_maxGears;                        // Número máximo de marchas
        public byte m_drsAllowed;                      // 0 = não permitido, 1 = permitido
        public ushort m_drsActivationDistance;         // Distância de ativação do DRS
        public byte m_actualTyreCompound;              // Composto de pneu real
        public byte m_visualTyreCompound;              // Composto de pneu visual
        public byte m_tyresAgeLaps;                    // Idade dos pneus em voltas
        public sbyte m_vehicleFiaFlags;                // Flags FIA do veículo
        public float m_enginePowerICE;                 // Potência do motor ICE (W)
        public float m_enginePowerMGUK;                // Potência do motor MGU-K (W)
        public float m_ersStoreEnergy;                 // Energia armazenada no ERS (Joules)
        public byte m_ersDeployMode;                   // Modo de deploy do ERS, 0 = nenhum, 1 = médio, 2 = hotlap, 3 = overtake
        public float m_ersHarvestedThisLapMGUK;       // Energia colhida no ERS nesta volta por MGU-K
        public float m_ersHarvestedThisLapMGUH;       // Energia colhida no ERS nesta volta por MGU-H
        public float m_ersDeployedThisLap;            // Energia do ERS usada nesta volta
        public byte m_networkPaused;                   // Se o carro está pausado em um jogo online
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PacketCarStatusData
    {
        public PacketHeader m_header;                            // Cabeçalho
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
        public CarStatusData[] m_carStatusData;                   // Dados de status para até 22 carros
    }
}
