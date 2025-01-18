using System;
using System.Runtime.InteropServices;
using TelemetryViewer.Packets.f122.Header;

namespace TelemetryViewer.Packets.f122.CarStatus
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct CarStatusData
    {
        public byte m_tractionControl; // Controle de tração - 0 = desligado, 1 = médio, 2 = total
        public byte m_antiLockBrakes; // Sistema antibloqueio de freios - 0 (desligado), 1 (ligado)
        public byte m_fuelMix; // Mistura de combustível - 0 = lean (pobre), 1 = standard, 2 = rica, 3 = máxima
        public byte m_frontBrakeBias; // Bias de frenagem dianteira (em porcentagem)
        public byte m_pitLimiterStatus; // Status do limitador de pit - 0 = desligado, 1 = ligado
        public float m_fuelInTank; // Massa de combustível atual
        public float m_fuelCapacity; // Capacidade do tanque de combustível
        public float m_fuelRemainingLaps; // Combustível restante em termos de voltas (valor exibido no MFD)
        public ushort m_maxRPM; // RPM máximo do carro, ponto de limite de rotação
        public ushort m_idleRPM; // RPM de marcha lenta do carro
        public byte m_maxGears; // Número máximo de marchas
        public byte m_drsAllowed; // 0 = não permitido, 1 = permitido
        public ushort m_drsActivationDistance; // 0 = DRS não disponível, valor não zero - DRS disponível em [X] metros
        public byte m_actualTyreCompound; // Composto real do pneu
        public byte m_visualTyreCompound; // Composto visual do pneu (pode ser diferente do composto real)
        public byte m_tyresAgeLaps; // Idade em voltas do conjunto atual de pneus
        public sbyte m_vehicleFiaFlags; // -1 = inválido/desconhecido, 0 = nenhum, 1 = verde, 2 = azul, 3 = amarelo, 4 = vermelho
        public float m_ersStoreEnergy; // Energia armazenada do ERS em Joules
        public byte m_ersDeployMode; // Modo de implantação do ERS - 0 = nenhum, 1 = médio, 2 = hotlap, 3 = ultrapassagem
        public float m_ersHarvestedThisLapMGUK; // Energia do ERS recolhida nesta volta pelo MGU-K
        public float m_ersHarvestedThisLapMGUH; // Energia do ERS recolhida nesta volta pelo MGU-H
        public float m_ersDeployedThisLap; // Energia do ERS utilizada nesta volta
        public byte m_networkPaused; // Se o carro está pausado em um jogo online
    };

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PacketCarStatus
    {
        public PacketHeader m_header; // Cabeçalho
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
        public CarStatusData[] m_carStatusData; // Status dos carros, até 22 carros
    };
}
