using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
#region 아래 설명
/*
 [시간을 나타내는 구조체]

[ TimeSpan.FromMilliseconds(10) ]
* TimeSpan은 시간 간격을 나타내는 .NET의 구조체
* FromMilliseconds는 TimeSpan 구조체에 있는 함수인데, 숫자(ms)를 넣으면 그에 해당하는 TimeSpan을 만들어줘.
* 여기선 10ms(밀리초, 천분의 1초)를 TimeSpan 객체로 만들어서 왼쪽 변수에 넣고 있어. 

[ TimeSpan threadSleepTimeSpan = TimeSpan.FromMilliseconds(10); ]
* 쓰레드를 10밀리초 동안 잠깐 멈추는 시간을 설정한 변수
* 주로 게임 루프에서 너무 빠르게 돌지 않도록 딜레이를 줄 때 사용

[ TimeSpan helicopterTimeSpan = TimeSpan.FromMilliseconds(70); ]
* 헬리콥터가 움직이거나 애니메이션이 바뀌는 주기를 70ms로 설정
* 0.07초마다 한 번씩 갱신
 
 
[ TimeSpan ufoMovementTimeSpan = TimeSpan.FromMilliseconds(100); ]
* UFO의 움직임 주기를 100ms, 즉 0.1초마다 이동하게끔 정한 거야.

[ TimeSpan enemySpawnTimeSpan = TimeSpan.FromSeconds(1.75); ]
* 적(enemy)이 생성되는 간격을 1.75초로 설정
* 1.75초마다 새로운 적 등장
 
 100ms(=0.1초)
 */
#endregion
TimeSpan threadSleepTimeSpan = TimeSpan.FromMilliseconds(10);
TimeSpan helicopterTimeSpan = TimeSpan.FromMilliseconds(70);
TimeSpan ufoMovementTimeSpan = TimeSpan.FromMilliseconds(100);
TimeSpan enemySpawnTimeSpan = TimeSpan.FromSeconds(1.75);

List<UFO> ufos = new();//ufo 객체 여러 개 저장
List<Bullet> bullets = new(); //총알 저장하는 리스트 -> 한 번에 여러개 날아갈 수 있음
List<Explosion> explosions = new(); //폭발 효과도 여러개 발생할 수 있기 때문에 리스트로 만듦(이미지)
Stopwatch stopwatchGame = new(); //Stopwatch은 시간 측정용 클래스(게임 전체 시간) -> 초시계처럼 시간 측정
Stopwatch stopwatchUFOSpawn = new(); //UFO가 언제 등장했는지, 다음 등장까지 얼마나 남았는지
Stopwatch stopwatchHelicopter = new(); //헬리콥터 움직임의 시간 체크용 타이머
Stopwatch stopwatchUFO = new(); //UFO가 움직이는 간격을 측정할 때 사용할 타이머

int score = 0;//점수집계(점수 저장)
bool bulletFrame = default; //총알을 그릴 지 말지 결정하는데 쓰일 수 있는 상태 변수
bool helicopterRender = default; //헬리콥터를 그릴지 말지(또는 깜빡이는 효과 등)에 관련된 상태를 저장하는 변수

#region Ascii Renders

string[] bulletRenders =
[
    " ", // 0
	"-", // 1
	"~", // 2
	"█", // 3
];

string[] helicopterRenders =
[
	// 0
	@"             " + '\n' +
    @"             " + '\n' +
    @"             ",
	// 1
	@"  ~~~~~+~~~~~" + '\n' +
    @"'\===<[_]L)  " + '\n' +
    @"     -'-`-   ",
	// 2
	@"  -----+-----" + '\n' +
    @"*\===<[_]L)  " + '\n' +
    @"     -'-`-   ",
];

string[] ufoRenders =
[
	// 0
	@"   __O__   " + '\n' +
    @"-=<_‗_‗_>=-",
	// 1
	@"     _!_     " + '\n' +
    @"    /_O_\    " + '\n' +
    @"-==<_‗_‗_>==-",
	// 2
	@"  _/\_  " + '\n' +
    @" /_OO_\ " + '\n' +
    @"() () ()",
	// 3
	@" _!_!_ " + '\n' +
    @"|_o-o_|" + '\n' +
    @" ^^^^^ ",
	// 4
	@" _!_ " + '\n' +
    @"(_o_)" + '\n' +
    @" ^^^ ",
];

string[] explosionRenders =
[
	// 0
	@"           " + '\n' +
    @"   █████   " + '\n' +
    @"   █████   " + '\n' +
    @"   █████   " + '\n' +
    @"           ",
	// 1
	@"           " + '\n' +
    @"           " + '\n' +
    @"     *     " + '\n' +
    @"           " + '\n' +
    @"           ",
	// 2
	@"           " + '\n' +
    @"     *     " + '\n' +
    @"    *#*    " + '\n' +
    @"     *     " + '\n' +
    @"           ",
	// 3
	@"           " + '\n' +
    @"    *#*    " + '\n' +
    @"   *#*#*   " + '\n' +
    @"    *#*    " + '\n' +
    @"           ",
	// 4
	@"     *     " + '\n' +
    @"   *#*#*   " + '\n' +
    @"  *#* *#*  " + '\n' +
    @"   *#*#*   " + '\n' +
    @"     *     ",
	// 5
	@"    *#*    " + '\n' +
    @"  *#* *#*  " + '\n' +
    @" *#*   *#* " + '\n' +
    @"  *#* *#*  " + '\n' +
    @"    *#*    ",
	// 6
	@"   *   *   " + '\n' +
    @" **     ** " + '\n' +
    @"**       **" + '\n' +
    @" **     ** " + '\n' +
    @"   *   *   ",
	// 7
	@"   *   *   " + '\n' +
    @" *       * " + '\n' +
    @"*         *" + '\n' +
    @" *       * " + '\n' +
    @"   *   *   ",
];

#endregion

Console.Clear();
if (OperatingSystem.IsWindows())//OperatingSystem.IsWindows()	현재 프로그램이 윈도우 운영체제에서 실행되고 있는지 확인하는 함수
{
    Console.WindowWidth = 100;
    Console.WindowHeight = 30;
}

int height = Console.WindowHeight;
int width = Console.WindowWidth;
Player player = new() { Left = 2, Top = height / 2, };

Console.CursorVisible = false;  //커서(깜빡이는 | 모양) 를 보이지 않게 설정 + 깔끔한 게임 화면을 위해 커서 숨김 처리
                                //Elapsed	Stopwatch가 작동한 시간의 총합(TimeSpan)
stopwatchGame.Restart();       //Restart()는 Elapsed 시간을 0으로 초기화하고 다시 작동 시작
stopwatchUFOSpawn.Restart();
stopwatchHelicopter.Restart(); //Restart()	메서드 (함수)	시간 초기화 + 다시 시작
stopwatchUFO.Restart();
                               //Stopwatch	클래스 (타입)	시간 측정 기능을 제공하는 객체
while (true)
{
    #region Window Resize

    if (height != Console.WindowHeight || width != Console.WindowWidth)
    {
        Console.Clear();
        Console.Write("Console window resized. Helicopter closed.");
        return;
    }

    #endregion

    #region Update UFOs

    if (stopwatchUFOSpawn.Elapsed > enemySpawnTimeSpan)
    {
        ufos.Add(new UFO
        {
            Health = 4,
            Frame = Random.Shared.Next(5),
            Top = Random.Shared.Next(height - 3),
            Left = width,
        });
        stopwatchUFOSpawn.Restart();
    }

    if (stopwatchUFO.Elapsed > ufoMovementTimeSpan)
    {
        foreach (UFO ufo in ufos)
        {
            if (ufo.Left < width)
            {
                Console.SetCursorPosition(ufo.Left, ufo.Top);
                Erase(ufoRenders[ufo.Frame]);
            }
            ufo.Left--;
            if (ufo.Left <= 0)
            {
                Console.Clear();
                Console.Write("Game Over. Score: " + score + ".");
                return;
            }
        }
        stopwatchUFO.Restart();
    }

    #endregion

    #region Update Player

    bool playerRenderRequired = false;
    if (Console.KeyAvailable)
    {
        switch (Console.ReadKey(true).Key)
        {
            case ConsoleKey.UpArrow:
                Console.SetCursorPosition(player.Left, player.Top);
                Render(helicopterRenders[default], true);
                player.Top = Math.Max(player.Top - 1, 0);
                playerRenderRequired = true;
                break;
            case ConsoleKey.DownArrow:
                Console.SetCursorPosition(player.Left, player.Top);
                Render(helicopterRenders[default], true);
                player.Top = Math.Min(player.Top + 1, height - 3);
                playerRenderRequired = true;
                break;
            case ConsoleKey.RightArrow:
                bullets.Add(new Bullet
                {
                    Left = player.Left + 11,
                    Top = player.Top + 1,
                    Frame = (bulletFrame = !bulletFrame) ? 1 : 2,
                });
                break;
            case ConsoleKey.Escape:
                Console.Clear();
                Console.Write("Helicopter was closed.");
                return;
        }
    }
    while (Console.KeyAvailable)
    {
        Console.ReadKey(true);
    }

    #endregion

    #region Update Bullets

    HashSet<Bullet> bulletRemovals = new();
    foreach (Bullet bullet in bullets)
    {
        Console.SetCursorPosition(bullet.Left, bullet.Top);
        Console.Write(bulletRenders[default]);
        bullet.Left++;
        if (bullet.Left >= width || bullet.Frame is 3)
        {
            bulletRemovals.Add(bullet);
        }
        HashSet<UFO> ufoRemovals = new();
        foreach (UFO ufo in ufos)
        {
            if (ufo.Left <= bullet.Left &&
                ufo.Top <= bullet.Top &&
                CollisionCheck(
                (bulletRenders[bullet.Frame], bullet.Left, bullet.Top),
                (ufoRenders[ufo.Frame], ufo.Left, ufo.Top)))
            {
                bullet.Frame = 3;
                ufo.Health--;
                if (ufo.Health <= 0)
                {
                    score += 100;
                    Console.SetCursorPosition(ufo.Left, ufo.Top);
                    Erase(ufoRenders[ufo.Frame]);
                    ufoRemovals.Add(ufo);
                    explosions.Add(new Explosion
                    {
                        Left = bullet.Left - 5,
                        Top = Math.Max(bullet.Top - 2, 0),
                    });
                }
            }
        }
        ufos.RemoveAll(ufoRemovals.Contains);
    }
    bullets.RemoveAll(bulletRemovals.Contains);

    #endregion

    #region Update & Render Explosions

    HashSet<Explosion> explosionRemovals = new();
    foreach (Explosion explosion in explosions)
    {
        if (explosion.Frame > 0)
        {
            Console.SetCursorPosition(explosion.Left, explosion.Top);
            Erase(explosionRenders[explosion.Frame - 1]);
        }
        if (explosion.Frame < explosionRenders.Length)
        {
            Console.SetCursorPosition(explosion.Left, explosion.Top);
            Render(explosionRenders[explosion.Frame]);
        }
        explosion.Frame++;
        if (explosion.Frame > explosionRenders.Length)
        {
            explosionRemovals.Add(explosion);
        }
    }
    explosions.RemoveAll(explosionRemovals.Contains);

    #endregion

    #region Render Player

    if (stopwatchHelicopter.Elapsed > helicopterTimeSpan)
    {
        helicopterRender = !helicopterRender;
        stopwatchHelicopter.Restart();
        playerRenderRequired = true;
    }
    if (playerRenderRequired)
    {
        Console.SetCursorPosition(player.Left, player.Top);
        Render(helicopterRenders[helicopterRender ? 1 : 2]);
    }

    #endregion

    #region Render UFOs

    foreach (UFO ufo in ufos)
    {
        if (ufo.Left < width)
        {
            Console.SetCursorPosition(ufo.Left, ufo.Top);
            Render(ufoRenders[ufo.Frame]);
        }
    }

    #endregion

    #region Render Bullets

    foreach (Bullet bullet in bullets)
    {
        Console.SetCursorPosition(bullet.Left, bullet.Top);
        Render(bulletRenders[bullet.Frame]);
    }

    #endregion

    Thread.Sleep(threadSleepTimeSpan);
}
//를 붙이면 -> “얘는 변수 이름으로 쓸게!
void Render(string @string, bool renderSpace = false)//문자열을 콘솔 화면에 출력하는 함수. -> bool renderSpace = false	공백도 출력할지 여부 (false면 공백 무시)
{
    int x = Console.CursorLeft; //현재 커서의 가로 위치 저장 -> Console.CursorLeft; 현재 커서의 x 좌표 (가로)
    int y = Console.CursorTop; //현재 커서의 세로 위치 저장 -> 현재 커서의 y 좌표 (세로)
    foreach (char c in @string) //문자열을 문자(char) 단위로 순회
        if (c is '\n')
            Console.SetCursorPosition(x, ++y); //커서를 지정한 위치로 이동 -> x는 가로이기 때문에 유지(가로도 움직이고 싶으면 x도 움++로 바꾸면 되지 않을까?) 
        else if (Console.CursorLeft < width - 1 && (c is not ' ' || renderSpace))
            Console.Write(c); //콘솔에 문자 c를 출력
        else if (Console.CursorLeft < width - 1 && Console.CursorTop < height - 1)
            Console.SetCursorPosition(Console.CursorLeft + 1, Console.CursorTop);
}

void Erase(string @string) //Render로 출력한 글자를 같은 자리에 공백으로 덮어서 지움 -> 총알 등 이동이 있을 때(애니메이션 전환)
{
    int x = Console.CursorLeft;
    int y = Console.CursorTop;
    foreach (char c in @string)
        if (c is '\n')
            Console.SetCursorPosition(x, ++y);
        else if (Console.CursorLeft < width - 1 && c is not ' ')
            Console.Write(' ');
        else if (Console.CursorLeft < width - 1 && Console.CursorTop < height - 1)
            Console.SetCursorPosition(Console.CursorLeft + 1, Console.CursorTop);
}

bool CollisionCheck((string String, int Left, int Top) A, (string String, int Left, int Top) B) //두 문자열 객체가 서로 콘솔 위치상 겹치는지(충돌) 확인
{
    char[,] buffer = new char[width, height];
    int left = A.Left;
    int top = A.Top;
    foreach (char c in A.String)
    {
        if (c is '\n')
        {
            left = A.Left;
            top++;
        }
        else if (left < width && top < height && c != ' ')
        {
            buffer[left++, top] = c;
        }
    }
    left = B.Left;
    top = B.Top;
    foreach (char c in B.String)
    {
        if (c is '\n')
        {
            left = A.Left;
            top++;
        }
        else if (left < width && top < height && c != ' ')
        {
            if (buffer[left, top] != default)
            {
                return true;
            }
            buffer[left++, top] = c;
        }
    }
    return false;
}

class Player
{
    public int Left;
    public int Top;
}

class Bullet
{
    public int Left;
    public int Top;
    public int Frame;
}

class Explosion
{
    public int Left;
    public int Top;
    public int Frame;
}

class UFO
{
    public int Frame;
    public int Left;
    public int Top;
    public int Health;
}