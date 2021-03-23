namespace NetSparkScheduler.Services.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface ISubscriber
    {
        Task<string> GiveMeAnElementAsync();

        Task<bool> CompleteAync();

        Task RollbackAsync();
    }
}
