using Topshelf;
using Topshelf.Logging;
using Topshelf.Ninject;
using Topshelf.StartParameters;
using TopShelf.WindowsService.UsingNinject;

namespace TopShelf.WindowsService.UsingStartParameter
{
    class Program
    {
        static void Main(string[] args)
        {
            string myParameter = args[1];

            var rc = HostFactory.Run(x =>
            {
                x.EnableStartParameters();

                x.UseNinject(new NinjectConfiguration(myParameter));

#if DEBUG
                x.WithStartParameter("myparameter", a => { });
#else
                x.WithStartParameter("myparameter",
                    a => HostLogger.Get("StartParameters").InfoFormat("parameter: {0}, value: {1}", "myparameter", a));
#endif

                x.Service<HelloWorldServiceManager>(s =>
                {
                    s.ConstructUsingNinject();
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });

                x.RunAsLocalSystem();

                x.SetDescription("HelloWorld Windows Service using TopShelf");
                x.SetDisplayName("HelloWorld Windows Service");
                x.SetServiceName("HelloWorld Windows Service");
            });
        }
    }
}
