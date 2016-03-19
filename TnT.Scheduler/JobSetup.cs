using System;
using TnT.Scheduler.Trigger;

namespace TnT.Scheduler
{
    public class JobSetup
    {
        public Guid JobId { get; set; }
        public ITrigger Trigger { get; set; }
        public object Parameter { get; set; }

        public JobSetup()
        {
            this.JobId = Guid.Empty;
        }

        public JobContext BuildContext()
        {
            return new JobContext(this.JobId, this.Parameter);
        }
    }
}