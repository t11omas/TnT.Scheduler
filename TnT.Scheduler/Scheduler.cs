using System;
using System.Collections.Generic;

namespace TnT.Scheduler
{
    public class Scheduler : IScheduler
    {
        private readonly IJobFactory jobFactory;
        private readonly ILoggerFactory loggerFactory;
        private readonly Dictionary<Guid, IWorker> jobs;

        public Scheduler(): this(new DefaultJobFactory(), new DefaultLoggerFactory())
        {
            
        }

        public Scheduler(IJobFactory jobFactory, ILoggerFactory loggerFactory)
        {
            this.loggerFactory = loggerFactory;
            this.jobFactory = jobFactory;
            this.jobs = new Dictionary<Guid, IWorker>();
        }

        public Guid AddJob<TJob>(JobSetup jobSetup) where TJob : IJob
        {
            if (jobSetup.JobId == Guid.Empty)
            {
                jobSetup.JobId = Guid.NewGuid();
            }

            Worker<TJob> worker = new Worker<TJob>(jobSetup, this.jobFactory, this.loggerFactory);

            this.jobs[jobSetup.JobId] = worker;

            worker.Start();

            return jobSetup.JobId;
        }

        public virtual void RemoveJob(Guid jobId)
        {
            if (this.jobs.ContainsKey(jobId))
            {
                this.jobs[jobId].Stop();

                this.jobs.Remove(jobId);
            }
        }
    }
}