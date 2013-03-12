using AutoService.Core;
using Common.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Jobs.WriteFile2
{
    [Export(typeof(StandardJob))]
    public class Job2 : StandardJob
    {
        private static readonly ILog log = LogManager.GetCurrentClassLogger();

        public override string CronExpression
        {
            get
            {
                return "0/30 * * * * ?";
            }
        }

        public override void Run()
        {
            try
            {
                log.Info("任务开始1111");
                log.Info("任务结束1111");
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }
    }
}
