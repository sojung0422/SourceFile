/***************************************************************
 [함수]
- 메서드라고 부르기도 함
- 특정 작업을 수행하는 코드
- 햔 변 정의하면 여러번 호출해서 사용 가능
- 코드의 재사용성이 높아짐(한 번 만드렁 놓으면 계속 쓸 수 있음)
- 유지보수가 쉬워짐


[접근제한자][반환형]함수이름(매개변수-파라미터)
{
     //여기에 실행할 코드(본문)
}
- 접근제한자 : 매서드에 접근 범위를 결정 (접근제한자가 없으면 프라이빗임)
- 반환형 : 함수(메서드)가 실행된 후 반환하는 타입
- 이름 : 이름
- 매개변수 : 함수가 입력받는 값(있을 수도, 없을 수도 있음)
- 반환하는 값이 있다면 반드시 반환타입과 동일해야 한다.
 
 ***************************************************************/
namespace _20250401
{
    //public void print()   -> 매서드는 클래스 안에 있어야 함
    //{

    //}

    internal class Function
    {
        //1. 반환이 없고 매개변수가 없는 경우
        public void Print() //public(접근제한자)void(반환형)print(이름)   ->   print의 값을 반환하고 끝내겠다는 것(void)는 아무것도 없다라는 뜻으로 반환하는 값이 없는 변수이기 때문에 중괄효 안에 retune을 쓰면 안됨 
        {
            //retune;
            Console.WriteLine("안녕 나는 Print().라는 메서드야!");
        }
        //2. 반환이 없고 매개변수가 없는 경우 - 상황 따라 매개 변수는 여러개 가능
        public void Print01(int a)//매개변수는 파라미터라고 부름
        {
            Console.WriteLine($"{a}");
        }
        //3. 반환값이 있고 매개변수가 없는 경우
        public int Print02()
        {
            return 3;
        }
        public string Print03()
        {
            return "안녕";
        }
        //4. 반환값이 있고 매개변수가 있는 경우
        public int Sum(int a, int b)
        {
            //int tes = a + b;
            //return;
            return a + b;

        }

        public void Print04(string name, int age)
        {
            Console.WriteLine($"이름 : {name}, 나이 : {age}");
        }
        public void Print05(int a, string str = "디폴트 매개변수", int c =1) //디폴트 매개변수(매개변수를 넣지 않으 상태에서 지정된 겂 매개변수)는 맨 오른쪽부터 시작을 해야 함
        {
            Console.WriteLine(str);
        }
        static void Main() //함수
        {
            Function function = new Function(); //객체 생성
            function.Print(); //여러번 호출 가능

            function.Print01(1);
            int num = function.Print02();
            Console.WriteLine(num);
            //int res = function.Print02();
            //Console.WriteLine();

            int res = function.Sum(100, 200); //전달의 개념이 아닌 복사의 의미임
            Console.WriteLine(res);
            function Print04("홍길동",10);
            function.Print05();
            function.Print05("홍길서");
            function.Print05("홍길남");







        }
        //반환값이 있고 매개변수가 있는 경우
        //디버깅 습관도 잘 들여놔야 함
    }
}
