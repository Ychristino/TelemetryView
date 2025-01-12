using System;
using System.Runtime.InteropServices;
using TelemetryViewer.Packets.f123.Header;

namespace TelemetryViewer.Packets.f123.TyreSets
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct TyreSetData
    {
        public byte m_actualTyreCompound;       // Composto real do pneu utilizado
        public byte m_visualTyreCompound;       // Composto visual do pneu utilizado
        public byte m_wear;                      // Desgaste do pneu (percentagem)
        public byte m_available;                // Se este conjunto está disponível (1 = disponível, 0 = não disponível)
        public byte m_recommendedSession;       // Sessão recomendada para este conjunto de pneus
        public byte m_lifeSpan;                 // Voltas restantes neste conjunto de pneus
        public byte m_usableLife;               // Número máximo de voltas recomendadas para este composto
        public short m_lapDeltaTime;            // Tempo de delta de volta em milissegundos comparado ao conjunto montado
        public byte m_fitted;                   // Se o conjunto está montado ou não (1 = montado, 0 = não montado)
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PacketTyreSetsData
    {
        public PacketHeader m_header;           // Cabeçalho
        public byte m_carIdx;                   // Índice do carro ao qual os dados se referem
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public TyreSetData[] m_tyreSetData;    // Dados de até 20 conjuntos de pneus (13 secos + 7 molhados)
        public byte m_fittedIdx;                // Índice no array do pneu montado
    }
}
