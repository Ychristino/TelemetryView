using System;
using System.Runtime.InteropServices;
using TelemetryViewer.Packets.f121.Header;

namespace TelemetryViewer.Packets.f121.LobbyInfo
{
    // Structure for Lobby Info Data
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct LobbyInfoData
    {
        public byte m_aiControlled;    // Whether the vehicle is AI (1) or Human (0) controlled
        public byte m_teamId;          // Team id - see appendix (255 if no team currently selected)
        public byte m_nationality;     // Nationality of the driver

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)]
        public byte[] m_name;          // Name of participant in UTF-8 format – null terminated
                                      // Will be truncated with ... (U+2026) if too long
        public byte m_readyStatus;     // 0 = not ready, 1 = ready, 2 = spectating
    }

    // Structure for Packet Lobby Info Data
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PacketLobbyInfoData
    {
        public PacketHeader m_header;  // Header
        public byte m_numPlayers;      // Number of players in the lobby data

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
        public LobbyInfoData[] m_lobbyPlayers;  // Lobby player data for up to 22 players
    }
}
