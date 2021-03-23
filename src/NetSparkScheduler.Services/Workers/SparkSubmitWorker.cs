namespace NetSparkScheduler.Services.Workers
{
    using Interfaces;
    using System;
    using System.Threading.Tasks;

    public sealed class SparkSubmitWorker : IWorker
    {
        private readonly ISubscriber subscriber;
        private readonly IAdmissionService admission;
        private readonly IControllerService controller;
        private readonly ISchedulerService scheduler;

        public SparkSubmitWorker(ISubscriber subscriber, 
            IAdmissionService admission, 
            IControllerService controller, 
            ISchedulerService scheduler)
        {
            this.subscriber = subscriber;
            this.admission = admission;
            this.controller = controller;
            this.scheduler = scheduler;
        }
        public async Task RunAsync()
        {
            try
            {
                while (true)
                {
                    var element = await this.subscriber.GiveMeAnElementAsync();

                    if (!string.IsNullOrWhiteSpace(element))
                    {
                        if (await this.admission.ValidateThisMessageAsync(element) 
                            && await this.controller.ThisItemCanBeScheduledAsync(element))
                        {
                            await this.scheduler.ScheduleAsync(element);
                            await this.subscriber.CompleteAync();
                            await Task.Delay(1000);
                        }
                    }
                    else
                    {
                        await Task.Delay(6000);
                    }
                }
            }
            catch (Exception)
            {
                await this.subscriber.RollbackAsync();
                throw;
            }
        }
    }
}
