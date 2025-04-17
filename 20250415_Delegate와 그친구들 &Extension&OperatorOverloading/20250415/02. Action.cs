
/********************************************
 [Action]
  - 반환값이 없는 메서드를 참조하는 델리게이트
  - 매개변수는 없을수도 있고 있다면 최대 16개의 인자를 받을수 있다.

[Action예시]
 - 콜백함수 : 다른 메서드에 작업을 완료한 후 실행할 메서드를 Action으로 전달
 - 이벤트 처리 : 이벤트가 발생했을때 호출할 메서드를 Action으로 전달하여 이벤트가 발생하면 해당 메서드를 실행(버튼 클릭 등)
 - 비동기 처리 :  비동기 작업이 끝난 후 실행될 코드를 Action으로 전달하여 작업이 완료되면 해당 메서드를 실행


[Func]
 - 값을 반환하는 메서드를 참조할때 사용
 - 최소 하나 이사으이 매개변수를 받고 마지막에 반환 타입을 지정
 -  Func<int, int , int> ->두개의 int를 인수로 받아 하나의 int를 반환하는 메서드를 참조

[무명(익명)메서드]
 - 이름이 없는 메서드. 코드 내에서 일시적으로 필요한 메서드를 정의할때 사용
 - 일반적으로 델리게이트나 이벤트 핸들러 등에 직접 전달하는 방식으로 사용

[람다식]
 -  주로 델리게이트나 Func, Action 델리게이트와 사용(=>사용)
 - 코드가 간결.명시적인 스타일의 메서드를 선호할수 있음.

 ********************************************/
namespace _20250415
{
    internal class _02
    {
        public static void PrintMsg()
        {
            Console.WriteLine("하이");
        }
        public static void PrintNumber(int number, string str)
        {
            Console.WriteLine($"{number},{str}");
        }
       static void Main()
        {
            //액션을 사용하여 PrintMsg메서드를 참조
            Action myAction = new Action(PrintMsg);
            myAction();

            Action<int, string> myAction1 = new Action<int, string>(PrintNumber);

            //delegate (int x, int y)요 부분이 익명 메서드
            Func<int, int, int> add = delegate (int x, int y)
            {
                return x + y;
            };

            int res = add(5, 3);
            Console.WriteLine(res);

            //람다식
            Func<int, int, int> Lamda = (x, y) => x + y;
            Console.WriteLine(Lamda);

            //매개변수가없고 반환값이 있는 람다식
            Func<int> getNumber = () => 42;
            Console.WriteLine(getNumber());

            //매개변수가 있고 코드블록이 있는 람다식
            Func<int, int, int> multi = (x, y) =>
            {
                int res = x * y;
                return res;
            };
        }
    }
}
