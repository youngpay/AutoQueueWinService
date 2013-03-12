using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quartz;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using AutoService.Core;
using System.Collections.Generic;
using System.IO;
using Quartz.Impl;
using System.Reflection;
using System.Diagnostics;

namespace HostingService.Test
{
    [TestClass]
    public class MefTest
    {
        private IScheduler scheduler;

        //[Import(typeof(List<StandardAutoJob>))]
        public List<IAutoJob> Jobs { get; set; }
        private void Compose()
        {
            ComposeJob cj = new ComposeJob();
            Jobs = cj.Jobs;
            //var catalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            //var container = new CompositionContainer(catalog);
            //container.ComposeParts(this);

            //ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
            //scheduler = schedulerFactory.GetScheduler();

            //if (Jobs != null)
            //{
            //    foreach (var job in Jobs)
            //    {
            //        var jobDetail = new JobDetailImpl(job.JobName(), job.GetJob().GetType());
            //        scheduler.ScheduleJob(jobDetail, job.GetTrigger());
            //    }
            //}
        }

        [TestMethod]
        public void Setup()
        {
            Compose();
            Jobs[0].GetJob().Execute(null);
        }

        [TestMethod]
        public void DictionaryWithAction()
        {
            Action a = () => { Debug.Write("test"); };
            Action a1 = () => { Debug.Write("test1"); };
            Action a2= () => { Debug.Write("test2"); };

            Dictionary<string, Action> dict = new Dictionary<string, Action> 
            {
                { "test", a },
                { "test1", a1 },
                { "test2", a2 }
            };
            dict["test"]();
            dict["test1"]();
            dict["test2"]();
        }
    }
}
