
/*********************************************
 [정적 클래스]
  - 정적 클래스와 정적멤버는 특정 인스턴스가 아닌 클래스 자체와 연결되는 개념
  - 공통된 기능을 제공하거나, 공유 데이터를 관리할때 사용(클래스 자체가 하나의 전역적인 유틸리티 역할) 
  - 오직 정적 멤버만 포함 가능. 객체(인스턴스)를 생성할 수 없음


구분                          정적                               일반
인스턴스                    불가능                                가능
상속                         불가                                가능
목적                      공통기능제공(수학연산,설정..)            개별 인스턴스 관리
 *********************************************/
namespace _20250408
{
    //정적 클래스
    static class MathUtils
    {
        //int a = 1;
        //public void Print() { }

        public static double Pi = 3.141592;
        public static int Add(int a, int b)
        {
            return a + b;
        }
        public static double CircleArea(double rad)
        {
            return Pi * rad * rad;
        }
    }
    class GameManager
    {
        private static int PlayerCount = 0;
        public static void AddPlayer()
        {
            PlayerCount++;
            Console.WriteLine($"{PlayerCount}");
        }
    }
    internal class _03
    {
        static void Main()
        {
            GameManager.AddPlayer();
            GameManager.AddPlayer();


            while (true)
            {

            }
        }
    }
}
