namespace _20250401
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("이거슨 c#이다."); // 출력
            int a = 0;
            Console.WriteLine(a);

            int b = 0;

            Console.WriteLine($"문자열 보간 방법으로 출력하는 것 : {a} + {b} = {a + b}"); // $표시 넣으면 중괄호 처리로 뽑아낼 수 있음

            /*
             [형 변환] (타임케스팅) 
            - 데이터를 선언한 자료형에 맞는 형태로 변환하는 작업
            - 다른 자료형의 데이터를 저장하기 위해선 형 변환 과정을 거쳐야 하며
            - 이 과정에서 보관할 수 없는 데이터는 버려짐
            - 명시적 - 명시한다
            - 묵시적 - 자기가 알아서 자동으로 형 변환함
             
             
             */

            //명시적 형변환
            //변환할 데이터의 앞에 변환할 자료형을 괄호 안에 넣어 형 변환 진행
            int intValue = (int)1.2; //1.2를 int로 변환하는 과정 중 보관할 수 없는 소수점은 버려짐

            Console.WriteLine($"int 변수에 1.2를 형 변환하여 집어넣은 데이터는{intValue} 1입니다.");

            //묵시적 형변환
            float floatValue = 3;
            double doubleValue = 1.2f; //f는 프롯형을 나타냄

            doubleValue = (double)floatValue; //작은 범위를 담을 수 있는 변수를 큰 변수로 옮길 때 자기가 알아서 형 변환을 때림

            //Parse
            //문자열을 해당 타입으로 변환하는 가장 기본적인 방법
            //변환이 실패하면 예외(Exception)가 발생
            string numberStr = "123";
            int number = int.Parse(numberStr);

            //int value = (int)"1234"; -> error : 문자형 자료를 정수형 자료형으로 단순 형 변환을 불가

            //변환할 수 없는 문자열 자료를 정수형으로 변환하려 시도하는 경우 예외 발생
            // int value = int.Parse("abc");
            // Console/WriteLine(value);

            string text1 = (true).ToString(); // string은 문자열로 바꿔준다는 뜻
            string text2 = (132).ToString();
            string text3 = (1.2).ToString();

            Console.WriteLine(text1);
            Console.WriteLine(text2);
            Console.WriteLine(text3);

            Console.Write("이름을 입력하세요");
            string name = Console.ReadLine();
            Console.WriteLine("안녕하세요 : " + name);

            //Console.WriteLine("숫자를 입력하세요");
            //string inpitNum = Console.ReadLine();
            //int.Parse(inputNum);
            //Console.WriteLine(inputNum);

            Console.WriteLine("숫자를 입력하세요");
            string inputNum = Console.ReadLine();
            int.TryParse(inputNum, out intValue); // out키워드가 없으면 변환된 값을 반환할 방법이 없음
            Console.WriteLine(inputNum);

            //Parse보다 TryParse가 안전하면 out은 변환된 변수값을 지정하는 역할이다.
        }
    }
}
