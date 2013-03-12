using Common.Logging;
using Quartz;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Core
{
    public class StandardAutoJob : IAutoJob
    {
        public StandardAutoJob(StandardJob stdJob)
        {
            this.stdJob = stdJob;
            JobName();
            GetJob();
            GetTrigger();
        }

        private StandardJob stdJob = null;

        private string jobName;
        private ITrigger trigger;
        private IJob job;

        public string JobName()
        {
            CheckImport();
            if (jobName == null)
            {
                jobName = stdJob.GetType().FullName;
            }
            return jobName;
        }

        public Quartz.IJob GetJob()
        {
            CheckImport();
            if (job == null)
                job = new Job(jobName, stdJob.Run);
            return job;
        }

        public Quartz.ITrigger GetTrigger()
        {
            CheckImport();
            if (trigger == null)
                trigger = TriggerBuilder.Create().WithCronSchedule(stdJob.CronExpression).Build();
            return trigger;
        }

        private void CheckImport()
        {
            if (stdJob == null)
            {
                throw new ArgumentNullException("stdJob");
            }
        }
    }
}
