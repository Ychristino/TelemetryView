using System;
using System.Globalization;
using System.IO;
using System.Text;
using TelemetryViewer.Dicts.f121.Nationality;
using TelemetryViewer.Dicts.f121.Team;
using TelemetryViewer.Packets.f121.LobbyInfo;

namespace TelemetryViewer.GeneratePDS.f121.LobbyInfo
{
    public class PDSLobbyInfo : PDSExport<PacketLobbyInfo>
    {
        public override void ExportPdsHeader(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath, append: true))
            {
                // Escrever o cabeçalho do arquivo CSV
                writer.WriteLine("\n# Lobby Info (F121)");
                writer.WriteLine("# Columns: AI Controlled, Team ID, Nationality, Name, Ready Status");
            }
        }
        public override void ExportToPds(PacketLobbyInfo packetData, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath, append: true))
            {
                // Escrever os dados de cada jogador no lobby
                foreach (var player in packetData.m_lobbyPlayers)
                {
                    // Converter o nome de bytes para uma string UTF-8
                    string playerName = Encoding.UTF8.GetString(player.m_name).TrimEnd('\0');

                    writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                        "{0}, {1}, {2}, \"{3}\", {4}",
                        player.m_aiControlled,
                        Team.GetTeamName(player.m_teamId),
                        Nationality.GetNationalityName(player.m_nationality),
                        playerName,
                        player.m_readyStatus
                    ));
                }
            }

            Console.WriteLine($"LobbyInfo F121 Exportado com sucesso: {filePath}");
        }
    }
}
