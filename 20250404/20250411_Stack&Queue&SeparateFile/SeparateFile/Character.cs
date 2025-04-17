

using Game.Enums;
using Game.Monster;
using SeparateFile;

namespace Game.Character
{
    internal class CCharacter
    {
        public string name { get; set; }

        public int hp { get; set; }

        public int attack { get; set; }

        public Job job { get; set; }

        public CCharacter(string name, Job job)
        {
            this.name = name;
            this.job = job;

            JobData jobData = new JobData(job);
            hp = jobData.hp;
            attack = jobData.attck;

        }
        public void AttackMonster(CMonster monster)
        {
            Console.WriteLine($"{name}이{monster.name}을 공격");
            monster.hp -= attack;
        }
    }
}
