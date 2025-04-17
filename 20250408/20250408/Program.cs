/********************************************************
 [캡슐화]
 - 객체의 내부 데이터를 외부에서 직접 접근하지 못하도록 보호하는 기법
 - 클래스 내부에서만 데이터를 관리하고 필요한 경우에만 외부에서 접근할수 있도록 제한

[캡슐화의 기본원칙]
 - 필드는 private으로 선언하여 외부에서 직접 접근하지 못하도록 함.
 - 필요한 경우라면  public 메서드나 프로퍼티를 통해 데이터를 제공
 - 클래스 내부에서만 데이터를 변경하거나 조작할수 있도록 제한

[캡슐화의 정점]
 - 데이터를 보호 -> private을 사용하면 잘못된 데이터 변경을 방지할수 있음
 - 유지보수 -> 필드 변경 방식이 바뀌어도 외부코드에 영향을 주지 않음
 - 제한적으로 접근 허용->프로퍼티를 조정하여 읽기/쓰기 권한을 조정 가능
 - 잘못된 값 방지-> set에서 유효성 검사를 추가해 오류를 방지
 
 ********************************************************/

/********************************************************
 [포함]
 - 클래스가 다른 클래스를 소유하고 있는 관계를 의미
 - 하나의 클래스가 다른 클래스의 인스턴스를 멤버 변수로 포함하고 그 객체의 기능을 자신의 일부처럼 사용하는 방식
 - 포함된 객체는 필드 변수처럼 사용되며, 외부에서 접근하기 위해서는 공개된 메서드를 통해 접근

[상속]
 - 한 클래스가 다른 클래스의 특성(속성, 메서드)을 물려받는 관계
 - 기본 클래스(부모 클래스)의 기능을 확장하거나 변경하여 자식 클래스에서 사용
 - 자식 클래스는 부모 클래스의 모든 public,protected 멤버를 상속
 - 자식 클래스는 부모클래스의 기능을 재정의(오버라이딩)하거나 추가할수 있음.
 - 다중상속은 C#에서 직접적으로 지원하지 않음. 인터페이스를 통해 다중상속의 효과를 낼수 있음
 
 ********************************************************/

namespace OOP
{
    class Engine
    {
        public string type;
        public Engine(string type)
        {
            this.type = type;
        }
        public void Start()
        {
            Console.WriteLine("엔진이 드릉드릉");
        }
    }
    class Car
    {
        private Engine engine;  //Engine객체를 포함

        public Car(string engineType)
        {
            engine = new Engine(engineType);    //Car 객체 생성시 Engine객체 생성
        }
        public void StartCar()
        {
            Console.WriteLine("시동이 걸려부러쓰");
            engine.Start();
        }
    }

    //class Warrior
    //{
    //    private string name;
    //    private int hp;
    //    private int atk;
    //    private int def;

    //    public Warrior(string name, int hp, int atk, int def)
    //    {
    //        this.name = name;
    //        this.hp = hp;
    //        this.atk = atk;
    //        this.def = def;
    //    }
    //    public void Attack()
    //    {
    //        Console.WriteLine($"{name}이 기본 공격함. 공격력 : {atk}");
    //    }
    //   public void ShowStatus()
    //    {
    //        Console.WriteLine($"{name} 체력 : {hp},공격력 : {atk} 방어력 : {def}"); 

    //    }
    //}

    class Character
    {
        protected string name { get; set; }
        protected int hp { get; set; }
        protected int atk { get; set; }

        public Character(string name, int hp, int atk)
        {
            this.name = name;
            this.hp = hp;
            this.atk = atk;
        }
        public void Attack()
        {
            Console.WriteLine($"{name}이 기본 공격함. 공격력 : {atk}");
        }
        public void ShowStatus()
        {
            Console.WriteLine($"{name} 체력 : {hp},공격력 : {atk} ");
        }
    }
    class Warrior : Character
    {
        private int def;    //Warrior클래스의 추가필드

        public Warrior(string name) : base(name, 120, 15)
        {
            def = 5;
        }
        public void HeavyAttack()
        {
            Console.WriteLine($"{name}이 필살공격함. 공격력 : {atk * 3}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Car myCar = new Car("모닝");
            myCar.StartCar();

            //Warrior warrior = new Warrior("홍길동", 100, 10, 5);
            //warrior.Attack();
            //warrior.ShowStatus();


            Warrior warrior = new Warrior("홍길서");
            warrior.ShowStatus();       //부모클래스메서드 호출
            warrior.Attack();        //부모 클래스 메서드
            warrior.HeavyAttack();   //자식 클래스 메서드
        }
    }
}
