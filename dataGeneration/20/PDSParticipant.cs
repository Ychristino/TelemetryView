using System;
using System.Globalization;
using System.IO;
using TelemetryViewer.Packets.f120.Participant;

namespace TelemetryViewer.GeneratePDS.f120.Participant
{
    public class PDSParticipantData : PDSExport<PacketParticipantsData>  // Agora herda de PDSExport<PacketParticipantsData>
    {
        public override void ExportToPds(PacketParticipantsData participantsData, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Escrever a seção de participantes
                writer.WriteLine("# Participant Data");
                writer.WriteLine("# Columns: Driver ID, Team ID, Race Number, Nationality, Name, Telemetry");

                // Iterar por todos os participantes
                for (int i = 0; i < participantsData.m_numActiveCars; i++)
                {
                    var participant = participantsData.m_participants[i];

                    // Escrever os dados de cada participante
                    string name = System.Text.Encoding.UTF8.GetString(participant.m_name).TrimEnd('\0');
                    writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                        "{0}, {1}, {2}, {3}, {4}, {5}",
                        participant.m_driverId,
                        participant.m_teamId,
                        participant.m_raceNumber,
                        participant.m_nationality,
                        name,
                        participant.m_yourTelemetry == 1 ? "Public" : "Restricted"
                    ));
                }
            }

            Console.WriteLine($"Dados dos participantes exportados para: {filePath}");
        }
    }
}
