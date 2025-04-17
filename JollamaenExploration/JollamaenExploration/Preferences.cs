using NPlayer;
using System.Diagnostics;

namespace NPreferences//환경 설정
{
    

    class Preferences
    {
        TimeSpan threadSleepTimeSpan = TimeSpan.FromMilliseconds(10);//게임 루프나 반복문이 너무 빠르게 실행되지 않도록 잠깐 멈추게 하려고 사용(게임을 while문에 넣고 돌리면 무한 실행 -> CPU를 100% 쓰게 되고 애니메이션이 너무 빠르거나 깜빡이거나 버벅임이 발생함)    
        TimeSpan playerTimeSpan = TimeSpan.FromMilliseconds(70);//플레이어 0.07초마다 움직임(프레임 바뀜)
        TimeSpan wispTimeSpan = TimeSpan.FromMilliseconds(100);//0.1초마다 도깨비불이 움직임(왼쪽으로)
        TimeSpan enemyTimeSpawn = TimeSpan.FromSeconds(1.75);
        #region 위 설명
        /*
        1. TimeSpan	-> 구조체 (struct)
        ㄴ 시간 간격(기간)을 나타내는 데이터 타입
         
        2. TimeSpan.FromMilliseconds(10)
        ㄴ 정적 메서드(static method)**를 호출
        ㄴ FromMilliseconds는 TimeSpan 구조체에 있는 함수
        ㄴ 숫자(ms)를 넣으면 그에 해당하는 TimeSpan을 만듦
         */
        #endregion

        Stopwatch stopwatchGame = new(); //게임 전체 시간 측정
        Stopwatch stopwatchWispAppear = new(); //도깨비불이 나타나는 시간 측정
        Stopwatch stopwatchPlayer = new(); //플레이어 움직임의 시간 체크용 타이머
        Stopwatch stopwatchWisp = new(); //도깨비불이 움직이는 간격 측정
        #region 위 설명
        /*
        Stopwatch	->  클래스(설계도) – 시간 측정을 위한 타입
        Restart()	->  그 객체의 기능(함수/메서드)
        Elapsed	    ->  지금까지 지난 시간(속성)
         */
        #endregion

        public void Size()
        {
            Console.Clear();//화면 지움

            if(OperatingSystem.IsWindows())//윈도우 시스템에서 실행되고 있다면
            {
                Console.WindowWidth = 100; //윈도우 가로 길이 100
                Console.WindowHeight = 30; //윈도우 높이 30
            }

            int Width = Console.WindowWidth; //윈도우의 가로 길이는 wigth에 저장
            int height = Console.WindowHeight; //"

            Player player = new() { Line = 2, Row = height / 2};//height / 2 -> 세로에서 중앙
            #region 위 설명
            /*변수의 타입이 이미 명확할 때, new Player() 대신 new()만 써도 됨
             
             Player player = new Player();
             player.Left = 2;
             player.Top = 15;

            */
            #endregion

        }

        public void Time()
        {
            Console.CursorVisible = false; // 커서 깜빡임 안보이게 설정



        }

        public void Frame()
        {
            int? playerRenders = null; //->>> jump랑 헬리콥터에서 코드 분석 중 ->> 점프에서는 플레이어 프레임 및 충동/ 헬리콥터에서는 움직이는 프렙임 구현(ufo처럼)
        }
    }

    
}
