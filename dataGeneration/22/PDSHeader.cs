using System;
using System.Globalization;
using System.IO;
using TelemetryViewer.Packets.f122.Header;

namespace TelemetryViewer.GeneratePDS.f122.Header
{
    public class PDSHeaderData : PDSExport<PacketHeader>
    {
        public override void ExportToPds(PacketHeader packetData, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Escrever o cabeçalho do arquivo CSV
                writer.WriteLine("\n# Packet Header Data (F122)");
                writer.WriteLine("# Columns: Packet Format, Game Version, Packet Version, Packet ID, Session UID, Session Time, Frame ID, Player Car Index, Secondary Player Car Index");

                // Escrever os dados do cabeçalho do pacote
                writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                    "{0}, {1}.{2}, {3}, {4}, {5}, {6}, {7}, {8}",
                    packetData.m_packetFormat,
                    packetData.m_gameMajorVersion,
                    packetData.m_gameMinorVersion,
                    packetData.m_packetVersion,
                    packetData.m_packetId,
                    packetData.m_sessionUID,
                    packetData.m_sessionTime,
                    packetData.m_frameIdentifier,
                    packetData.m_playerCarIndex,
                    packetData.m_secondaryPlayerCarIndex
                ));
            }

            Console.WriteLine($"PacketHeader F122 Sucesso: {filePath}");
        }
    }
}
