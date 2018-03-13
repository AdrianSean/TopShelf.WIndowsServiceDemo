using Topshelf;
using Topshelf.Logging;
using Topshelf.StartParameters;


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

                string queueName = string.Empty;
#if DEBUG
                //CHANGE TO WHATEVER QUEUE NAME HERE WHEN IN DEUBG MODE TO TEST THE SUBSCRIPTION AGAINST THAT QUEUE
                // WHEN RUNNING IN VS THE PARAMETER IS SET UNDER PROJECT PROPERTIES->DEBUG TAB->COMMAND LINE ARGUMENTS TEXTFIELD
                
                x.AddCommandLineDefinition("myparam", f => { queueName = f; });
                x.ApplyCommandLine();

#else
                //PICKS UP THE QUEUE NAME FROM THE PARAMETER [-queueName] (SEE THE INSTALLER FOLDER FOR EXAMPLE OF THIS)
                x.EnableStartParameters();
                x.WithStartParameter("myparam", f => {queueName = f; });
#endif

                x.Service<HelloWorldServiceManager>(s =>
                {
                    s.ConstructUsing(name => new HelloWorldServiceManager(queueName));
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
