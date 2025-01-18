using System;
using System.Globalization;
using System.IO;
using TelemetryViewer.Dicts.f122.Nationality;
using TelemetryViewer.Dicts.f122.Team;
using TelemetryViewer.Packets.f122.Lobby; // Alterado para o namespace f122

namespace TelemetryViewer.GeneratePDS.f122.Lobby
{
    public class PDSLobbyInfo : PDSExport<PacketLobbyInfo>
    {
        public override void ExportPdsHeader(string filePath){
            using (StreamWriter writer = new StreamWriter(filePath, append: true))
            {
                // Escrever o cabeçalho do arquivo CSV
                writer.WriteLine("\n# Lobby Info Data (F122)"); // Alterado para F122
                writer.WriteLine("# Columns: AI Controlled, Team ID, Nationality, Name, Car Number, Ready Status");
            }
        }
        public override void ExportToPds(PacketLobbyInfo packetData, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath, append: true))
            {
                // Escrever os dados dos jogadores
                for (int i = 0; i < packetData.m_numPlayers; i++)
                {
                    var player = packetData.m_lobbyPlayers[i];

                    // Converter o nome do jogador de bytes para uma string UTF-8
                    string playerName = System.Text.Encoding.UTF8.GetString(player.m_name).TrimEnd('\0');

                    // Escrever os dados do jogador no arquivo CSV
                    writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                        "{0}, {1}, {2}, {3}, {4}, {5}",
                        player.m_aiControlled,
                        Team.GetTeamName(player.m_teamId),
                        Nationality.GetNationalityName(player.m_nationality),
                        playerName,
                        player.m_carNumber,
                        player.m_readyStatus
                    ));
                }
            }

            Console.WriteLine($"PacketLobbyInfoData F122 Sucesso: {filePath}");
        }
    }
}
