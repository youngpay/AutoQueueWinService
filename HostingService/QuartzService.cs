using System.Collections.Generic;
using System.ServiceProcess;
using Common.Logging;
using Quartz.Impl;
using Quartz;
using AutoService.Core;

namespace HostingService
{
    partial class QuartzService : ServiceBase
    {
        private readonly ILog logger = LogManager.GetCurrentClassLogger();
        private IScheduler scheduler;

        public List<IAutoJob> Jobs { get; set; }

        public QuartzService()
        {
            InitializeComponent();

            Compose();
        }

        private void Compose()
        {
            Jobs = new ComposeJob().Jobs;
            InitScheduler();
        }

        private void InitScheduler() 
        {
            if (scheduler == null)
            {
                ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
                scheduler = schedulerFactory.GetScheduler();
            }
            if (scheduler.IsStarted)
            {
                this.OnStop();
            }

            if (Jobs != null)
            {
                foreach (var job in Jobs)
                {
                    var jobDetail = new JobDetailImpl(job.JobName(), job.GetJob().GetType());
                    scheduler.ScheduleJob(jobDetail, job.GetTrigger());
                }
            }
        }

        protected override void OnStart(string[] args)
        {
            scheduler.Start();
            logger.Info("Quartz 启动");
        }

        protected override void OnStop()
        {
            scheduler.Shutdown();
            logger.Info("Quartz 停止");
        }

        protected override void OnPause()
        {
            scheduler.PauseAll();
            
        }

        protected override void OnContinue()
        {
            scheduler.ResumeAll();
        }
    }
}
