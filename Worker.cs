using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace TelemetryViewer
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IServer _server;
    
        public Worker(ILogger<Worker> logger, IServer server)
        {
            _logger = logger;
            _server = server;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Starting server...");
            Task.Run(() => _server.Start("26.108.51.74", 20777, stoppingToken), stoppingToken);

            return Task.CompletedTask;
        }
    }
}
