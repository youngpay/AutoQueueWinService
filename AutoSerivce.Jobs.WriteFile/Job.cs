using AutoService.Core;
using Common.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSerivce.Jobs.WriteFile
{
    [Export(typeof(StandardJob))]
    public class Job : StandardJob
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
                log.Info("任务开始");
                log.Info("任务结束");
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }
    }
}
