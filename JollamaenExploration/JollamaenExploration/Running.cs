using NAnimatedMovie;


namespace NRunning
{
    internal class Running
    {
        AnimatedMovie move = new AnimatedMovie();


        public void Run()
        {
            int position = 0; //플레이가 달린 거리
            int? runningFrame = 0; //플레이어가 달리는 중임(처음부터 이렇게 나옴)
            int? jumpingFrame = null; //현재 점푸 중이 아님(대기 상태) -> 점프 애니메이션 중 몇 번째 프레임을 보여줄 차례인지 기억하는 변수(프레임 인덱스 역할)
            //위에 int?는 null이 될 수 있는 정수를 나타냄 -> 점프가 아닌 상태에는 프레임이 들어가지 않으므로 null처리가 되어야 함
            while (position < int.MaxValue) //플레이어의 거리가 max 거리를 달성하면 종료 -> MaxValue는 int 형이 가질 수 있는 가장 큰 수를 나타내는 상수 필드
            {
                #region Console.KeyAvailable 의미
                /*
                [Console.KeyAvailable]
                 “지금 키보드 입력이 대기 중인가요?” 라고 물어보는 질문 속성

                  구분	   함수 (Method)	        속성 (Property)
                  형태	   Something()	        Something
                  예시	   Console.ReadKey()	Console.KeyAvailable
                  뜻	       실행을 하라!	        값을 알려줘!
                  괄호()	   반드시 있어야 함	    ❌ 없음!
                 */
                #endregion
                if (Console.KeyAvailable) // 키가 눌리면
                {
                    #region
                    /*
                     ReadKey()는 ConsoleKeyInfo라는 정보를 반환
                    .Key는 그 안에 포함된 **"무슨 키가 눌렸는지"**에 해당하는 값
                     */
                    #endregion
                    switch (Console.ReadKey(true).Key) //어떤 키가 눌렸는지 확인
                    {
                        case ConsoleKey.Escape: //Esc 키를 누르면
                            Console.Clear(); //화면을 지우고
                            Console.WriteLine("게임을 종료합니다."); //게임 종료 메시지 출력
                            return; //프로그램 종료
                        case ConsoleKey.UpArrow: //up키를 누르면
                            if(!jumpingFrame.HasValue) //점프 중이 아니라면 -> HasValue	값이 있는지 검사 (true or false) -> Value	실제 값을 꺼내서 사용 (단, null이면 예외 발생!)
                            {
                                jumpingFrame = 0; //점프 애니메이션 시작
                                runningFrame = null; //달리기 애니메이션 중지
                            }
                            break;
                    }
                }
                #region 아래 코드 설명
                /*
                100, 150, 200 같은 위치에서 장애물이 등장
                -> !jumpingFrame.HasValue에서 HasValue는 ~값이 있는지 검사, 이때 !는 부정이기에 점프를 안했거나
                
                ! (부정 NOT 연산자)는 항상 "논리값(bool)"에만 붙일 수 있어!
                그리고 그 전체 조건문 앞에 붙이는 거야
                
                [예외]
                !jumpingFrame.HasValue는 전체 조건을 부정하는 게 아니라,
                HasValue라는 속성 자체의 결과(true 또는 false)를 부정하는 것이기 때문에
                👉 속성 바로 앞에 !를 붙이는 게 맞아!

                -------------------------------------------------------------------------------------------------

                position >= 100 && position % 50 == 0 &&
                ㄴ 장애물은 포지션 100보다 높을 때부터 등장함
                ㄴ 장애물은 50단위롤 등장함
                 -> 점프 상황에서 아래 조건이 일치하는 경우 죽음

                (!jumpingFrame.HasValue || !(2 <= jumpingFrame && jumpingFrame <= 7)))
                ㄴ 점프가 이루어지지 않았거나 점프가 이루어졌지만 타이밍이 맞지 않을 때
                ㄴ 2~7까지가 점프 기준인 이유 -> 점프 애니메이션(jumpingAnimation[]) 배열의 구조 때문 (2~7까지가 점프 프레임임)

                */
                #endregion
                if (position >= 100 && position % 50 == 0 &&
                    (!jumpingFrame.HasValue || !(2 <= jumpingFrame && jumpingFrame <= 7)))
                {
                    Console.Clear();//화면을 지우고
                    Console.Write($"Game Over!\nScore {position}");
                    return; //프로그램 종료
                }
                #region 삼항 연산자 & !용도
                /*
                 ? -> 삼항 조건 연산자 -> jumpingFrame.HasValue가 참일 때 
                 [jumpingFrame.Value] ://배열에서 인덱스 접근! → "몇 번째?"를 지정하는 부분
                 ㄴ 일정 숫자르 ㄹ넣으면 고정된 프레임이 나오지만 위 처럼 쓰면 매번 바뀌는 프레임 값에 따라 유연하게 사용 가능
                 ㄴ jumpingFrame은 계속해서 값이 바뀌기 때문에,매 순간마다 다른 프레임을 꺼낼 수 있는 "열쇠(key)" 역할

                 ------------------------------------------------------------------------------------------------------------

                [!의 용도]
                1. 논리 부정 (not) -> !true == false ->	조건 반전 (일반적인 의미)
                2. null-forgiving operator -> runningFrame!.Value	컴파일러에게 “null 아님을 보장한다”고 알려주는 용도! 
                ㄴ 변수나 표현식 뒤에 붙음
                ㄴ 아래 코드 runningFrame!.Value에서 (!)는 null-forgiving operator이라고 부름
                ㄴ 나 이거 null 아닌 거 확실해! 걱정 말고 써   라는 뜻

                **아래서 !를 사용하여 안정성을 확보하는 이유
                ㄴ null인 경우 .Value를 쓰면 프로그램이 실행 중에 바로 터짐
                 */
                #endregion
                string playerFrame =
                    jumpingFrame.HasValue ? move.jumpingAnimation[jumpingFrame.Value] ://배열에서 인덱스 접근! → "몇 번째?"를 지정하는 부분
                    move.runningAnimation[runningFrame!.Value];
                #region SetCursorPosition 설명
                /*
                System.Console 클래스 안에 포함된 함수(wjdwjr aptjem)
                -> 콘솔 화면에서 출력한 커서 위치를 이동시키는 역할
                 
                Console.SetCursorPosition(int left, int top)
                ㄴ 매개변수	left = X 좌표 (가로), top = Y 좌표 (세로)

                [예시]
                Console.SetCursorPosition(10, 5);  ->  (y, x)임
                Console.Write("🐱"); // 10칸 오른쪽, 5줄 아래에 고양이 출력
                
                [좌표계]
                (0,0) ← ← ← ← ← x
                 |
                 ↓
                 y
                 
                 */
                #endregion
                Console.SetCursorPosition(4, 10);
            }
        }
        

        
    }
}
