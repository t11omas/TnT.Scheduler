using System;

namespace TnT.Scheduler.Configuration
{
    public static class SchedulerExtensions
    {
        public static Guid AddJob<T>(this TnT.Scheduler.Scheduler @this, Action<IJobConfiguration<T>> configure)
            where T : IJob
        {
            var cfg = new JobConfiguration<T>();

            configure(cfg);

            return cfg.SetupJob(@this);
        }
    }
}