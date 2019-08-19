using System;

namespace Coveoticore.Benchmarks.Logger
{
    public class ConsoleLogger : ILogger
    {
        public void Info(string p_Message)
        {
            Console.WriteLine(p_Message);
        }
    }
}