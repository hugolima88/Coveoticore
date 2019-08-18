using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Coveoticore.Benchmarks.Logger
{
    public static class LogManager
    {
        public static ILogger GetInstance()
        {
            return new Logger(MethodBase.GetCurrentMethod().DeclaringType);
        }
    }
}
