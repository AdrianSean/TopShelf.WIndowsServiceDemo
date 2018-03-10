using Topshelf;
using Topshelf.Ninject;

namespace TopShelf.WindowsService.UsingNinject
{
    class Program
    {
        static void Main(string[] args)
        {
            var rc = HostFactory.Run(x =>
            {
                x.UseNinject(new NinjectConfiguration()); //Initiates Ninject and consumes Modules

                x.Service<HelloWorldServiceManager>(s =>
                {
                    s.ConstructUsingNinject();
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });
                x.RunAsLocalSystem();

                x.SetDescription("HelloWorld Windows Service using TopShelf");
                x.SetDisplayName("HelloWorld Windows Service");
                
            });
        }
    }
}
