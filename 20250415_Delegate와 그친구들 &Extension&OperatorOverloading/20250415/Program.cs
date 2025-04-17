/************************************************************
 델리게이트(대리자)
  - 특정 매개변수 목록 및 반환형식이 있는 함수에 대한 참조
  - 대리자를 통해 함수를 호출할수 있음.
  - 참조형 변수로, 실행할 메서드를 동적으로 설정하고 호출
  - 주로 이벤트 처리, 콜백에서 사용
 
[문법]
public delegate 반환형 델리게이트이름(매개변수);
 ************************************************************/


namespace _20250415
{
   
    internal class Program
    {
        #region 델리게이트1
        //델리게이트 선언(생겨먹은 메서드랑 비스무리하게 생겨먹음)
        public delegate int MyDel(int a, int b);

        static int Plus(int a, int b)
        {
            return a + b;
        }
        static int Minus(int a, int b)
        {
            return a - b;
        }
        #endregion
        public delegate float DelegateMethod1(float x, float y);
        public delegate void DelegateMethod2(string str);

        public static float Plus(float left, float right) { return left + right; }
        public static float Minus(float left, float right) {return left - right; }
        public static float Multi(float left, float right) { return left * right; }
        public static float Divide(float left, float right) { return (left / right); }

        public static void Message(string message) { Console.WriteLine(message); }
        static void Main(string[] args)
        {
            #region 델리게이트1
            MyDel callback;
            callback = new MyDel(Plus);
            Console.WriteLine(callback(3, 4));
            #endregion

            DelegateMethod1 delegate1 = new DelegateMethod1(Plus);  //델리게이트 생성
            DelegateMethod2 delegate2 = Message;                    //간략한 문법의 델리게이트 생성

            delegate1(20, 10);
            delegate1.Invoke(20, 10);   //Plus(20,10);
            delegate2("메세지");           //Message("메세지");
        }
    }
}
