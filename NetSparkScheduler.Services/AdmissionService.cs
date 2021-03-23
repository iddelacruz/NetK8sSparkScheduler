namespace NetSparkScheduler.Services
{
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public sealed class AdmissionService : IAdmissionService
    {
        public Task<bool> ValidateThisMessageAsync(string message)
        {
            throw new NotImplementedException();
        }
    }
}
