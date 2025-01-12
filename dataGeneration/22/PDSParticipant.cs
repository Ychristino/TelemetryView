using System;
using System.Globalization;
using System.IO;
using TelemetryViewer.Packets.f122.Participants; // Alterado para o namespace f122.Participants

namespace TelemetryViewer.GeneratePDS.f122.Participants
{
    public class PDSParticipantData : PDSExport<PacketParticipantsData>
    {
        public override void ExportToPds(PacketParticipantsData packetData, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Escrever o cabeçalho do arquivo CSV
                writer.WriteLine("\n# Participant Data (F122)"); // Alterado para F122
                writer.WriteLine("# Columns: Car Number, AI Controlled, Driver ID, Network ID, Team ID, " +
                                 "My Team, Nationality, Name, Your Telemetry");

                // Escrever os dados dos participantes (até 22 carros)
                for (int i = 0; i < packetData.m_numActiveCars; i++)
                {
                    var participant = packetData.m_participants[i];

                    // Converter o nome do participante para uma string
                    string name = new string(participant.m_name).TrimEnd('\0');

                    // Escrever os dados do participante no arquivo CSV
                    writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                        "{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}",
                        participant.m_raceNumber,
                        participant.m_aiControlled,
                        participant.m_driverId,
                        participant.m_networkId,
                        participant.m_teamId,
                        participant.m_myTeam,
                        participant.m_nationality,
                        name,
                        participant.m_yourTelemetry
                    ));
                }
            }

            Console.WriteLine($"PacketParticipantsData F122 Sucesso: {filePath}");
        }
    }
}
