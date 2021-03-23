using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NetSparkScheduler.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NetSparkScheduler.Worker
{
    public class Scheduler : BackgroundService
    {
        private readonly ILogger<Scheduler> logger;

        public Scheduler(ILogger<Scheduler> logger)
        {
            this.logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            this.logger.LogInformation($"Scheduler running at: {DateTimeOffset.Now}");
            await BackgroundProcessing(stoppingToken);
        }

        private async Task BackgroundProcessing(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {

                }
                catch (Exception ex)
                {
                    this.logger.LogError(ex.Message);
                }
            }
        }
    }
}
