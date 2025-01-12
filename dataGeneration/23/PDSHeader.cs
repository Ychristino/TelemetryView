using System;
using System.Globalization;
using System.IO;
using TelemetryViewer.Packets.f123.Header; // Alterado para o namespace f123.Header

namespace TelemetryViewer.GeneratePDS.f123.Header
{
    public class PDSPacketHeaderData : PDSExport<PacketHeader>
    {
        public override void ExportToPds(PacketHeader packetData, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Escrever o cabeçalho do arquivo CSV
                writer.WriteLine("\n# Packet Header Data (F123)"); // Atualizado para F123
                writer.WriteLine("# Columns: Packet Format, Game Year, Game Version (Major.Minor), Packet Version, Packet ID, Session UID, Session Time, Frame Identifier, Overall Frame Identifier, Player Car Index, Secondary Player Car Index");

                // Processar os dados do cabeçalho e exportar para o CSV
                writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                    "{0}, {1}, {2}.{3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}",
                    packetData.PacketFormat,
                    packetData.GameYear,
                    packetData.GameMajorVersion,
                    packetData.GameMinorVersion,
                    packetData.PacketVersion,
                    packetData.PacketId,
                    packetData.SessionUID,
                    packetData.SessionTime,
                    packetData.FrameIdentifier,
                    packetData.OverallFrameIdentifier,
                    packetData.PlayerCarIndex,
                    packetData.SecondaryPlayerCarIndex));
            }

            Console.WriteLine($"PacketHeaderData F123 Sucesso: {filePath}");
        }
    }
}
