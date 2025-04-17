/*************************************************
 [인터페이스]
 - 클래스가 구현해야하는 메서드의 규약을 정의하는것.
 - 어떤 동작을 수행해야하는지만 정의하고 실제 구현은 하지 않음
 - 클래스가 특정 기능을 반드시 구현하도록 강제

 - 메서드의 구현이 X
 - 메서드를 반드시 구현해야 한다는 규칙만 정의
 - 직접적인 코드가 없고, 자식 클래스에서 반드시 구현해야함.

 - 다중 상속가능
 - 클래스는 하나의 부모 클래스만 상속받을수 있지만 , 여러 개의 인터페이스를 상속 받을수 있음

 - 인스턴스 필드, 생성자 포함 불가
 *************************************************/

namespace _20250409
{
    //인터페이스 선언
    interface IAttackable
    {
       void Attack();//구현이 없음

    }
    interface IDamageble
    {
        void TakeDamage(int damage);
    }

    class Warrior : IAttackable
    {
        public void Attack()
        {
            Console.WriteLine("칼을 휘두른다");
        }
        public void Attack01()
        {
            Console.WriteLine("fgjhsdfhkds");
        }
    }
    class Mage: IAttackable, IDamageble
    {
        public void Attack()
        {
            //구현
        }
       
        public void TakeDamage(int damage)
        {
            //구현
        }
    }
    class Archer : IAttackable
    {
        public void Attack()
        {
            //구현
        }
        public void Attack01()
        {
            //구현
        }
    }
    internal class _02
    {
        static void Main()
        {
            //워리어 클래스 타입의 객체 생성
            //워리어 클래스로 참조
            //워리어 인스턴스가 그대로 할당
            Warrior warrior = new Warrior();
            warrior.Attack();
            warrior.Attack01();

            //
            IAttackable archer = new Archer();
            archer.Attack();
           //archer.Attack01();
        }
    }
}
