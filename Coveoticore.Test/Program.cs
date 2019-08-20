using System;
using System.Threading;
using Coveoticore.Benchmarks.USPC.Fight2;

namespace Coveoticore.Test
{
    public class Program
    {
        static void Main(string[] args)
        {
            Benchmark fight2 = new Benchmark();
            fight2.Process();

            Console.ReadKey();
        }
    }
}
