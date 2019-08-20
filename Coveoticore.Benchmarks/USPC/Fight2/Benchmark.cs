using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Coveoticore.Benchmarks.Logger;
using Coveoticore.Benchmarks.USPC.Octagon;

namespace Coveoticore.Benchmarks.USPC.Fight2
{
    public class Benchmark
    {
        private readonly WebClient m_WebClient;

        private const string SITECORE_INSTANCE = "http://coveoticore-uspc-sc827/";

        public Benchmark()
        {
            m_WebClient = new WebClient();

            //Warm-up
            LoadPageWithViewRenderings(10);
            LoadPageWithControllerRenderings(10);
        }

        public void Process()
        {
            FightNightEvent fightNightEvent = new FightNightEvent
            {
                Name = "USPC Fight 2",
                Rounds = 5,
                BlueCornerContender = new Contender
                {
                    Name = "10 View Renderings",
                    Action = () => { LoadPageWithViewRenderings(10); }
                },
                RedCornerContender = new Contender
                {
                    Name = "10 Controller Renderings",
                    Action = () => { LoadPageWithControllerRenderings(10); }
                }
            };

            Executer bruceBuffer = new Executer(fightNightEvent, LogManager.GetConsoleLoggerInstance());

            bruceBuffer.LetsGetItOn();
        }

        private string LoadPageWithViewRenderings(int p_NumberOfRenderings)
        {
            return DownloadHtmlPage(SITECORE_INSTANCE + "page-with-" + p_NumberOfRenderings + "-view-renderings");
        }

        private string LoadPageWithControllerRenderings(int p_NumberOfRenderings)
        {
            return DownloadHtmlPage(SITECORE_INSTANCE + "page-with-" + p_NumberOfRenderings + "-controller-renderings");
        }

        private string DownloadHtmlPage(string p_URL)
        {
            return m_WebClient.DownloadString(p_URL);
        }
    }
}
