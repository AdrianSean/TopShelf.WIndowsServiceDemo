using System;

namespace HelloWorldLibrary
{
    public class DoSomeStuffInstanceClass : IDoSomeStuff
    {
        readonly string _param;
        public DoSomeStuffInstanceClass()
        {

        }

        public DoSomeStuffInstanceClass(string startParameter)
        {
            _param = startParameter;
        }

        public void PrintHelloWorld()
        {
            Console.WriteLine("Hello world @ {0} using start parameter {1}", DateTime.Now, _param);
        }

    }
}
