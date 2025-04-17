using System.Diagnostics;
using System.Text;

namespace _20250403
{
    /*******************************************************
    [string]
    - 참조타입
    - 얘는 클래스임
    - 문자들의 집합으로 표현을 함
    - string클래스는 문자열을 다룰때 자주 사용되며 유용한 메서드와 기능을 제공
    - 문자열은 불변객체 : 문자열이 한 번 생성되면 수정할 수 없음
    ㄴ 문자열은 한 번 생성되면 수정할 수 없음(-> 수정되는 것이 아닌 새로운 객체를 생성한다.)

    [string의 불변성]
    - 다른 기본 자료형과 다르게 크기가 정해져 있지 않음(char의 집합이므로 갯수에 따라 크기가 유동적이기 때문)
    - 따라서 string은 ㅇ런타임 당시에 크기가 결정. 구조체가 아닌 클래스로 구성되어 있음
    - 힙 영역을 쓰기 때문에 한 번 설정하면 변경할 수 없음


     ******************************************************/

    internal class Program
    {
        static void Main(string[] args)
        {

            string str = "홍길동";
            str += "홍길서"; //불변 객체라며, 근데 수정되네?? -> 이건 수정되는 게 아니라 새로운 객체가 생성된다는 뜻임 -> 이어붙이는 거임
            // +=는 연산을 붙인다는 건데, 이런 연산이 계속 이러나면 성능 저하가 이러남 -> 불변객체라는 특성 때문에
            Console.WriteLine(str);

            string s1 = "abcd";
            //문자배열을 이루어져 있기 때문에 인덱스로 접근이 가능
            Console.WriteLine(s1[0]);
            Console.WriteLine(s1[1]);
            Console.WriteLine(s1[2]);

            //읽기 전용이라 수정은 불가함
            //s1[2] = 'f';

            string s2 = "fgh";
            string s3 = s1 + " " + s2;
            Console.WriteLine(s3);

            string str4 = "abcd"; //힙 영역에 abcde문자열이 생성되고 str4가 참조
            str4 = "abc";          // 새로운 힙 영역에 abc가 생성되고 str4는 이름 참조하도록 변경
                                   //기존 abcde는 아무 변수도 참조를 하지 않고 있기 때문에 gc에 의해 정리

            str4 = str4 + "123";    //"abcd" + "1234"연ㅅ나을 수행하여 새로운 힙 영역에 "abc123"ㅇ르 생성
                                    //str4는 "abc123"을 참조하게 되고 기존 abc는 GC가 손실

            string str5 = str4;    //str5는 str4가 참조하는 ***같은 문자열 (abc123)을 참조함

            Console.WriteLine(str4);
            Console.WriteLine(str5);

            Console.WriteLine(ReferenceEquals(str4, str5)); //??


            //abc123def456을 얻어내기 위해 abc버리고 def 버리고 abc123버리고 abc123def 버리게 됨 -> GC가 일을 4번 함
            string str6 = "abc" + 123 + "def" + 456; //+연산자 웬만하면 쓰지 마라 -> GC가 일하니까 성능 저하됨
            Console.WriteLine(str6);

            //스트링 빌더는 새로운 문자열을 안만들고 기존 문자열을 수정함 -> 빠르다는 얘기임

            //스트링 빌더
            //새로운 문자열을 만들지 ㅇ낳고 기존 메모리를 수정하기 때문에 빠름(상황따라 다름)
            //반복적인 조작이 많을 경우 스트링 빌더를 사용하면 성능 상 이점이 있다.

            const int iteration = 300000; //const상수화 시킴
            //iteration = 100; //iteration은 const로 고정시켰기 때문에 값을 바꿀 수 없음

            Stopwatch stringStopWatch = Stopwatch.StartNew(); //Stopwatch는 for문이 도는 시간을 측정해주는 얘임
            
            string resultString = " ";
            for (int i =0; i < iteration; i++)
            {
                resultString += "a";
            }
            stringStopWatch.Stop();
            Console.WriteLine($"스트링 : {stringStopWatch.ElapsedMilliseconds} 초");


            StringBuilder stringBilder = new StringBuilder();

            Stopwatch stringBilderStopWatch = Stopwatch.StartNew();

            for (int i = 0; i < iteration; i++)
            {
                stringBilder.Append("a");
            }
            stringBilderStopWatch.Stop();
            Console.WriteLine($"스트링빌더 : {stringBilderStopWatch.ElapsedMilliseconds}초");



        }
    }
}
