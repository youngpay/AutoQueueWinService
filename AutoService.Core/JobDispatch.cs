using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Core
{
    public static class JobDispatch
    {
        static JobDispatch() 
        {
            JobTable = new Dictionary<string, Action>();
        }

        public static Dictionary<string, Action> JobTable { get; set; }

        public static void Insert(string key, Action job) 
        {
            JobTable.Add(key, job);
        }

        public static Action JobForKey(string key)
        {
            if (!JobTable.ContainsKey(key))
                return null;
            return JobTable[key];
        }
    }
}
