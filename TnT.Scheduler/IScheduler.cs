using System;

namespace TnT.Scheduler
{
    public interface IScheduler
    {
        Guid AddJob<TJob>(JobSetup jobSetup) where TJob : IJob;
        void RemoveJob(Guid jobId);
    }
}