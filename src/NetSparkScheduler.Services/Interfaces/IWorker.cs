namespace NetSparkScheduler.Services.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IWorker
    {
        Task RunAsync();
    }
}
