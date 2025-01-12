using System;
using System.Runtime.InteropServices;
using TelemetryViewer.Packets.f122.Header;

namespace TelemetryViewer.Packets.f122.Classification
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct FinalClassificationData
    {
        public byte m_position;                    // Posição final
        public byte m_numLaps;                     // Número de voltas completadas
        public byte m_gridPosition;                // Posição de largada do carro
        public byte m_points;                      // Número de pontos ganhos
        public byte m_numPitStops;                 // Número de pit stops realizados
        public byte m_resultStatus;                // Status do resultado - 0 = inválido, 1 = inativo, 2 = ativo, 3 = terminou, 4 = não terminou, 5 = desqualificado, 6 = não classificado, 7 = retirado
        public uint m_bestLapTimeInMS;             // Melhor tempo de volta da sessão em milissegundos
        public double m_totalRaceTime;             // Tempo total de corrida em segundos sem penalidades
        public byte m_penaltiesTime;               // Tempo total de penalidades acumuladas em segundos
        public byte m_numPenalties;                // Número de penalidades aplicadas ao piloto
        public byte m_numTyreStints;               // Número de stint de pneus (máximo de 8)
        
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] m_tyreStintsActual;          // Pneus reais usados por este piloto

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] m_tyreStintsVisual;          // Pneus visuais usados por este piloto

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] m_tyreStintsEndLaps;         // Número da volta em que o stint de pneus terminou
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PacketFinalClassificationData
    {
        public PacketHeader m_header;                      // Cabeçalho
        public byte m_numCars;                              // Número de carros na classificação final

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
        public FinalClassificationData[] m_classificationData; // Dados de classificação para até 22 carros
    }
}
