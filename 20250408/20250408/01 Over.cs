/********************************************
 [다형성]
 - 형태가 여러가지
 - 하나의 인터페이스(메서드, 클래스..)가 다양한 방식으로 동작할수 있도록 하는 OOP개념

 - 오버로딩 : 같은 이름의 메서드를 매개변수만 다르게 여러개 정의
 - 오버라이딩  : 부모 클래스 메서드를 자식 클래스에서 재정의
 - 추상 클래스와 인터페이스 : 공통적인 동작을 정의하고 각각의 클래스에서 다른 방식으로 구현
 

[메서드 오버라이딩]
 - 상속 받은 부모 클래스의 메서드를 자식 클래스에서 재정의(수정) 하는 기능
 - 부모 클래스의 메서드와 같은 이름, 같은 매개변수를 가지지만, 내부 동작을 다르게 구현

 - 부모 클래스의 메서드와 반환형, 이름, 매개변수가 동일해야함.
 - 부모 클래스에 virtual 키워드를 붙히고, 자식 메서드에 override 키워드를 사용

 - virtual : 부모클래스에서 이 메서드는 자식 클래스에서 오버라이딩이 가능하다라고 명시하는 키워드
 - override : 부모의 virtual 메서드를 재정의(override)하려면 override 키워드를 사용
 - sealed : 자식 클래스에서 더 이상 오버로딩을 허용하지 않으려면 sealed 키워드를 사용


[오버로딩  VS 오버라이딩]

구분                   오버로딩                                           오버라이딩

목적                  같은 이름의 메서드를 여러개 정의                     상속받은 메서드를 재정의
상속여부              상속과 관계없음                                     상속관계에서 사용
virtual/override      X                                                  O
매개변수               다르게 설정                                       동일
반환형                                                                  동일

 ********************************************/
namespace _20250408
{
    class Character
    {
        protected string name { get; set; }
        public Character(string name)
        {
            this.name = name;
        }
        public virtual void Attack()
        {
            Console.WriteLine($"{name}이 공격함");
        }
    }
    //Character 상속
    class Warrior : Character
    {
        public Warrior(string name) : base(name)
        {

        }
        public override sealed void Attack()//오버라이딩(재정의)
        {
            Console.WriteLine($"{name}이 크리티컬 공격을 했다");
        }
    }
    class Mage : Character
    {
        public Mage(string name) : base(name)
        {

        }
        public override void Attack()
        {
            base.Attack();//부모의 Attack메서드 호출
            Console.WriteLine("마법사가 아이스볼 공격을 한다");
        }
    }
    class Warrior1 : Warrior
    {
        public Warrior1(string name) : base(name) { }

        //public override void Attack()
        //{
        //    //여기에 뭔가 들어갈꺼고...
        //}
    }
    internal class _01
    {

    }
}
