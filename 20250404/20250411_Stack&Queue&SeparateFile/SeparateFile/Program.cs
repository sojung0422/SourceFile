using Game.Character;
using Game.Enums;
using Game.Monster;
using SeparateFile;

namespace Game.Main
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("플레이어 이름을 입력해라  :");
            string name = Console.ReadLine();

            Console.WriteLine("직업을 선택하시용~ : 0 = 전사, 1 = 엘프궁수 2 = 법사");
            int jobInput = int.Parse(Console.ReadLine());
            Job selectJob = (Job)jobInput;

            CCharacter player = new CCharacter(name, selectJob);
            CMonster slime = new CMonster("슬라임", 60, 10);

            CBattle  battle = new CBattle();
            battle.Battle(player, slime);
        }
    }
}
