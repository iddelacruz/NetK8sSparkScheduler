namespace NetSparkScheduler.Services.Interfaces
{
    using Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IClusterClient
    {
        Task<Metric> GetPodsMetricsAsync(string namspaceName);

        Task<IEnumerable<Pod>> GetNamespacedPodAsync(string namespaceName);

        Task SubmitSparkJobAsync();

        Task DeletePodAsync(Pod pod, string namespaceName);
    }
}
