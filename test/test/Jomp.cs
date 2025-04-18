using System;
using System.Threading;

string[] runningAnimation =
[
	#region Frames
	// 0
	@"       " + '\n' +
    @"       " + '\n' +
    @"  __O  " + '\n' +
    @" / /\_," + '\n' +
    @"__/\   " + '\n' +
    @"    \  ",
	// 1
	@"       " + '\n' +
    @"       " + '\n' +
    @"   _O  " + '\n' +
    @"  |/|_ " + '\n' +
    @"  /\   " + '\n' +
    @" /  |  ",
	// 2
	@"       " + '\n' +
    @"       " + '\n' +
    @"    O  " + '\n' +
    @"  </L  " + '\n' +
    @"   \   " + '\n' +
    @"   /|  ",
	// 3
	@"       " + '\n' +
    @"       " + '\n' +
    @"   O   " + '\n' +
    @"   |_  " + '\n' +
    @"   |>  " + '\n' +
    @"  /|   ",
	// 4
	@"       " + '\n' +
    @"       " + '\n' +
    @"   O   " + '\n' +
    @"  <|L  " + '\n' +
    @"   |_  " + '\n' +
    @"   |/  ",
	// 5
	@"       " + '\n' +
    @"       " + '\n' +
    @"   O   " + '\n' +
    @"  L|L  " + '\n' +
    @"   |_  " + '\n' +
    @"  /  | ",
	// 6
	@"       " + '\n' +
    @"       " + '\n' +
    @"  _O   " + '\n' +
    @" | |L  " + '\n' +
    @"   /-- " + '\n' +
    @"  /   |",
	#endregion
];

string[] jumpingAnimation =
[
	#region Frames
	// 0
	@"       " + '\n' +
    @"       " + '\n' +
    @"   _O  " + '\n' +
    @"  |/|_ " + '\n' +
    @"  /\   " + '\n' +
    @" /  |  ",
	// 1
	@"       " + '\n' +
    @"       " + '\n' +
    @"       " + '\n' +
    @"    O  " + '\n' +
    @"  </L  " + '\n' +
    @"   /|  ",
	// 2
	@"       " + '\n' +
    @"    /O/" + '\n' +
    @"    /  " + '\n' +
    @"   //  " + '\n' +
    @"  //   " + '\n' +
    @"       ",
	// 3
	@"  __O__" + '\n' +
    @" /     " + '\n' +
    @"//     " + '\n' +
    @"       " + '\n' +
    @"       " + '\n' +
    @"       ",
	// 4
	@"  __   " + '\n' +
    @" // \O " + '\n' +
    @"     \\" + '\n' +
    @"       " + '\n' +
    @"       " + '\n' +
    @"       ",
	// 5
	@"  __   " + '\n' +
    @" //_O\ " + '\n' +
    @"       " + '\n' +
    @"       " + '\n' +
    @"       " + '\n' +
    @"       ",
	// 6
	@"  __\  " + '\n' +
    @" _O/   " + '\n' +
    @"       " + '\n' +
    @"       " + '\n' +
    @"       " + '\n' +
    @"       ",
	// 7
	@" \O\__ " + '\n' +
    @"     \\" + '\n' +
    @"       " + '\n' +
    @"       " + '\n' +
    @"       ",
	// 8
	@"       " + '\n' +
    @"       " + '\n' +
    @"   O   " + '\n' +
    @"  L|L  " + '\n' +
    @"   |_  " + '\n' +
    @"  /  | ",
	#endregion
];

string hurdleFrame =
#region Frame
    @"  ___  " + '\n' +
    @" |   | " + '\n' +
    @" | . | ";
#endregion

int position = 0; //게임에서 플레이어가 달린 거리를 의미
int? runningFrame = 0;//현재 달리는 중이고, 첫 번재 프레임임 -> 처음 시작부터 달리기 때문에
int? jumpingFrame = null; //int?는 nullable int, 즉 숫자도 되고, null도 되는 자료형 -> 현재 점푸 중이 아님(대기 상태)
#region 삼항 연산자 -> 조건 ? 참일 때 값 : 거짓일 때 값
/*
조건 ? 참일 때 값 : 거짓일 때 값
"조건이 맞으면 → A, 아니면 → B" 를 한 줄로 표현하는 거야

int age = 20;
string result = age >= 19 ? "성인입니다" : "미성년자입니다";
Console.WriteLine(result);

그래서 삼(3)항 연산자라고 불러
*/
#endregion 

Console.CursorVisible = false;
if (OperatingSystem.IsWindows())
{
    Console.WindowWidth = 120;
    Console.WindowHeight = 20;
}
Console.Clear();
while (position < int.MaxValue)
{
    if (Console.KeyAvailable) //Console.KeyAvailable -> 지금 눌린 키가 있는가?? -> 현재 키보드에서 입력 대기 중인 키가 있는지 확인
    {
        switch (Console.ReadKey(true).Key) //어떤 키가 눌렸는지 확인 -> true일 경우	즉시 Console.ReadKey() 호출 가능
        {
            case ConsoleKey.Escape: //Escape -> 탈출하다(ESC키 누르면)
                Console.Clear(); //Console.Clear()	콘솔 화면을 지움
                Console.Write("Hurdles was closed."); //게임 종료 메세지 출력
                return;// 이 함수 (혹은 루프) 즉시 종료 → 게임 끝!
            case ConsoleKey.UpArrow:
                if (!jumpingFrame.HasValue) //지금 점프 중이 아니라면 (null이라면) ->>  HasValue는 null 체크를 확실하게 해주고, jumpingFrame.Value로 값을 쓸 때도 null이 아님을 보장해줘!
                {
                    jumpingFrame = 0; //점프 애니메이션 시작 (0번째 프레임부터)
                    runningFrame = null; //달리기 애니메이션 중단
                }
                break;
        }
    }
    if (position >= 100 && // ① 위치가 100 이상이고
        position % 50 is 0 && // ② 50 간격마다 장애물 위치이고
        (!jumpingFrame.HasValue || // ③ 점프 중이 아니거나
        !(2 <= jumpingFrame && jumpingFrame <= 7))) // ④ 점프 중이지만 타이밍이 틀렸다면
    {
        Console.Clear(); //화면을 지우고
        Console.Write("Game Over. Score " + position + "."); //게임 오버를 출력
        return;
    }
    string playerFrame =
        jumpingFrame.HasValue ? jumpingAnimation[jumpingFrame.Value] :
        runningAnimation[runningFrame!.Value];
    Console.SetCursorPosition(4, 10);
    Render(playerFrame, true);
    RenderHurdles(true);
    #region jumpingAnimation과 jumpingFrame 연결 설명
    /*
    string[] jumpingAnimation = [...];       // 0~8까지 프레임 9개 있음
    int? jumpingFrame = null;                // 아직 점프 안 한 상태
    
    // 점프 시작할 때:
    jumpingFrame = 0;                        // 점프 애니메이션 시작

    string playerFrame = jumpingAnimation[jumpingFrame.Value];


    jumpingFrame.Value는 현재 몇 번째 장면을 출력할지 나타냄
    배열의 인덱스니까 → jumpingAnimation[0], jumpingAnimation[1] ...
    이렇게 애니메이션 프레임을 한 장면씩 순서대로 출력하는 구조야!
     */
    #endregion

    if (position % 50 is 5)
    {
        Console.SetCursorPosition(0, 13);
        Render(
            @"       " + '\n' +
            @"       " + '\n' +
            @"       ", true);
    }
    if (position % 50 < 3) //깜빡임 방지
    {
        Console.SetCursorPosition(4, 10);
        Render(playerFrame, false);
        RenderHurdles(false);
    }
    else
    {
        RenderHurdles(false);
        Console.SetCursorPosition(4, 10);
        Render(playerFrame, false);
    }
    runningFrame = runningFrame.HasValue
        ? (runningFrame + 1) % runningAnimation.Length
        : runningFrame;
    jumpingFrame = jumpingFrame.HasValue
        ? jumpingFrame + 1
        : jumpingFrame;
    if (jumpingFrame >= jumpingAnimation.Length)
    {
        jumpingFrame = null;
        runningFrame = 2;
    }
    position++;
    Thread.Sleep(TimeSpan.FromMilliseconds(80));
}
Console.Clear();
Console.Write("You Win.");

void Render(string @string, bool renderSpace)
{
    int x = Console.CursorLeft;
    int y = Console.CursorTop;
    foreach (char c in @string)
        if (c is '\n') Console.SetCursorPosition(x, ++y);
        else if (c is not ' ' || renderSpace) Console.Write(c);
        else Console.SetCursorPosition(Console.CursorLeft + 1, Console.CursorTop);
}

void RenderHurdles(bool renderSpace)
{
    for (int i = 5; i < Console.WindowWidth - 5; i++)
    {
        if (position + i >= 100 && (position + i - 7) % 50 is 0)
        {
            Console.SetCursorPosition(i - 3, 13);
            Render(hurdleFrame, renderSpace);
        }
    }
}