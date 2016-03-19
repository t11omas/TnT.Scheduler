using System;
using NCrontab.Advanced;

namespace TnT.Scheduler.Trigger
{
    public class CronTrigger : Trigger
    {
        private readonly string cronExpression;
        private DateTime previousRun;

        public CronTrigger(string cronExpression, DateTime? startingFrom = null)
        {
            this.previousRun = startingFrom ?? DateTime.UtcNow;
            this.cronExpression = cronExpression;
        }

        protected override TimeSpan GetNextOccurrence()
        {
            DateTime nextOccurence = CrontabSchedule.Parse(this.cronExpression).GetNextOccurrence(previousRun);
            TimeSpan resut =  nextOccurence.Subtract(DateTime.UtcNow);
            previousRun = nextOccurence;
            return resut;
        }
    }
}