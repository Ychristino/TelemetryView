using System;
using System.Globalization;
using System.IO;
using System.Text;
using TelemetryViewer.Packets.f121.Participant;

namespace TelemetryViewer.GeneratePDS.f121.Participant
{
    public class PDSParticipant : PDSExport<PacketParticipantsData>
    {
        public override void ExportToPds(PacketParticipantsData packetData, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Escrever o cabeçalho do arquivo CSV
                writer.WriteLine("\n# Participant Data (F121)");
                writer.WriteLine("# Columns: Car Index, AI Controlled, Driver ID, Team ID, Race Number, Nationality, Name, Telemetry Setting");

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
                        participant.m_driverId,
                        participant.m_teamId,
                        participant.m_raceNumber,
                        participant.m_nationality,
                        name,
                        participant.m_yourTelemetry
                    ));
                }
            }

            Console.WriteLine($"Participant Data F121 Exportado com sucesso: {filePath}");
        }
    }
}
