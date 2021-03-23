namespace NetSparkScheduler.Services
{
    using Interfaces;
    using k8s;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using System.Linq;
    using Models;
    using k8s.Models;

    public sealed class KubernetesClient : IClusterClient
    {
        private readonly IKubernetes client;

        public KubernetesClient(IKubernetesConfiguration config)
        {
            this.client = new Kubernetes(config.BuildConfigFromConfigFile());
        }

        public async Task DeletePodAsync(Pod pod, string namespaceName)
        {
            var result = await this.client.DeleteNamespacedPodAsync(pod.Name, namespaceName);        
        }

        public Task<IEnumerable<Pod>> GetNamespacedPodAsync(string namespaceName)
        {
            throw new NotImplementedException();
        }

        public async Task<Metric> GetPodsMetricsAsync(string namespaceName)
        {
            var podsMetrics = await this.client
                .GetKubernetesPodsMetricsByNamespaceAsync(namespaceName)
                .ConfigureAwait(false);

            uint memory = 0;
            uint cpu = 0;

            if (podsMetrics.Items.Any())
            {
                var resources = podsMetrics.Items
                    .SelectMany(x => x.Containers)
                    .Select(x => x.Usage);

                foreach (var item in resources)
                {
                    if (item.ContainsKey("cpu"))
                    {
                        
                    }
                    else
                    {

                    }
                }       
            }
            return new Metric(namespaceName, memory, cpu);
        }

        public Task SubmitSparkJobAsync()
        {
            throw new NotImplementedException();
        }
    }
}
