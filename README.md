# TnT.Scheduler

Lightweight .NET package for scheduling jobs.  It makes use of the TPL and waiting between each occurrence is done in a non-blocking manner.

## Sample for running on an interval

```c#
 public class TestJob : Job
    {
        public override Run(JobContext context)
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
        public override Run(JobContext context)
        {
            Console.WriteLine($"Job Executed {DateTime.Now}");
           
        }
    }

 Scheduler scheduler = new Scheduler();
 scheduler.AddJob<TestJob>(cfg => cfg.UseCron("* * * * *"));
```