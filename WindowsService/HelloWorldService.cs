using HelloWorldLibrary;
using System;
using System.ServiceProcess;
using System.Threading;

namespace WindowsService
{
    public partial class HelloWorldService : ServiceBase
    {
        ManualResetEvent _shutdownEvent = new ManualResetEvent(false);
        Thread _thread;

        public HelloWorldService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            _thread = new Thread(DoWork) {                
                IsBackground = true
            };
            _thread.Start();
        

            Console.WriteLine("Starting the service");
        }

        protected override void OnStop()
        {
            Console.WriteLine("Stopping the service");
            _shutdownEvent.Set();
            if (!_thread.Join(3000))
            { // give the thread 3 seconds to stop
                _thread.Abort();
            }
        }

        internal void TestStartup(string[] args)
        {
            this.OnStart(args);
            Console.ReadLine();            
        }


        private void DoWork()
        {
            while (!_shutdownEvent.WaitOne(1000)) // 1 second
            {  
                DoSomeStuff.PrintHelloWorld();
            }  
        }
    }
}
