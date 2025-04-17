/*********************************************
 [캐스팅]
 - 상속관계에서 객체를 서로 다른 타입으로 변환하는 개념

 -업캐스팅
 ㄴ 하위클래스(자식 클래스)의 객체를 상위클래스(부모 클래스)타입으로 변환하는것.
 ㄴ 자동변환이 가능(안전)


 *********************************************/

namespace _20250409
{
    class Animal
    {
        public void Speak()
        {
            Console.WriteLine("동물이 소리를 낸다");
        }
        public virtual void Eat()
        {
            Console.WriteLine("밥을 먹는다");
        }
    }
    class Dog : Animal
    {
        public override void Eat()
        {
            Console.WriteLine("강아지가 밥을 와구와구 먹는다");
        }
        public void Bark()
        {
            Console.WriteLine("멍멍");
        }
    }
    internal class _04
    {
        static void Main()
        {
            Dog dog = new Dog(); //원래 Dog객체
            Animal animal = dog;    //업캐스팅

            animal.Speak(); //부모클래스의 메서드
            //animal.Bark(); //자식클래스의 멤버는 접근이 불가

            animal.Eat();   //생성된 인스턴스가 하위클래스(Dog)d이기 때문에 오버라이딩된 Eat()가 실행
        }
    }
}
