using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace TelemetryViewer.Server
{
    public class TCPServer : IServer
    {
        public void Start(string hostIp, int port, CancellationToken cancellationToken)
        {
            var hostAddress = IPAddress.Parse(hostIp);
            var tcpListener = new TcpListener(hostAddress, port);
            tcpListener.Start();

            Console.WriteLine($"TCP Server started on {hostAddress}:{port}");

            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    if (!tcpListener.Pending())
                    {
                        Thread.Sleep(100);
                        continue;
                    }

                    using TcpClient client = tcpListener.AcceptTcpClient();
                    Console.WriteLine("Client connected.");

                    var tcpStream = client.GetStream();
                    byte[] buffer = new byte[256];
                    StringBuilder messageBuilder = new StringBuilder();
                    int bytesRead;

                    while (!cancellationToken.IsCancellationRequested &&
                           (bytesRead = tcpStream.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        string incomingMessage = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                        messageBuilder.Append(incomingMessage);

                        while (messageBuilder.ToString().Contains("\n"))
                        {
                            var fullMessage = messageBuilder.ToString();
                            var delimiterIndex = fullMessage.IndexOf('\n');
                            var completeMessage = fullMessage.Substring(0, delimiterIndex);

                            Console.WriteLine($"User Said: {completeMessage}");

                            messageBuilder.Remove(0, delimiterIndex + 1);

                            string response = "ack\n";
                            byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                            tcpStream.Write(responseBytes, 0, responseBytes.Length);
                        }
                    }
                }
            }
            catch (SocketException ex) when (cancellationToken.IsCancellationRequested)
            {
                Console.WriteLine($"TCP Server shutting down gracefully. {ex}");
            }
            finally
            {
                tcpListener.Stop();
                Console.WriteLine("TCP Server stopped.");
            }
        }
    }
}
