using System.Threading.Tasks;

namespace TnT.Scheduler
{
    public abstract class Job : IJob
    {
        public virtual Task RunAsync(JobContext context)
        {
            this.Run(context);
            return Task.FromResult(0);
        }

        protected abstract void Run(JobContext context);
    }
}