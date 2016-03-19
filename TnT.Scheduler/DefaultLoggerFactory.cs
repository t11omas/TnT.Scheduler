using Common.Logging;

namespace TnT.Scheduler
{
    public class DefaultLoggerFactory : ILoggerFactory
    {
        public ILog Resolve<T>()
        {
            return LogManager.GetLogger<T>();
        }
    }
}