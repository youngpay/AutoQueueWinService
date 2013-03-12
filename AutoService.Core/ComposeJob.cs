using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Core
{
    public class ComposeJob
    {
        public ComposeJob() 
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "jobs");
            var catalog = new DirectoryCatalog(path);
            var container = new CompositionContainer(catalog);
            container.ComposeParts(this);
            InitJobs();
        }

        private void InitJobs()
        {
            Jobs = new List<IAutoJob>();
            if (StdJobs != null)
            {
                foreach (var item in StdJobs)
                {
                    var stdJob = new StandardAutoJob(item);
                    Jobs.Add(stdJob);
                }
            }
        }

        [ImportMany]
        public List<StandardJob> StdJobs { get; set; }

        public List<IAutoJob> Jobs { get; set; }
    }
}
