/****************************************
 [namespace]
 네임스페이스 기본 사용     ->  클래스를 그룹화하여 이름충돌 방지
 중첩 네임스페이스          ->  네임스페이스를 계층적으로 구성
 별명사용                  -> 긴 네임스페이스를 간결하게 사용
 이름충돌 방지             -> 동일한 클래스명이 있어도 네임스페이스로 구분가능
 ****************************************/

using GameCharacter = Game.Characters.Warrior;
namespace AA
{
    public class CNamespace
    {
        public int a;
    }
}
namespace Game.Utils
{

    //이건 몰라도됨.
    static class MathHelper
    {
        //이녀석도 몰라도 됨(정적 메서드)
        public static int CalculateDamage(int baseDamage, int strength)
        {
            return baseDamage * strength;
        }
    }
}

namespace Game
{
    namespace Characters
    {
        class Warrior
        {
            public void Attack()
            {
                Console.WriteLine("기본공격!!");
            }
        }
    }
}

namespace _20250404
{

    internal class CNamespace
    {
        public int a;

        static void Main()
        {
            AA.CNamespace cNamespace = new AA.CNamespace();
            cNamespace.a = 1;

            //Game.Characters.Warrior warrior = new Game.Characters.Warrior();
            GameCharacter warrior = new GameCharacter();
        }
    }
    