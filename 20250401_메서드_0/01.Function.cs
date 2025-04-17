/******************************************************
 [함수]
 - 메서드라고 부르기도 함.
 - 특정 작업을 수행하는 코드
 - 한번 정의하면 여러번 호출해서 사용
 - 코드의 재사용성이 높아짐
 - 유지보수가 쉬워짐
 
 [접근제한자][반환형]함수이름(매개변수)
 {
    //실행할 코드
 }
 - 접근제한자 : 메서드의 접근 범위를 결정
 - 반환형 : 메서드가 실행된 후 반환하는 타입
 - 이름 : 이름
 - 매개변수 : 메서드가 입력받는 값(없을수도 있음)
 - 반환하는 값이 있다면 반드시 반환타입과 동일해야한다.
 *******************************************************/
namespace _20250401
{
   
    internal class Function
    {
        //1.반환이 없고 매개변수가 없는경우
        public void Print()
        {
            Console.WriteLine("안녕 나는 Print()라는 메서드야!");
        }
        //2.반환이 없고 매개변수가 있는 경우
        public void Print01(int a)
        {
            Console.WriteLine($"{a}");
        }
        //3.반환값이 있고 매개변수가 없는경우
        public int Print02()
        {
            return 3;
        }
        public string Print03()
        {
            return "안녕";
        }

        //4.반환값이 있고 매개변수가 있는 경우
        public int Sum(int a, int b)
        {
            return a + b;   
        }
        public void Print04(string name, int age)
        {
            Console.WriteLine($"이름 : {name}, 나이 : {age}");
        }
        public void Print05(string str = "디폴트 매개변수")
        {
            Console.WriteLine(str);
        }
        static void Main()
        {
            Function function = new Function();
            function.Print();
            function.Print01(1);
            int num = function.Print02();
            Console.WriteLine(num);

            int res = function.Sum(100, 200);
            Console.WriteLine(res);
            function.Print04("홍길동",10);
            //function.Print05();
            //function.Print05("홍길서");
            //function.Print05("홍길남");
        }
    }
}
