using System;
using System.Threading;
using System.Threading.Tasks;
using Common.Logging;

namespace TnT.Scheduler
{
    internal class Worker<T> : IWorker where T : IJob
    {
        private readonly Type jobType;
        private readonly IJobFactory jobFactory;
        private readonly JobSetup setup;
        private Task workerTask;
        private CancellationTokenSource cancellationTokenSource;
        private readonly ILog logger;

        public Worker(JobSetup setup, IJobFactory jobFactory, ILoggerFactory loggerFactory)
        {
            this.setup = setup;
            this.jobFactory = jobFactory;
            this.logger = loggerFactory.Resolve<T>();
            this.jobType = typeof (T);
        }

        public void Start()
        {
            this.workerTask = Task.Factory.StartNew(RunAsync, TaskCreationOptions.LongRunning);
            this.cancellationTokenSource= new CancellationTokenSource();
            this.logger.Debug($"{jobType.FullName} - started");
        }

        public void Stop()
        {
            this.cancellationTokenSource.Cancel();
            this.logger.Debug($"{jobType.FullName} - stopped");
        }

        private async Task RunAsync()
        {
            try
            {
                while (true)
                {
                    await this.setup.Trigger.WaitAsync().ConfigureAwait(false);

                    if (this.cancellationTokenSource.IsCancellationRequested)
                    {
                        return;
                    }

                    await this.RunJobAsync().ConfigureAwait(false);
                }
            }
            catch (Exception)
            {
                logger.Info($"Job ({jobType.FullName}) execution interrupted by user code!");
            }
           
        }

        private async Task RunJobAsync()
        {
            try
            {
                logger.Debug($"Instantiating job: {jobType.FullName}");
                T jobInstance = this.jobFactory.Resolve<T>();
                JobContext context = this.setup.BuildContext();

                try
                {
                    logger.Debug($"Executing job ({jobType.FullName})...");
                    await jobInstance.RunAsync(context).ConfigureAwait(false);
                    logger.Debug($"Executing job ({jobType.FullName})...Done!");
                }
                catch (Exception ex)
                {
                    logger.Error($"Unhandled exception during job ({jobType.FullName}) execution!", ex);
                }
            }
            catch (Exception ex)
            {
                logger.Fatal(ex);
            }
        }
    }
}