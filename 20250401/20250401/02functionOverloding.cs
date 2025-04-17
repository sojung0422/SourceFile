/*
 오버로딩
- 같은 이름의 메서드를 매개 변수의 타입이나 개수를 다르게 해서 여러개 정의
 - 같은 기능을 수행하지만 다양한 입력방식이 필요한 경우 유용하게 사용
- 반환형은 고려하지 않는다.
 
성립조건
- 매개변수의 개수가 다른 경우
- 매개변수의 데이터 타입이 다른 경우
- 매개변수의 순서가 다른 경우
 */



using System;

namespace _20250401
{
    internal class FunctionOverloding
    {
        //public int AddInt(int a, int b)
        //{
        //    return a + b;
        //}
        //public double AddDouble(double a, double b)
        //{
        //    return a + b;
        //}
        //public double AddDouble(int a, int b, int c)
        //{
        //    return a + b;
        //}
        public int Sum(int a, int b) //함수 매서드 이름은 무조건 대문자로 시작
        {
            return a + b;
        }
        public int Sum(int a, int b, int c)
        {

        }
        public double Sum(double a, double b, double c)
        {

        }
        static void Main()
        {
            FunctionOverloding program = new FunctionOverloding();
            program.Sum(1, 2);
            program.Sum()

        }
    }
}
