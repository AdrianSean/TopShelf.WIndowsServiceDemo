using HelloWorldLibrary;
using System;

namespace WindowsService.ConsoleAppTestHarness
{
    class Program
    {
        static void Main(string[] args)
        {
            DoSomeStuff.PrintHelloWorld();
            Console.Read();
        }
    }
}
