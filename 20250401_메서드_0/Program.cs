namespace _20250401
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("이거슨 C#이다");
            int a = 1;
            Console.WriteLine(a);

            int b = 2;

            Console.WriteLine($"문자열보간방법으로 출력하는것:{a}+{b} = {a + b}");

            /************************************************
             [형변환]
             - 데이터를 선언한 자료형에 맞는 형태로 변환하는 작업
             - 다른 자료형의 데이터를 저장하기 위해선 형변환 과정을 거쳐야 하며
             - 이 과정에서 보관할수 없는 데이터는 버려짐

            ************************************************/
            //명시적 형변환
            //변환할 데이터의 앞에 변환할 자료형을 괄호안에 넣어 형변환 진행
            int intValue = (int)1.2;    //1.2를 int로 변환하는 과정 중 보관할수 없는 소수점은 버려짐

            Console.WriteLine($"int 변수에 1.2를 형변환하여 집어넣은 데이터는{intValue}입니당");

            //묵시적 형변환
            float floatValue = 3;
            double doubleValue = 1.2f;
            doubleValue = (double)floatValue;

            //Parse
            //문자열을 해당 타입으로 변환하는 가장 기본적인 방법
            //변환이 실패하면 예외(Exception)가 발생
            string numberStr = "123";
            int number = int.Parse(numberStr);

           //int value = (int)"1234"; error->문자열 자료를 정수형 자료형으로 단순 형변환은 불가

           //변환할수 없는 문자열 자료를 정수형으로 변환하려 시도하는 경우 예외발생
           //int value = int.Parse("abc");
           //Console.WriteLine(value);

            //각 자료형에서 ToString을 이용하여 자료형에서 문자열로 변환
            string text1 = (true).ToString();
            string text2 = (132).ToString();
            string text3 = (1.2).ToString();

            Console.WriteLine(text1);
            Console.WriteLine(text2);
            Console.WriteLine(text3);

            //Console.Write("이름을 입력하세요");
            //string name = Console.ReadLine();
            //Console.WriteLine("안녕하세요 : "+name);

            //Console.WriteLine("숫자를 입력하세요");
            //string inputNum = Console.ReadLine();
            //int.Parse(inputNum);
            //Console.WriteLine(inputNum);


            Console.WriteLine("숫자를 입력하세요");
            string inputNum = Console.ReadLine();
            int.TryParse(inputNum,  out intValue);   
            Console.WriteLine(inputNum);


        }
    }
}
