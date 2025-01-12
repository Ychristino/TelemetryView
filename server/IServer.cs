namespace TelemetryViewer
{
    public interface IServer
    {
        void Start(string hostIp, int port, CancellationToken cancellationToken);
    }
}
