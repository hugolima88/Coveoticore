using System.Net;
using Coveoticore.Benchmarks.Logger;
using Coveoticore.Benchmarks.USPC.Octagon;

namespace Coveoticore.Benchmarks.USPC.Fight2
{
    public class Benchmark
    {
        private const int TOTAL_OF_RENDERINGS = 100;
        private const string SITECORE_INSTANCE = "http://coveoticore-uspc-sc827/";

        private readonly WebClient m_WebClient;

        public Benchmark()
        {
            m_WebClient = new WebClient();

            //Warm-up
            LoadPageWithViewRenderings(TOTAL_OF_RENDERINGS);
            LoadPageWithControllerRenderings(TOTAL_OF_RENDERINGS);
        }

        public void Process()
        {
            FightNightEvent fightNightEvent = new FightNightEvent
            {
                Name = "USPC Fight 2",
                Rounds = 5,
                BlueCornerContender = new Contender
                {
                    Name = TOTAL_OF_RENDERINGS + " View Renderings",
                    Action = () => { LoadPageWithViewRenderings(TOTAL_OF_RENDERINGS); }
                },
                RedCornerContender = new Contender
                {
                    Name = TOTAL_OF_RENDERINGS + " Controller Renderings",
                    Action = () => { LoadPageWithControllerRenderings(TOTAL_OF_RENDERINGS); }
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
