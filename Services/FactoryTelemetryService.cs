using EaproERP.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace EaproERP.Services
{
    public class FactoryTelemetryService : BackgroundService
    {
        private readonly IHubContext<FactoryHub> _hubContext;
        private readonly Random _random = new();

        public FactoryTelemetryService(IHubContext<FactoryHub> _hubContext)
        {
            this._hubContext = _hubContext;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                // 1. Simulate IIoT Data (In reality, read from MQTT here)
                var telemetryData = new
                {
                    machineId = "UNIT_04_PCU_TESTER",
                    temp = _random.Next(38, 52), // PCU Testing temperature
                    thd = _random.NextDouble() * (2.5 - 1.1) + 1.1, // Sine wave purity (THD %)
                    load = _random.Next(75, 95),
                    timestamp = DateTime.Now.ToString("HH:mm:ss")
                };

                // 2. Broadcast to all open Titan OS Dashboards via SignalR
                await _hubContext.Clients.All.SendAsync("ReceiveTelemetry", telemetryData);

                // 3. Heartbeat frequency: Update every 2 seconds
                await Task.Delay(2000, stoppingToken);
            }
        }
    }
}