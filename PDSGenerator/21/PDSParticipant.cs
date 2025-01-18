using System;
using System.Globalization;
using System.IO;
using System.Text;
using TelemetryViewer.Dicts.f121.Driver;
using TelemetryViewer.Dicts.f121.Nationality;
using TelemetryViewer.Dicts.f121.Team;
using TelemetryViewer.Packets.f121.Participant;

namespace TelemetryViewer.GeneratePDS.f121.Participant
{
    public class PDSParticipant : PDSExport<PacketParticipants>
    {
        public override void ExportPdsHeader(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath, append: true))
            {
                // Escrever o cabeçalho do arquivo CSV
                writer.WriteLine("\n# Participant Data (F121)");
                writer.WriteLine("# Columns: Car Index, AI Controlled, Driver ID, Team ID, Race Number, Nationality, Name, Telemetry Setting");
            }
        }
        public override void ExportToPds(PacketParticipants packetData, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath, append: true))
            {
                // Escrever os dados de cada participante no pacote
                for (int i = 0; i < packetData.m_participants.Length; i++)
                {
                    var participant = packetData.m_participants[i];

                    // Convertendo o nome para string
                    string name = Encoding.UTF8.GetString(participant.m_name).TrimEnd('\0');

                    writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                        "{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}",
                        i,
                        participant.m_aiControlled,
                        Driver.GetDriverName(participant.m_driverId),
                        Team.GetTeamName(participant.m_teamId),
                        participant.m_raceNumber,
                        Nationality.GetNationalityName(participant.m_nationality),
                        name,
                        participant.m_yourTelemetry
                    ));
                }
            }

            Console.WriteLine($"Participant Data F121 Exportado com sucesso: {filePath}");
        }
    }
}
