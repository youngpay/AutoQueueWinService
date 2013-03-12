using System.IO;
using System.ServiceProcess;

namespace HostingService
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        static void Main()
        {
            if (!File.Exists("jobs"))
                Directory.CreateDirectory("jobs");
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
            { 
                new QuartzService()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
