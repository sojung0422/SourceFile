namespace _20250402
{

    /*****************************************************************
     [ref]
     - 값을 변경할 수 있는 참조 전달을 의미
     - 메서드에서 매개변수의 값을 변경하면 호출한 곳에서도 변경이 반영.
     - 메서드 내부에서 매개변수를 읽고 수정가능
     - 메서드를 호출하는 쪽에서 해당 변수의 값을 반드시 할당한 상태여야 함.(초기화 필수)
     - 메서드 내부에서 값을 수정하고 그 변경이 호출할 곳에도 반영되어야 할때 사용

    [ref를 안썼을 경우]
     - 값이 복사되어 메서드 내부에서 변경해도 원본 변수에는 영향을 주지 않는다.

    [in]
     - 읽기 전용 참조전달 의미함.
     - 메서드내부에서 매개변수의 값을 읽을수 있지만 변경은 불가
     - 구조체를 참조로 전달할때 값 복사를 방지하여 성능을 향상시킬수 있음
     -  메서드를 호출하는 쪽에서 해당 변수의 값을 반드시 할당한 상태여야 함.(초기화 필수)

    [out]
     - 메서드에서 값을 반드시 설정해야 하는 참조전달을 의미
     - 여러 개의 값을 반환하거나 초기화 되지 않은 변수를 메서드에서 설정할때 사용
     - 여러개의 값을 반환해야 하는 경우에도 사용
     - 메서드 내부에서 값을 할당해야 함.

    [params]
     - 매개변수 개수를 가변적으로 받을수 있음
     - 배열형태로 값을 전달
     ******************************************************************/



    internal class Program
    {
       public void NoRefFunc(int num)
        {
            num += 10;
            Console.WriteLine($"[함수 내부]num = {num}");
        }

       public void RefFunc(ref int num)
        {
            num += 10;
            Console.WriteLine($"[ref 함수 내부]num = {num}");
        }
        public void InFunc(in int num)
        {
            //num += 10; 읽기 전용 변수 이므로 변경은 불가
            Console.WriteLine(num);
        }
        public void OutFunc(out int a, out int b)
        {
            a = 10;
            b = 20;
        }
        public void Divide(int a, int b, out int num, out int num1)
        {
            num = a / b;
            num1 = a % b;
        }

        public void PrintNumber(params int[] numbers)
        {
            Console.WriteLine("숫자 : ");
            foreach (int num in numbers)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }
        public void NoParamsPrintNumber(int[] numbers)
        {
            Console.WriteLine("숫자 : ");
            foreach (int num in numbers)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
          Program program = new Program();
            //int number = 1;
            //program.NoRefFunc(number);
            //Console.WriteLine(number);

            int a =1;
            program.RefFunc(ref a);
            Console.WriteLine(a);

            int b = 5 ;
            program.InFunc(b);


            int x, y;
            program.OutFunc(out x, out y);  
            Console.WriteLine($"x : {x}, y : {y}");

            int number1;
            int number2;

            program.Divide(10,3,out number1, out number2);
            Console.WriteLine($"몫 : {number1},나머지 : {number2}");


            program.PrintNumber(1,2,3,4,5);
            program.PrintNumber(1,2);

            program.NoParamsPrintNumber([1, 2, 3, 4, 5]);
        }
    }
}
