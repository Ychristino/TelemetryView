using System;
using System.Runtime.InteropServices;
using TelemetryViewer.Packets.f123.Header;

namespace TelemetryViewer.Packets.f123.Lobby
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct LobbyInfoData
    {
        public byte m_aiControlled;      // Se o veículo é controlado por IA (1) ou Humano (0)
        public byte m_teamId;            // ID do time - veja o apêndice (255 se nenhum time estiver selecionado)
        public byte m_nationality;       // Nacionalidade do piloto
        public byte m_platform;          // 1 = Steam, 3 = PlayStation, 4 = Xbox, 6 = Origin, 255 = desconhecido
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)]
        public byte[] m_name;           // Nome do participante em formato UTF-8 – null terminado
        public byte m_carNumber;         // Número do carro do jogador
        public byte m_readyStatus;       // 0 = não pronto, 1 = pronto, 2 = assistindo
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PacketLobbyInfo
    {
        public PacketHeader m_header;         // Cabeçalho
        public byte m_numPlayers;             // Número de jogadores nos dados do lobby
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
        public LobbyInfoData[] m_lobbyPlayers; // Dados dos jogadores no lobby (até 22 jogadores)
    }
}
