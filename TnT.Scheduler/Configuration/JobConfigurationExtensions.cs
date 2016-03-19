using System;
using TnT.Scheduler.Trigger;

namespace TnT.Scheduler.Configuration
{
    public static class JobConfigurationExtensions
    {
        public static IJobConfiguration<T> RunEvery<T>(this IJobConfiguration<T> @this, TimeSpan interval)
            where T : IJob
        {
            return @this.UseTrigger(new IntervalTrigger(interval));
        }

        public static IJobConfiguration<T> UseCron<T>(this IJobConfiguration<T> @this, string cronExpression, DateTime? startingFrom = null)
            where T : IJob
        {
            return @this.UseTrigger(new CronTrigger(cronExpression, startingFrom));
        }
    }
}