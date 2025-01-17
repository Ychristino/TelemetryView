namespace TelemetryViewer.GeneratePDS
{
    public abstract class PDSExport<T>
    {
        public abstract void ExportToPds(T packetData, string filePath);
        public abstract void ExportPdsHeader(string filePath);
    }
}
