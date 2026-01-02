using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ProjectTracker.Business.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectTracker.Business.BackgroundServices
{
    /// <summary>
    /// Background service for creating daily project snapshots
    /// Runs automatically at 23:59 every day
    /// </summary>
    public class SnapshotBackgroundService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<SnapshotBackgroundService> _logger;
        private Timer? _timer;

        public SnapshotBackgroundService(
            IServiceProvider serviceProvider,
            ILogger<SnapshotBackgroundService> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Snapshot Background Service started at {Time}", DateTime.Now);

            // Calculate time until next 23:59
            var now = DateTime.Now;
            var scheduledTime = DateTime.Today.AddHours(23).AddMinutes(59);
            
            // If we're past 23:59 today, schedule for tomorrow
            if (now > scheduledTime)
            {
                scheduledTime = scheduledTime.AddDays(1);
            }

            var firstRunDelay = scheduledTime - now;
            _logger.LogInformation("First snapshot run scheduled for {Time} (in {Delay})", 
                scheduledTime, firstRunDelay);

            // Create timer: first run at calculated delay, then every 24 hours
            _timer = new Timer(
                async _ => await CreateSnapshotsAsync(stoppingToken),
                null,
                firstRunDelay,
                TimeSpan.FromDays(1));

            return Task.CompletedTask;
        }

        private async Task CreateSnapshotsAsync(CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
                return;

            _logger.LogInformation("Starting daily snapshot creation at {Time}", DateTime.Now);

            try
            {
                // Create a scope to resolve scoped services
                using var scope = _serviceProvider.CreateScope();
                var reportService = scope.ServiceProvider.GetRequiredService<IAdvancedReportService>();

                // Execute snapshot creation
                var snapshotsCreated = await reportService.CreateDailySnapshotsAsync();

                _logger.LogInformation(
                    "Daily snapshot creation completed. Created {Count} snapshots at {Time}",
                    snapshotsCreated, DateTime.Now);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating daily snapshots at {Time}", DateTime.Now);
            }
        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Snapshot Background Service is stopping at {Time}", DateTime.Now);

            _timer?.Change(Timeout.Infinite, 0);
            _timer?.Dispose();

            await base.StopAsync(cancellationToken);
        }

        public override void Dispose()
        {
            _timer?.Dispose();
            base.Dispose();
        }
    }
}
