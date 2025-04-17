using Game.Character;
namespace Game.Monster
{

    internal class CMonster
    {
        public string name { get; set; }
        public int hp { get; set; }
        public int attack { get; set; }

        public CMonster(string name, int hp, int attack)
        {
            this.name = name;
            this.hp = hp;
            this.attack = attack;
        }
        public void AttackPlayer(CCharacter player)
        {
            Console.WriteLine($"{name}이 {player.name}을 공격!");
            player.hp -= attack;
        }
    }
}
