using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetSparkScheduler.Services;
using NetSparkScheduler.Services.Interfaces;
using NetSparkScheduler.Services.Workers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetSparkScheduler.Worker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureHostConfiguration( builder => 
                {
                   
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Scheduler>();
                    DependencyInjection(services);
                });

        private static void DependencyInjection(IServiceCollection services)
        {
            services.AddSingleton<IKubernetesConfiguration, KubernetesConfiguration>();
            services.AddSingleton<IClusterClient, KubernetesClient>();
            services.AddSingleton<ISchedulerService, SchedulerService>();
            services.AddSingleton<IControllerService, ControllerService>();
            services.AddSingleton<IAdmissionService, AdmissionService>();
            services.AddSingleton<ISubscriber, KafkaSubscriber>();
        }
    }
}
