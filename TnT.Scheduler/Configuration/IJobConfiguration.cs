using System;
using TnT.Scheduler.Trigger;

namespace TnT.Scheduler.Configuration
{
    public interface IJobConfiguration<TJob> 
        where TJob : IJob
    {
        IJobConfiguration<TJob> UseTrigger(ITrigger trigger);
        IJobConfiguration<TJob> Setup(Action<JobSetup> action);
        IJobConfiguration<TJob> WithParameter(object parameter);
    }
}