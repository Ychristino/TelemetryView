using System;
using System.Runtime.InteropServices;
using TelemetryViewer.Packets.f123.Header;

namespace TelemetryViewer.Packets.f123.SessionHistory
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct LapHistoryData
    {
        public uint m_lapTimeInMS;                // Tempo da volta em milissegundos
        public ushort m_sector1TimeInMS;          // Tempo do setor 1 em milissegundos
        public byte m_sector1TimeMinutes;         // Parte do minuto do tempo do setor 1
        public ushort m_sector2TimeInMS;          // Tempo do setor 2 em milissegundos
        public byte m_sector2TimeMinutes;         // Parte do minuto do tempo do setor 2
        public ushort m_sector3TimeInMS;          // Tempo do setor 3 em milissegundos
        public byte m_sector3TimeMinutes;         // Parte do minuto do tempo do setor 3
        public byte m_lapValidBitFlags;           // Flags de validade da volta e setores
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct TyreStintHistoryData
    {
        public byte m_endLap;                     // Lap onde o uso do pneu termina (255 se for o pneu atual)
        public byte m_tyreActualCompound;         // Composto real do pneu usado
        public byte m_tyreVisualCompound;         // Composto visual do pneu usado
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PacketSessionHistory
    {
        public PacketHeader m_header;               // Cabeçalho
        public byte m_carIdx;                       // Índice do carro ao qual os dados dessa volta se referem
        public byte m_numLaps;                      // Número de voltas nos dados (incluindo a volta parcial atual)
        public byte m_numTyreStints;                // Número de estágios de pneus nos dados
        public byte m_bestLapTimeLapNum;            // Número da volta em que o melhor tempo foi alcançado
        public byte m_bestSector1LapNum;            // Número da volta com o melhor tempo do setor 1
        public byte m_bestSector2LapNum;            // Número da volta com o melhor tempo do setor 2
        public byte m_bestSector3LapNum;            // Número da volta com o melhor tempo do setor 3
        
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 100)]
        public LapHistoryData[] m_lapHistoryData;   // Dados de até 100 voltas

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public TyreStintHistoryData[] m_tyreStintsHistoryData;  // Dados de até 8 estágios de pneus
    }
}
