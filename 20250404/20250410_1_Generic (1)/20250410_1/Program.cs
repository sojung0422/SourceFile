namespace _20250410_1
{

    /***********************************************
     [예외]
     - 프로그램 실행중에 발생하는 비정상적인 상황을 의미
     - 예외 처리를 통해 프로그램이 갑자기 종료되는 것을 방지
     - try-catch를 활용하여 오류를 방지
     - 프로그램이 예상치 못한 상황에서도 안정적으로 동작하도록 도와주는 중요한 기능
     
     ***********************************************/
    internal class Program
    {
        static void Main(string[] args)
        {
            int x = 10;
            int y = 0;

            //0으로 나누기
            //int result = x / y;
            //Console.WriteLine(result);

            //잘못된 배열접근
            //int[] numbers = { 1, 2, 3 };
            //Console.WriteLine(numbers[5]);

            try
            {
                //예외가 발생할수 있는 코드
                int a = 10;
                int b = 0;
                int result = a / b;         //예외 발생
                Console.WriteLine(result);
            }
            //예외가 발생하면 catch 블록실행
            catch(DivideByZeroException ex)
            {
                //예외가 발생했을때 실행할 코드
                Console.WriteLine($"오류 발생 : {ex.Message}");  
            }

            try
            {
                int[] number1 = { 1, 2, 3 };
                Console.WriteLine(number1[5]);
            }
            //catch 블록을 여러개 작성하여 다양한 예외를 구별하여 처리 할수 있음
            catch (DivideByZeroException)
            {

            }
            catch (IndexOutOfRangeException)
            {
                
            }
            //예외 발생여부와 관계 없이 항상 실행
            finally
            {

            }

            string[] inven = { "포션", "폭탄", "열쇠" };

            try
            {
                Console.WriteLine("사용할 아이템 번호를 입력하시오 : ");
                int choice = int.Parse(Console.ReadLine());

                if(choice<0||choice>=inven.Length)
                {
                    throw new IndexOutOfRangeException("잘못된 아이템 번호임");
                }
            }
            catch(FormatException)
            {
                Console.WriteLine("숫자를 입력해야된다.");
            }
            catch(IndexOutOfRangeException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }
    }
}
