using System;

namespace Coveoticore.Benchmarks.USPC.Octagon
{
    public class FightNightEvent
    {
        public string Name { get; set; }
        public int Rounds { get; set; }
        public Contender RedCornerContender { get; set; }
        public Contender BlueCornerContender { get; set; }
    }
}
