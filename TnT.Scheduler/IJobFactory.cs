namespace TnT.Scheduler
{
    public interface IJobFactory
    {
        T Resolve<T>();
    }
}