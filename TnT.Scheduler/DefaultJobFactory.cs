using System;

namespace TnT.Scheduler
{
    public class DefaultJobFactory : IJobFactory
    {
        public T Resolve<T>()
        {
            return Activator.CreateInstance<T>();
        }
    }
}