using System;
using System.Globalization;
using System.IO;
using System.Text;
using TelemetryViewer.Packets.f120.LobbyInfo;

namespace TelemetryViewer.GeneratePDS.f120.LobbyInfo
{
    public class PDSLobbyInfo : PDSExport<PacketLobbyInfoData> // Herda de PDSExport<PacketLobbyInfoData>
    {
        public override void ExportToPds(PacketLobbyInfoData lobbyInfoData, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Escrever a seção de dados de lobby
                writer.WriteLine("# Lobby Information");
                writer.WriteLine("# Columns: Player Name, AI Controlled, Team ID, Nationality, Ready Status");

                // Iterar por todos os jogadores
                for (int i = 0; i < lobbyInfoData.m_numPlayers; i++)
                {
                    var playerData = lobbyInfoData.m_lobbyPlayers[i];

                    // Converter nome de jogador para string
                    string playerName = Encoding.UTF8.GetString(playerData.m_name).TrimEnd('\0');

                    // Escrever os dados de cada jogador
                    writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                        "{0}, {1}, {2}, {3}, {4}",
                        playerName,
                        playerData.m_aiControlled,
                        playerData.m_teamId,
                        playerData.m_nationality,
                        playerData.m_readyStatus
                    ));
                }
            }

            Console.WriteLine($"Dados de lobby exportados para: {filePath}");
        }
    }
}
