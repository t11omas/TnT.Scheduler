using System;

namespace TnT.Scheduler.Trigger
{
    public class IntervalTrigger : Trigger
    {
        private readonly TimeSpan interval;

        public IntervalTrigger(TimeSpan interval)
        {
            this.interval = interval;
        }

        protected override TimeSpan GetNextOccurrence()
        {
            return this.interval;
        }
    }
}