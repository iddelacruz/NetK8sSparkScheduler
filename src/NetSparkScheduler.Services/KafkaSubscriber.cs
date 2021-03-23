namespace NetSparkScheduler.Services
{
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public class KafkaSubscriber : ISubscriber
    {

        public Task<string> GiveMeAnElementAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> CompleteAync()
        {
            throw new NotImplementedException();
        }

        public Task RollbackAsync()
        {
            throw new NotImplementedException();
        }
    }
}
