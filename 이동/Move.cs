/*
1. 플레이어 이동 (ConsoleKey) 
2. 단축키 감지 (ConsoleKeyInfo)
3. 텍스트 입력 (이름 입력)

비교 항목	ConsoleKeyInfo	                    ConsoleKey
타입	        구조체 (struct)	                    열거형 (enum)
포함 정보	키, 문자, 조합키                     키 이름 자체만
사용 목적	자세한 입력 정보가 필요할 때        	키가 무엇인지 판별할 때


EX)단축키 감지
ConsoleKeyInfo keyInfo = Console.ReadKey(true);

if ((keyInfo.Modifiers & ConsoleModifiers.Control) != 0 && keyInfo.Key == ConsoleKey.S)
{
    Console.WriteLine("저장 단축키 눌림 (Ctrl + S)");
}


EX)텍스트 입력(이름 입력)
string name = "";

ConsoleKeyInfo keyInfo;
do
{
    keyInfo = Console.ReadKey(true);
    if (char.IsLetterOrDigit(keyInfo.KeyChar))
    {
        name += keyInfo.KeyChar;
        Console.Write(keyInfo.KeyChar);
    }
} while (keyInfo.Key != ConsoleKey.Enter);


 */


using CCrash;

namespace MMove
{
    internal class Move
    {
        Crash crash = new Crash();

        struct Position//struct는 구조체를 정의할 때 사용함
        {
            public int x;
            public int y;
        }
        // 플레이어는 x,y 2개의 값으로 표현됨 but, 구조체가 아닌 int playerX = 5;/  int playerY = 3;로 표현하게 되면 나중에 요소가 많아지면 복잡해짐


        static void Main(string[] args)
        {
            Crash.move();

            Position playerPos;//(ex -> int num;)Position이라는 구조체(또는 클래스) 타입의 변수 pos를 선언한다는 뜻이야.
            playerPos.x = 5;
            playerPos.y = 5;

            Console.CursorVisible = false;// 깜빡이는 커서 숨김 -> CursorVisible는 커서를 숨질 지 말지 설정하는 기능임(false)일 경우 숨겨짐

            while (true)
            {
                Console.Clear();//화면 초기화(깜빡거림 없애기)
                Crash.move();
                Console.SetCursorPosition(playerPos.x, playerPos.y);//SetCursorPosition은 콘솔 창에서 "글자가 출력될 위치(좌표)"를 설정해주는 함수
                Console.Write("★");

                ConsoleKey key = Console.ReadKey(true).Key;

                GameUpDate(key, ref playerPos);
            }
 
        }

        static void GameUpDate(ConsoleKey key, ref Position playerPos)
        {

            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    if (Crash.map[playerPos.y,playerPos.x - 1]==true)
                    {
                        playerPos.x--;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (Crash.map[playerPos.y,playerPos.x + 1]==true)//플레이어의 오른쪽 칸이 이동 가능한지(true) 확인하는 조건이야.
                    {
                        playerPos.x++;
                    }
                    break;
                case ConsoleKey.UpArrow:
                    if (Crash.map[playerPos.y-1,playerPos.x]==true)
                    playerPos.y--;
                    break;
                case ConsoleKey.DownArrow:
                    if (Crash.map[playerPos.y-1,playerPos.x]==true)
                    playerPos.y++;
                    break;
                    //default: 
            }
        }
    }
}
