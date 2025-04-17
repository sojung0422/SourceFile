namespace _20250411
{
    /***********************************************************
    [stack]
     - LIFO(LastInFirstOut)구조를 따르는 자료구조. 즉 마지막에 들어온 데이터가 가장 먼저 나간다.
     - 내부적으로 동적배열을 사용하여 구현되어 있음.
     - 즉, 요소를 추가를 할때 만약 내부 배열이 부족할 경우 더 큰 배열을 할당하고 기존 데이터를 복사
     - DFS(깊이 우선 탐색), 역순처리, 되돌리기 등에 사용될수 있음.
     
   
     ***********************************************************/
    internal class Program
    {
        static void Main(string[] args)
        {
            //스택생성
            Stack<string> stack = new Stack<string>();

            stack.Push("책1");
            stack.Push("책2");
            stack.Push("책3");

            Console.WriteLine($"현재 스택 : {stack.Count}");
            Console.WriteLine();

            //특정 데이터가 있는지 확인
            Console.WriteLine($"{stack.Contains("책3")}");
            //모든 요소 제거
            stack.Clear();
            Console.WriteLine($"현재 스택 : {stack.Count}");



            //스택의 맨위 요소를 반환(삭제 X)
            Console.WriteLine($"{stack.Peek()}");
            Console.WriteLine();

            Console.WriteLine($"현재 스택 : {stack.Count}");
            Console.WriteLine();

            //스택의 맨 위 요소 제거 및 반환
            Console.WriteLine($"{stack.Pop()}");
            Console.WriteLine();

            Console.WriteLine($"현재 스택 : {stack.Count}");
            Console.WriteLine();

            Stack<int> stack1 = new Stack<int>();

            for(int i = 1; i<=10;i++)
            {
                stack1.Push( i );

                Console.WriteLine($"Push({i})--->Count :{stack1.Count}");
            }

            
        }
    }
}
