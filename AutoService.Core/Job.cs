using Common.Logging;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Core
{
    public class Job : IJob
    {
        private static readonly ILog log = LogManager.GetCurrentClassLogger();

        public Job() { }
        public Job(string name, Action run)
        {
            JobDispatch.Insert(name, run);
        }

        public void Execute(IJobExecutionContext context)
        {
            string name = context.JobDetail.Key.Name;
            log.Info(name + ":Execute begin >>>");
            var action = JobDispatch.JobForKey(context.JobDetail.Key.Name);
            if (action != null)
                action();
            log.Info(name + ":Execute end   <<<");
        }
    }
}
