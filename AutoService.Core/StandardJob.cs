using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Core
{
    public abstract class StandardJob
    {
        public abstract void Run();
        public abstract string CronExpression { get; }
    }
}
