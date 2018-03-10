using System;

namespace HelloWorldLibrary
{
    public class DoSomeStuffInstanceClass : IDoSomeStuff
    {     

        public void PrintHelloWorld()
        {
            Console.WriteLine("Hello world @ {0}", DateTime.Now);
        }

    }
}
