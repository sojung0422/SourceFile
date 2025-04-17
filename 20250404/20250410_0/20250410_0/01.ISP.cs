
/*
 ISP
- 클라이언트는 사용하지 않는 메서드에 의존하지 않아야 된다!
 -큰 덩어리의 인터페이스를 지양하고 작은 인터페이스를 여러개로 나누는게 좋다.
 

LSP
 - 자식 클래스는 부모클래스의 기능을 대체할수 있어야함.
 - 부모 클래스 객체가 사용되는 모든 부분에 자식 클래스 객체를 대체해도 논리적으로 동작이 깨지면 안됨.
 - 메서드의 동작방식이 부모클래스와 일관되도록 설계해야함.


    DIP
 - 상위모듈이 하위모듈에 의존하지 않도록하고. 추상화된 인터페이스에 의존하도록 해야한다.
 - 하위모듈은 상위 모듈의 구현에 의존X, 두 모듈이 추상화된 인터페이스를 통해 연결
 - 구체적인 구현에 의존하지 않고 추상화에 의존하여 모듈간의 결합도를 줄임.
 */
namespace ConsoleApp1
{

    #region ISP
    interface IAttack
    {
        void Attck();
    }
    interface IMagic
    {
        void CastSpell();
    }

    //class Knight : IAttack
    //{
    //    public void Attack()
    //    {

    //    }
    //}
    #endregion
    #region LSP
    class Bird
    {
        public virtual void Fly()
        {
            Console.WriteLine("훠이훠이 날아감");
        }
    }
    class Eagle : Bird
    {
        public override void Fly()
        {
            Console.WriteLine("독수리가 훠이훠이 날아감");
        }

    }
    class Dog : Bird
    {
        public override void Fly()
        {
            Console.WriteLine("개가 훠이훠이..?어떻게..?혼종?");
        }
    }
    abstract class Char
    {
        public abstract void Move();    //추상 메서드로 강제 시켜버림
    }
    class Chief : Char
    {
        public override void Move()
        {

        }
    }
    #endregion

    internal class _01
    {
    }
}
