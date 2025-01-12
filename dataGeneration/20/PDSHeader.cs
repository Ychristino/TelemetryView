using System;
using System.Globalization;
using System.IO;
using TelemetryViewer.Packets.f120.Header;

namespace TelemetryViewer.GeneratePDS.f120.Header
{
    public class PDSHeader : PDSExport<PacketHeader> // Herda de PDSExport<PacketHeader>
    {
        public override void ExportToPds(PacketHeader headerData, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Escrever a seção de cabeçalho
                writer.WriteLine("# Packet Header Data");
                writer.WriteLine("# Columns: Packet Format, Game Version, Packet Version, Packet ID, Session UID, Session Time, Frame Identifier, Player Car Index, Secondary Player Car Index");

                // Escrever os dados do cabeçalho
                writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                    "{0}, {1}.{2}, {3}, {4}, {5}, {6:F3}, {7}, {8}, {9}",
                    headerData.m_packetFormat,
                    headerData.m_gameMajorVersion,
                    headerData.m_gameMinorVersion,
                    headerData.m_packetVersion,
                    headerData.m_packetId,
                    headerData.m_sessionUID,
                    headerData.m_sessionTime,
                    headerData.m_frameIdentifier,
                    headerData.m_playerCarIndex,
                    headerData.m_secondaryPlayerCarIndex
                ));
            }

            Console.WriteLine($"Dados do cabeçalho exportados para: {filePath}");
        }
    }
}
