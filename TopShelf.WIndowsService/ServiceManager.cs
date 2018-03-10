using HelloWorldLibrary;
using System;
using System.Threading;

namespace TopShelf.WIndowsService
{
    public class HelloWorldServiceManager
    {
        ManualResetEvent _shutdownEvent = new ManualResetEvent(false);
        Thread _thread;

        public void Start() {

            _thread = new Thread(DoWork)
            {
                IsBackground = true
            };
            _thread.Start();


            Console.WriteLine("Starting the service");
        }

        public void Stop() {

            Console.WriteLine("Stopping the service");
            _shutdownEvent.Set();
            if (!_thread.Join(3000))
            { // give the thread 3 seconds to stop
                _thread.Abort();
            }

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
