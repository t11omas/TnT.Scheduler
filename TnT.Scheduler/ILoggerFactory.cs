using Common.Logging;

namespace TnT.Scheduler
{
    public interface ILoggerFactory
    {
        ILog Resolve<T>();
    }
}

