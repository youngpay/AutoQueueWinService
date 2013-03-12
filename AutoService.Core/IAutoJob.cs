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
    public interface IAutoJob
    {
        string JobName();
        IJob GetJob();
        ITrigger GetTrigger();
    }
}
