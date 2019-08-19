using System.Diagnostics;
using Coveoticore.Benchmarks.Logger;

namespace Coveoticore.Benchmarks.USPC.Octagon
{
    public class Executer : IExecuter
    {
        private readonly FightNightEvent m_FightNightEvent;
        private readonly ILogger m_Logger;

        public Executer(FightNightEvent p_FightNightEvent, ILogger p_Logger)
        {
            m_FightNightEvent = p_FightNightEvent;
            m_Logger = p_Logger;
        }

        public void LetsGetItOn()
        {
            long redCornerResult = ExecuteFigther(m_FightNightEvent.RedCornerContender);
            long blueCornerResult = ExecuteFigther(m_FightNightEvent.BlueCornerContender);

            string winner = redCornerResult < blueCornerResult ? m_FightNightEvent.RedCornerContender.Name
                : m_FightNightEvent.BlueCornerContender.Name;

            m_Logger.Info($"{m_FightNightEvent.Name} - (Judges Decision): Ladies and gentlemen, {winner} is the winner of the night!");
        }

        private long ExecuteFigther(Contender p_Contender)
        {
            long totalExecutionTime = 0;
            for (int i = 1; i <= m_FightNightEvent.Rounds; i++)
            {
                Stopwatch stopWatch = Stopwatch.StartNew();
                p_Contender.Action();
                stopWatch.Stop();

                totalExecutionTime += stopWatch.ElapsedMilliseconds;
                m_Logger.Info($"{m_FightNightEvent.Name} - {p_Contender.Name} (Round {i}): {stopWatch.ElapsedMilliseconds}");
            }
            m_Logger.Info($"{m_FightNightEvent.Name} - {p_Contender.Name} (Average): {totalExecutionTime/m_FightNightEvent.Rounds}");
            return totalExecutionTime;
        }
    }

    public interface IExecuter
    {
        void LetsGetItOn();
    }
}