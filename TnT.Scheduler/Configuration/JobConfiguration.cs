using System;
using TnT.Scheduler.Trigger;

namespace TnT.Scheduler.Configuration
{
    public class JobConfiguration<TJob> : IJobConfiguration<TJob>
        where TJob : IJob
    {
        private readonly JobSetup setup;

        public JobConfiguration()
        {
            this.setup = new JobSetup();
        }

        public Guid SetupJob(TnT.Scheduler.Scheduler scheduler)
        {
            return scheduler.AddJob<TJob>(this.setup);
        }

        public IJobConfiguration<TJob> UseTrigger(ITrigger trigger)
        {
            this.setup.Trigger = trigger;
            return this;
        }

        public IJobConfiguration<TJob> Setup(Action<JobSetup> action)
        {
            action(this.setup);

            return this;
        }

        public IJobConfiguration<TJob> WithParameter(object parameter)
        {
            this.setup.Parameter = parameter;
            return this;
        }
    }
}