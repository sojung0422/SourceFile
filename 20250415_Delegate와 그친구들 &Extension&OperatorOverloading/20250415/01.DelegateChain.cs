/*************************************************
 [DelegateChain]
 - 여러 델리게이트 메서드를 연결해서 하나의 델리게이트 호출로 순차적으로 실행되게 하는 방식
 - 여러 메서드를 한번에 호출할수 있어 이벤트 처리나 특정 작업을 여러 메서드가 동시에 수행할때 유용
 - +=,-= 연산자를 통해 할당을 추가하고 제거할수 있음
 -  = 연산자를 통해 할당할 경우 이전의 다른 메서드를 할당한 상황이 사라짐

[예시]
 - 델리게이트 체인을 통해 여러 행동을 순차적으로 실행하여 캐릭터의 행동구현(이동->자동공격->아이템 사용)
 *************************************************/
namespace _20250415
{
    internal class DelegateChain
    {
        public delegate void MyDel(string msg);
        public static void Method1(string msg) { Console.WriteLine($"메서드 1 : {msg}"); }
        public static void Method2(string msg) { Console.WriteLine($"메서드 2 : {msg}"); }
        public static void Method3(string msg) { Console.WriteLine($"메서드 3 : {msg}"); }
        static void Main()
        {
            MyDel delChain = Method1;
            delChain += Method2;
            delChain += Method3;

            delChain("호출");

            Console.WriteLine();

            delChain -= Method2;
            delChain("두번째 호출");

            Console.WriteLine();
            delChain = Method1;     //=를 이용해 할당할 경우 이전에 참조된 상황이 제거됨.
            delChain("세번째 호출");
        }
    }
}
