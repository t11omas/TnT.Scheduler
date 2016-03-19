using System.Threading.Tasks;

namespace TnT.Scheduler.Trigger
{
    public interface ITrigger
    {
        Task WaitAsync();
    }
}