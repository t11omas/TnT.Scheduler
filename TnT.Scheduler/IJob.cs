using System.Threading.Tasks;

namespace TnT.Scheduler
{
    public interface IJob
    {
        Task RunAsync(JobContext context);
    }
}