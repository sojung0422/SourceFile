
using Game.Enums;

namespace SeparateFile
{
    internal class JobData
    {
        public int hp { get; private set; }
        public int attck { get; private set; }

        public JobData(Job job)
        {
            switch (job)
            {
                case Job.Warrior:
                    hp = 100;
                    attck = 20;
                   break;
                case Job.Archer:
                    hp = 200;
                    attck = 20;
                    break;
                case Job.Mage:
                    hp = 50;
                    attck = 2000;
                    break;
            }
        }
    }
}
