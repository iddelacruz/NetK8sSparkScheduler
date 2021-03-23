namespace NetSparkScheduler.Services
{
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public sealed class SchedulerService : ISchedulerService
    {
        private readonly IClusterClient cluster;

        public SchedulerService(IClusterClient cluster)
        {
            this.cluster = cluster;
        }

        public async Task<bool> ScheduleAsync(string message)
        {
            try
            {
                await this.cluster.SubmitSparkJobAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
            throw new NotImplementedException();
        }
    }
}
