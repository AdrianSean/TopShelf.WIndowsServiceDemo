using Topshelf;

namespace TopShelf.WIndowsService
{
    class Program
    {
        static void Main(string[] args)
        {
            var rc = HostFactory.Run(x =>                                   
            {
                x.Service<HelloWorldServiceManager>(s =>                                   
                {
                    s.ConstructUsing(name => new HelloWorldServiceManager());                
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
