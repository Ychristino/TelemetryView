using System;
using System.Globalization;
using System.IO;
using TelemetryViewer.Packets.f123.Participants;

namespace TelemetryViewer.GeneratePDS.f123.Participants
{
    public class PDSParticipantsData : PDSExport<PacketParticipantsData>
    {
        public override void ExportToPds(PacketParticipantsData packetData, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Escrever o cabeçalho do arquivo CSV
                writer.WriteLine("\n# Participants Data (F123)"); // Atualizado para F123
                writer.WriteLine("# Columns: Car Number, Driver ID, Network ID, Team ID, My Team, Nationality, Name, Telemetry Setting, Show Online Names, Platform");

                // Processar os dados dos participantes
                for (int i = 0; i < packetData.m_participants.Length; i++)
                {
                    var participant = packetData.m_participants[i];

                    // Verificar se o participante está ativo
                    if (i < packetData.m_numActiveCars)
                    {
                        // Convertendo o nome do participante (char[] para string)
                        string participantName = new string(participant.m_name).TrimEnd('\0');

                        // Escrever as informações do participante no arquivo CSV
                        writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                            "{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}",
                            participant.m_raceNumber, // Número de corrida do carro
                            participant.m_driverId,   // ID do piloto
                            participant.m_networkId,  // ID da rede do jogador
                            participant.m_teamId,     // ID do time
                            participant.m_myTeam,     // Se é o meu time
                            participant.m_nationality, // Nacionalidade do piloto
                            participantName,          // Nome do participante
                            participant.m_yourTelemetry, // Telemetria pública (0 = restrito, 1 = público)
                            participant.m_showOnlineNames, // Exibir nomes online (0 = off, 1 = on)
                            participant.m_platform    // Plataforma (1 = Steam, 3 = PlayStation, 4 = Xbox, 6 = Origin, 255 = desconhecido)
                        ));
                    }
                }
            }

            Console.WriteLine($"ParticipantsData F123 Sucesso: {filePath}");
        }
    }
}
