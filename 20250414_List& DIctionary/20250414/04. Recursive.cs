/**************************************
 [Recursive]
 - 재귀함수는 자기 자신을 호출하는 함수를 의미. 특정 문제를 더 작은 문제로 나누어 해결할때 유용하게 사용
 - DFS(깊이 우선 탐색),분할 정복 알고리즘 등에 사용

[재귀 함수의 기본 구조]
 1. 기저조건(종료조건) : 
 ㄴ이 조건이 충족되면 함수는 더이상 자기자신을 호출하지 않고 종료
 ㄴ모든 재귀 함수는 적어도 하나 이상의 종료 조건이 있어야됨.

2. 재귀단계
 ㄴ 함수가 자기 자신을 호출하는 단계. 이 단계에서 더 작은 하위 문제로 분해


[재귀를 사용한 경우]
 - 코드가 간결해짐
 - 문제의 구조를 그대로 코드로 표현이 가능함.


[재귀를 사용하지 않은 경우]
 - 속도가 더 빠름
 - 일부 문제는 반복문보다 재귀가 더 직관적일수 있음.
 **************************************/

namespace _20250414
{
    internal class _04
    {

        //팩토리얼 : n부터 1까지의 모든 정수의 곱
        //재귀X

        static int FactorialIter(int n)
        {
            int result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }
        //재귀
        static int RecursiveFactorial(int n)
        {
            //종료조건
            if (n <= 1) return 1;

            return n * RecursiveFactorial(n - 1);
        }
        //위 함수의 호출단계
        //1.첫번째 호출 : RecursiveFactorial(3)에서 종료조건을 확인후
        //n이 1보다 크므로 3* RecursiveFactorial(2)를 리턴하려고함.
        //2.두번째 호출  : RecursiveFactorial(2)호출
        //마찬가지로 n이 1보다 크기 때문에 RecursiveFactorial(1)를 리턴하려고 함.
        //3. 세번째 호출 :  RecursiveFactorial(1)를 호출 :  이번엔 종료조건을 만족하므로 1을 반환

        // RecursiveFactorial(1) -> 1를 반환
        //RecursiveFactorial(2)-> 2*1반환
        //RecursiveFactorial(3) -> 3*2를 반환
        static void Main()
        {
            Console.WriteLine(FactorialIter(3));
            Console.WriteLine(RecursiveFactorial(3));
        }
    }
}
