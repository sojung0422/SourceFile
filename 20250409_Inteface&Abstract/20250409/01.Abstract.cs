/*************************************************
[abstractClass]
- 객체를 직접 생성할수 없고(인스턴스를 생성할수 없음) 구체적인 내용이 일부 또는 전혀 없는 클래스
- 공통적인 기능을 정의하고, 자식클래스가 이를 상속받아서 구현하도록 강제하는 역할
- 자식 클래스가 반드시 구현해야하는 메서드를 포함할수 있음
- 일반 메서드와 추상 메서드를 함께 가질수 있음.
 
[abstractClass 사용 이유]
 - 공통된 기능을 부모클래스에서 정의하고, 특정 기능만 자식 클래스에서 구현하도록 강제
 - 공통된 기능을 한곳에서 관리하므로 중복코드를 줄이고 유지보수성을 높일 수 있음.
 - 만약 아래 예시에서 다른 동물클래스가 추가가 되더라도  Bark()를 강제 구현 시키므로 일관성이 유지됨.
 **************************************************/

namespace _20250409
{
    abstract class Animal
    {
        protected string name { get; set; }
        public Animal(string name)
        {
            this.name = name;
        }
        //일반 메서드
        public void Eat()
        {

        }
        //추상 메서드->구현불가(반드시 자식 클래스에서 구현해야됨.)
        public abstract void Bark();
    }
    class Dog : Animal
    {
        public Dog(string name) : base(name) { }
        public override void Bark()
        {
            Console.WriteLine($"{name}이 멍멍");
        }
    }
    class Cat : Animal
    {
        public Cat(string name) : base(name) { }
        public override void Bark()
        {
            Console.WriteLine($"{name}이 야옹야옹");
        }
    }
    internal class _01
    {
        static void Main()
        {
            Dog dog = new Dog("바우바우");
            dog.Bark();


            //추상 클래스는 인스턴스 생성 불가
           // Animal animal = new Animal("동물");
        }
    }
}
