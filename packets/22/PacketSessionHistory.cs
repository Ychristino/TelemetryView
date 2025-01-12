using System;
using System.Runtime.InteropServices;
using TelemetryViewer.Packets.f122.Header;

namespace TelemetryViewer.Packets.f122.SessionHistory
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct LapHistoryData
    {
        public uint m_lapTimeInMS;          // Tempo da volta em milissegundos
        public ushort m_sector1TimeInMS;    // Tempo do setor 1 em milissegundos
        public ushort m_sector2TimeInMS;    // Tempo do setor 2 em milissegundos
        public ushort m_sector3TimeInMS;    // Tempo do setor 3 em milissegundos
        public byte m_lapValidBitFlags;     // Flags de validade da volta e setores (0x01 = volta válida, 0x02 = setor 1 válido, etc.)
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct TyreStintHistoryData
    {
        public byte m_endLap;               // Volta em que o uso do pneu termina (255 se for o pneu atual)
        public byte m_tyreActualCompound;   // Pneus reais usados por este piloto
        public byte m_tyreVisualCompound;   // Pneus visuais usados por este piloto
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PacketSessionHistoryData
    {
        public PacketHeader m_header;                      // Cabeçalho
        public byte m_carIdx;                               // Índice do carro a que os dados da volta se referem
        public byte m_numLaps;                              // Número de voltas nos dados (incluindo a volta parcial atual)
        public byte m_numTyreStints;                        // Número de stints de pneus nos dados
        public byte m_bestLapTimeLapNum;                    // Volta em que o melhor tempo de volta foi alcançado
        public byte m_bestSector1LapNum;                    // Volta em que o melhor tempo do setor 1 foi alcançado
        public byte m_bestSector2LapNum;                    // Volta em que o melhor tempo do setor 2 foi alcançado
        public byte m_bestSector3LapNum;                    // Volta em que o melhor tempo do setor 3 foi alcançado

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 100)]
        public LapHistoryData[] m_lapHistoryData;           // Dados das últimas 100 voltas (máximo)

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public TyreStintHistoryData[] m_tyreStintsHistoryData; // Dados históricos de stints de pneus (máximo de 8)
    }
}
