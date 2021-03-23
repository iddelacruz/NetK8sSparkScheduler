namespace NetSparkScheduler.Services.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;


    public interface IAdmissionService
    {
        Task<bool> ValidateThisMessageAsync(string message);
    }
}
