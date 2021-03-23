namespace NetSparkScheduler.Services.Workers
{
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using System.Linq;
    using Models;
    using Microsoft.Extensions.Configuration;

    public sealed class ResourceCleanerWorker : IWorker
    {
        private readonly IClusterClient cluster;
        private readonly IConfiguration configuration;

        public ResourceCleanerWorker(IClusterClient cluster, IConfiguration configuration)
        {
            this.cluster = cluster;
            this.configuration = configuration;
        }
        public async Task RunAsync()
        {
            //cargar el nombre del namespace desde un archivo de configuracion
            var namespaceName = "namespace";
            try
            {
                while (true)
                {
                    var pods = await this.cluster.GetNamespacedPodAsync(namespaceName);
                    foreach (var pod in pods.Where(x => x.Status == Status.Completed))
                    {
                        await this.cluster.DeletePodAsync(pod, namespaceName);
                    }
                    await Task.Delay(30000);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
