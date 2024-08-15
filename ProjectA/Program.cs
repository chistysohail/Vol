using System;
using SharedLibrary;

namespace ProjectA
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Thread.Sleep(100000);
            Console.WriteLine(Utilities.GetGreeting("ProjectA"));
        }
    }
}
