namespace NetSparkScheduler.Services
{
    using Interfaces;
    using Microsoft.Extensions.Configuration;
    using Models;
    using System.Threading.Tasks;

    public sealed class ControllerService : IControllerService
    {
        private readonly IClusterClient cluster;
        private readonly IConfiguration configuration;
        private uint currentMemory;
        private uint currentCPU;

        public ControllerService(IClusterClient cluster, IConfiguration configuration)
        {
            this.cluster = cluster;
            this.configuration = configuration;
        }

        public async Task<bool> ThisItemCanBeScheduledAsync(string message)
        {
            //cargar el nombre del namespace desde un archivo de configuracion
            //Cargar también los parámetros para comparar si el job puede ser programado.
            var namespaceName = "namespace";
            var metric = await this.cluster.GetPodsMetricsAsync(namespaceName);
            UpdateCurrentUsage(metric);
            return ItIsSchedulable(metric);
        }

        private void UpdateCurrentUsage(Metric metric)
        {

        }

        private bool ItIsSchedulable(Metric metric)
        {
            return true;
        }
    }
}
