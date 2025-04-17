/****************************************************************************
  [사용자 정의 자료형]
    - int, string 등은 기본적으로 제공되는 자료형임
    - 사용자 정의 자료형은 기본적으로 제공되는 자료형 외에 사용자가 직접 정의하여 사용할 수 있는 자료현
    - 열거형, 구조체, 클래스, 인터페이스, 델리게이트 등이 있음.

구조체(struct)
- 데이터와 관련 기능(메서드 = 함수)을 캡슐화할 수 있는 값 형식
- 
 
 
 ***************************************************************************/
//<기본구성>
//struct 구조체 이름
//{
//     멤버변수1
//     멤버변수2
//     메서드
//     메서드2
//}
//-> 구성하기 나름


namespace UserDefineTypes
{
    struct StudentInfo
    {
        public string name;
        public int math;
        public int english;
        public int science;

        public float Average()
        {
            return (math + english + science) / 3.0f;
        }
    }
    struct Point
    {
        public int x;
        public int y;

        //public point()
        //{
        //    x = 0;
        //    y =0;
        //}
    }


    internal class CUserDataTypes
    {
        StudentInfo st = new StudentInfo();

        //st.math = 10;
        //    st.english = 20;
        //    st.science = 30;

        //    Console.WriteLine(st.Average());

        Point point = new Point();
        Cons
    }
}
