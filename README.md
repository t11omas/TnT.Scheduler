# TnT.Scheduler

Lightweight .NET package for scheduling jobs.  It makes use of the TPL and waiting between each occurrence is done in a non-blocking manner.

## Sample for running on an interval

```c#
 public class TestJob : Job
    {
        public override void Run(JobContext context)
        {
            Console.WriteLine($"Job Executed {DateTime.Now}");
           
        }
    }

 Scheduler scheduler = new Scheduler();
 scheduler.AddJob<TestJob>(cfg => cfg.RunEvery(TimeSpan.FromSeconds(1)));
```

## Sample for running using a cron expression

```c#
 public class TestJob : Job
    {
        public override void Run(JobContext context)
        {
            Console.WriteLine($"Job Executed {DateTime.Now}");
           
        }
    }

 Scheduler scheduler = new Scheduler();
 scheduler.AddJob<TestJob>(cfg => cfg.UseCron("* * * * *"));
```

## Create an async Job

```c#
 public class TestJob : Job
    {
        public override Task RunAsync(JobContext context)
        {
            return Task.Run(() => Console.WriteLine($"Job Executed {DateTime.Now}"));
           
        }
    }
```

## Logging

TnT.Scheduler makes use of Common.Logging, so you are free to make use of any logging framework of your choice.  If you need control over how loggers are constructed, then implement ILoggerFactory:

```c#
public class DefaultLoggerFactory : ILoggerFactory
    {
        public ILog Resolve<T>()
        {
            return LogManager.GetLogger<T>();
        }
    }
```

##JobFactory

TnT.Schedule supports the use of any IoC frameworks for resolving instances of your Job.  To use your IoC, implement IJobFactory:

```c#
public class IoCJobFactory: IJobFactory
    {
	private IoC ioc;

	public IoCJobFactory(IoC ioc)
	{
		this.ioc = ioc;
	}

        public IJob Resolve<T>()
        {
            return this.ioc.Resolve<T>();
        }
    }
```
