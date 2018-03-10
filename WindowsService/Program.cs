using System;
using System.ServiceProcess;

namespace WindowsService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            if (Environment.UserInteractive) {
                var helloWorldService = new HelloWorldService();
                helloWorldService.TestStartup(null);
            }
            else {

                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[] {
                    new HelloWorldService()
                };
                ServiceBase.Run(ServicesToRun);
            }            
        }
    }
}
