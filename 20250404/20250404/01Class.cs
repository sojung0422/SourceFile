
//클래스
//데이터와 관련기능을 캡슐화 할수 있는 참조형식
//객체지향 프로그래밍에 객체를 만들기 위한 설계도
//클래스는 객체를 만들기위한 설계도 이며, 만들어진 객체를 인스턴스라 한다.
//만들어진 설계도를 기반으로 여러 객체를 만들수 있음
//참조 : 원본을 가리키고 있다==원본의 주소를 가지고 있음
//OOP 에서는 클래스를 사용하여 프로그램을 객체 단위로 구조화

/*
 [클래스 정의]
class 클래스이름
{
    //필드(속성)
    데이터 타입(int, string...) 필드이름(변수명);

   //메서드(기능)
   반환형 메서드 이름()
    {
        동작할 코드
    }

}
 
 
 */
namespace _20250404
{
    class Car
    {
        //필드(속성)
        public string name;
        public int speed;

        public void Drive()
        {
            Console.WriteLine($"{name}이(가) {speed}로 움직인다");
        }
    }

    class Point
    {
        public int x;
        public int y;
    }

    internal class CClass
    {
        static void Main()
        {
            Car car1 = new Car();//객체생성

            //속성설정(Car 클래스 안에 있는)
            car1.name = "봉고";
            car1.speed = 100;
            //Car 클래스 안에 있는 메서드를 호출
            car1.Drive();
            Car car2 = new Car();//객체생성

            //속성설정(Car 클래스 안에 있는)
            car2.name = "모닝";
            car2.speed = 200;
            //Car 클래스 안에 있는 메서드를 호출
            car2.Drive();


            Point p1 = new Point();
            p1.x = 10;
            p1.y = 20;

            Point p2 = p1; //참조형식의 대입

            Console.WriteLine(p2.x);        //10
            Console.WriteLine(p2.y);        //20

            p1.x = 30;
            Console.WriteLine(p2.x);        //10


            Point p3 = new Point(); ;
            p3.y = 10;
        }

    }
}
