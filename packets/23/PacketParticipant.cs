using System;
using System.Runtime.InteropServices;
using TelemetryViewer.Packets.f123.Header;

namespace TelemetryViewer.Packets.f123.Participants
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ParticipantData
    {
        public byte m_aiControlled;      // 1 se o veículo é controlado pela IA, 0 se controlado por humano
        public byte m_driverId;          // ID do piloto (veja o apêndice), 255 se for um humano na rede
        public byte m_networkId;         // ID único para identificar jogadores na rede
        public byte m_teamId;            // ID do time (veja o apêndice)
        public byte m_myTeam;            // 1 se for meu time, 0 caso contrário
        public byte m_raceNumber;        // Número de corrida do carro
        public byte m_nationality;       // Nacionalidade do piloto
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)]
        public char[] m_name;            // Nome do participante em formato UTF-8, termina com NULL
                                        // Pode ser truncado para "..." se o nome for muito longo
        public byte m_yourTelemetry;     // Configuração de telemetria do jogador, 0 = restrito, 1 = público
        public byte m_showOnlineNames;   // Configuração para exibir nomes online, 0 = off, 1 = on
        public byte m_platform;          // Plataforma do jogador (1 = Steam, 3 = PlayStation, 4 = Xbox, 6 = Origin, 255 = desconhecido)
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PacketParticipants
    {
        public PacketHeader m_header;            // Cabeçalho do pacote
        public byte m_numActiveCars;             // Número de carros ativos na corrida – deve corresponder ao número de carros no HUD
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
        public ParticipantData[] m_participants; // Array de até 22 participantes ativos
    }
}
