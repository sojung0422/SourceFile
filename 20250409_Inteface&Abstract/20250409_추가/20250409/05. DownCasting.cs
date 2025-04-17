/*********************************************
  -다운 캐스팅
 ㄴ 부모클래스 타입의 객체를 자식 클래스 타입으로 변환하는것.
 ㄴ 명시적 변환이 필요
 ㄴ 실제 객체가 자식 클래스 타입 아닐 경우 오류 발생
 ㄴ as 연산자 또는 is연산자를 사용하면 안전하게 변환 가능
 

//성기사,마법사,드루이드..기타등등...

 ***********************************************/
namespace _20250409
{
    class Animal
    {
        public void Speak()
        {
            Console.WriteLine("동물이 소리를 낸다");
        }
    }
    class Dog : Animal
    {
        public void Bark()
        {
            Console.WriteLine("멍멍");
        }
    }

    internal class _05
    {
        static void Main()
        {

            Animal animal = new Dog();//업 캐스팅
            Dog dog = (Dog)animal;  //다운 캐스팅(명시적 변환)
            dog.Bark();

            Animal animal1 = new Dog();
            //is 연산자를 사용하면 타입에 맞는 경우에만 다운 캐스팅을 수행
            if(animal1 is Dog dog1)
            {
                dog1.Bark();
            }
            else
            {
                Console.WriteLine("다운 캐스팅 불가");
            }
            Animal animal2 = new Dog();
            //as : 변환실패시 null를 반환하여 예외를 방지
            Dog dog2 = animal2 as Dog;

            if (dog2 != null)
            {
                dog2.Bark();
            }
            else
            {
                Console.WriteLine("다운 캐스팅 실패");
            }
   
        }
    }
}
