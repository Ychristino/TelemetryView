using System;
using System.Globalization;
using System.IO;
using TelemetryViewer.Dicts.f123.Nationality;
using TelemetryViewer.Dicts.f123.Team;
using TelemetryViewer.Packets.f123.Lobby;

namespace TelemetryViewer.GeneratePDS.f123.Lobby
{
    public class PDSLobby : PDSExport<PacketLobbyInfo>
    {
        public override void ExportPdsHeader(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath, append: true))
            {
                // Escrever o cabeçalho do arquivo CSV
                writer.WriteLine("\n# Lobby Info Data (F123)"); // Atualizado para F123
                writer.WriteLine("# Columns: Player Index, AI Controlled, Team ID, Nationality, Platform, Name, Car Number, Ready Status");
            }
        }
        public override void ExportToPds(PacketLobbyInfo packetData, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath, append: true))
            {

                // Processar os dados de jogadores no lobby
                for (int i = 0; i < packetData.m_lobbyPlayers.Length; i++)
                {
                    var player = packetData.m_lobbyPlayers[i];
                    // Ignorar jogadores sem dados (por exemplo, quando o número de jogadores for menor que 22)
                    if (i >= packetData.m_numPlayers)
                        break;

                    // Converter o nome do jogador de UTF-8 para string
                    string playerName = System.Text.Encoding.UTF8.GetString(player.m_name).TrimEnd('\0');

                    writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                        "{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}",
                        i + 1, // Índice do jogador (começando de 1)
                        player.m_aiControlled,
                        Team.GetTeamName(player.m_teamId),
                        Nationality.GetNationalityName(player.m_nationality),
                        player.m_platform,
                        playerName,
                        player.m_carNumber,
                        player.m_readyStatus
                    ));
                }
            }

            Console.WriteLine($"LobbyInfoData F123 Sucesso: {filePath}");
        }
    }
}
