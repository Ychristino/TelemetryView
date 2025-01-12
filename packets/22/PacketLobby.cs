using System;
using System.Runtime.InteropServices;
using TelemetryViewer.Packets.f122.Header;

namespace TelemetryViewer.Packets.f122.Lobby
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct LobbyInfoData
    {
        public byte m_aiControlled;      // Se o veículo é controlado por IA (1) ou por Humano (0)
        public byte m_teamId;            // ID da equipe (255 se nenhuma equipe selecionada)
        public byte m_nationality;       // Nacionalidade do piloto
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)]
        public byte[] m_name;            // Nome do participante em formato UTF-8 (terminado por nulo)
        public byte m_carNumber;         // Número do carro do jogador
        public byte m_readyStatus;       // 0 = não pronto, 1 = pronto, 2 = assistindo
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PacketLobbyInfoData
    {
        public PacketHeader m_header;         // Cabeçalho
        public byte m_numPlayers;             // Número de jogadores nos dados da sala
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
        public LobbyInfoData[] m_lobbyPlayers; // Dados dos jogadores da sala (até 22 jogadores)
    }
}
