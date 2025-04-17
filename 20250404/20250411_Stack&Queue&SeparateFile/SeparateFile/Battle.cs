

using Game.Character;
using Game.Monster;

namespace SeparateFile
{
    internal class CBattle
    {
        public void Battle(CCharacter player, CMonster monster)
        {
            Console.WriteLine("싸워라");

            while (player.hp >0 && monster.hp>0)
            {
                player.AttackMonster(monster);
                Console.WriteLine($"{monster.name} HP : {monster.hp}");

                if(monster.hp<=0)
                {
                    Console.WriteLine($"{monster.name}이 죽어버려쪙");
                    break;
                }
                monster.AttackPlayer(player);
                Console.WriteLine($"{player.name} HP : {player.hp}");
                if (player.hp <= 0)
                {
                    Console.WriteLine($"{player.name}이 죽어버려쪙");
                    break;
                }
                Console.WriteLine();
            }
        }
    }
}
