namespace NetSparkScheduler.Services.Interfaces
{
    using k8s;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public interface IKubernetesConfiguration
    {
        KubernetesClientConfiguration BuildConfigFromConfigFile();
    }
}
