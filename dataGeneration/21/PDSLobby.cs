using System;
using System.Globalization;
using System.IO;
using System.Text;
using TelemetryViewer.Packets.f121.LobbyInfo;

namespace TelemetryViewer.GeneratePDS.f121.LobbyInfo
{
    public class PDSLobbyInfo : PDSExport<PacketLobbyInfoData>
    {
        public override void ExportToPds(PacketLobbyInfoData packetData, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Escrever o cabeçalho do arquivo CSV
                writer.WriteLine("\n# Lobby Info (F121)");
                writer.WriteLine("# Columns: AI Controlled, Team ID, Nationality, Name, Ready Status");

                // Escrever os dados de cada jogador no lobby
                foreach (var player in packetData.m_lobbyPlayers)
                {
                    // Converter o nome de bytes para uma string UTF-8
                    string playerName = Encoding.UTF8.GetString(player.m_name).TrimEnd('\0');

                    writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                        "{0}, {1}, {2}, \"{3}\", {4}",
                        player.m_aiControlled,
                        player.m_teamId,
                        player.m_nationality,
                        playerName,
                        player.m_readyStatus
                    ));
                }
            }

            Console.WriteLine($"LobbyInfo F121 Exportado com sucesso: {filePath}");
        }
    }
}
