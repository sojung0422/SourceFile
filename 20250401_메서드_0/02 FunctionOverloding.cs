/**************************************
 오버로딩
 - 같은 이름의 메서드를 매개변수의 타입이나 개수를 다르게 해서 여러 개 정의하는것
 - 같은 기능을 수행하지만 다양한 입력방식이 필요한 경우 유용하게 사용
 -  반환형은 고려하지 않는다.

 성립조건
 -  매개변수의 개수가 다른경우
 -  매개변수의 데이터 타입이 다른경우
 -  매개변수의 순서가 다른경우 
 **************************************/
namespace _20250401
{
    internal class FunctionOverloding
    {

       
        public int Sum(int a, int b)
        {
            return a + b;
        }
        public int Sum(int a, int b, int c)
        {
            return a + b + c;   
        }
        public double Sum(double a, double b, double c)
        {
            return a + b + c;
        }
        public double Sum(double a, int b, double c)
        {
            return a + b + c;
        }
        public double Sum(double a,  double c, int b)
        {
            return a + b + c;
        }

        //배열의 합을 구하는 메서드
        public int SumArray(int[] arr)
        {
            int sum = 0;
            foreach (int num in arr)
            {
                sum+= num;  
            }
            return sum;
        }
        //배열을 출력하는 메서드
        public void PrintArray(int[] arr)
        {
            foreach (int num in arr)
            {
                Console.WriteLine(num+ " ");
            }
            Console.WriteLine();
        }
        static void Main()
        {
            FunctionOverloding program = new FunctionOverloding();
            program.Sum(1, 2);
            program.Sum(1, 2,3);
            program.Sum(1.5, 2.5,3.5);
            program.Sum(1.5, 5,5.3);
            program.Sum(1.5, 5.3,5);

            int[] numbers  = { 1,2,3,4,5};

            Console.WriteLine(program.SumArray(numbers));
            program.PrintArray(numbers);


            //실습
            //더하기, 곱하기, 나누기, 빼기 메서드를 만들고 출력해보아라.
            
        }
    }
}
