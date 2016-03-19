using System;
using System.Threading.Tasks;

namespace TnT.Scheduler.Trigger
{
    public abstract class Trigger : ITrigger
    {
        public Task WaitAsync()
        {
            return Task.Delay(this.GetNextOccurrence());
        }

        protected abstract TimeSpan GetNextOccurrence();
    }
}