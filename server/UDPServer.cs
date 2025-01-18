using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using TelemetryViewer.Packets.f120.Header;
using TelemetryViewer.Dicts.f120.PacketInfo;
using TelemetryViewer.Packets;

namespace TelemetryViewer.Server
{
    public class UDPServer : IServer
    {
        private CancellationToken _cancellationToken;

        public void Start(string hostIp, int port, CancellationToken cancellationToken)
        {
            _cancellationToken = cancellationToken;
            var hostAddress = IPAddress.Parse(hostIp);
            var udpClient = new UdpClient(new IPEndPoint(hostAddress, port));

            Console.WriteLine($"UDP Server started on {hostAddress}:{port}");

            var remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
            byte[] buffer;

            try
            {
                while (!_cancellationToken.IsCancellationRequested)
                {
                    if (udpClient.Available > 0)
                    {
                        buffer = udpClient.Receive(ref remoteEndPoint);

                        // Deserializar o PacketHeader
                        var packetHeader = Packet.DeserializePacket<PacketHeader>(buffer);

                        // Imprimir o conteúdo do PacketHeader
                        Console.WriteLine($"-------------------------------- BEGIN PACKET --------------------------------");
                        Console.WriteLine("Received Packet Header:");
                        Packet.PrintPacketHeader(packetHeader);
                        Console.WriteLine("");

                        try{
                            var packetInfo = PacketInfo.GetPacketInfo(packetHeader.m_packetId);
                            var packetReceived = Packet.DeserializePacketDynamic(buffer, packetInfo.StructureType);
                            Console.WriteLine($"Packet Header Version: {packetInfo.StructureType}");
                            Packet.WriteFile(packetReceived, packetInfo.PDSWrite);

                            if (packetReceived != null){
                                Console.WriteLine($"Received Packet {packetInfo.Name}:");
                                Packet.PrintPacketDetails(packetReceived);
                            }
                            else{
                                Console.WriteLine($"Nullable Package Received!");
                            }
                        }
                        catch(ArgumentOutOfRangeException ex){
                            Console.WriteLine($"Packet Discard. {ex.Message}");
                        }
                        catch(ArgumentNullException ex){
                            Console.WriteLine($"Packet Discard. {ex.Message}");
                        }
                        Console.WriteLine($"--------------------------------- END PACKET ---------------------------------");

                        // sendMessage(udpClient, "ack\n", remoteEndPoint.Address.ToString(), remoteEndPoint.Port);
                    }
                    else
                    {
                        Thread.Sleep(10);
                    }
                }
            }
            catch (SocketException ex) when (_cancellationToken.IsCancellationRequested)
            {
                Console.WriteLine($"UDP Server shutting down gracefully. {ex}");
            }
            catch(Exception ex){
                Console.WriteLine($"STOP: {ex}");
            }
            finally
            {
                udpClient.Close();
                Console.WriteLine("UDP Server stopped.");
            }
        }

        private void sendMessage(UdpClient udpClient, string message, string ipAddress, int port){
            byte[] responseBytes = Encoding.UTF8.GetBytes(message);
            udpClient.Send(responseBytes, responseBytes.Length, ipAddress, port);
        }
    }
}
