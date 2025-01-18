using System;
using System.Runtime.InteropServices;
using TelemetryViewer.Packets.f122.Header;

namespace TelemetryViewer.Packets.f122.Participants
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ParticipantData
    {
        public byte m_aiControlled; // Se o veículo é controlado pela IA (1) ou pelo jogador humano (0)
        public byte m_driverId; // ID do piloto - veja o apêndice, 255 se for um jogador de rede
        public byte m_networkId; // ID de rede – identificador único para jogadores de rede
        public byte m_teamId; // ID do time - veja o apêndice
        public byte m_myTeam; // Flag do meu time – 1 = Meu Time, 0 = caso contrário
        public byte m_raceNumber; // Número de corrida do carro
        public byte m_nationality; // Nacionalidade do piloto
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)]
        public char[] m_name; // Nome do participante no formato UTF-8 – terminador nulo
        public byte m_yourTelemetry; // Configuração de UDP do jogador, 0 = restrito, 1 = público
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PacketParticipants
    {
        public PacketHeader m_header; // Cabeçalho
        public byte m_numActiveCars; // Número de carros ativos nos dados – deve corresponder ao número de carros no HUD
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
        public ParticipantData[] m_participants; // Dados de todos os participantes, até 22 carros
    }
}
