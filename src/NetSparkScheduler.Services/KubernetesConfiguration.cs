namespace NetSparkScheduler.Services
{
    using k8s;
    using NetSparkScheduler.Services.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public sealed class KubernetesConfiguration : IKubernetesConfiguration
    {
        public KubernetesClientConfiguration BuildConfigFromConfigFile()
        {
            return KubernetesClientConfiguration.BuildConfigFromConfigFile();
        }
    }
}
