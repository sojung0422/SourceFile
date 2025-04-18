using NAnimatedMovie;


namespace NRunning
{
    internal class Running
    {
        AnimatedMovie move = new AnimatedMovie();


        public void Run()
        {
            Console.CursorVisible = false;// 커서 깜빡임 안보이게 설정

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
                Console.SetCursorPosition(4, 10); //y : 4, x : 10에 아래 코드 출력
                Render(playerFrame, true);
                RenderObstacle(true); //장애물 그리기
                //***********아래 다시 공부하기**************************************************>>>>>>>>> 아래 부분은 다시 공부하기
                if (position % 50 == 5) //5단위로 달릴 때마다 -> 105, 110 등
                {
                    Console.SetCursorPosition(0, 13); //장애물이 있던 줄로 커서를 이동
                    Render //3줄의 공백을 공백 포함으로 출력해서 장애물 흔적을 완전히 지워줌
                        (
                        @"       " + '\n' +
                        @"       " + '\n' +
                        @"       ", true
                        );
                    #region
                    /*
                     @ -> “그대로 출력해!” 라는 뜻의 verbatim string (버베이텀 문자열) 기호
                    ㄴ @가 없으면 \n이라는 줄바꿈 문자로 인식

                    ------------------------------------------------------------------------------------

                    Render(
                    @"       " + '\n' +
                    @"       " + '\n' +
                    @"       ", true);

                    위 식은 Render(string image, bool renderSpace) 함수에 전달하는 인자임

                    */
                    #endregion
                }
                #region
                /*
                if (position % 50 < 3)
                ㄴ 장애물을 지나고 0~2까지의 위치에 도달했을 때
                ㄴ 징에믈은 50단위로 등장하며, 50으로 나눈 값의 나머지가 3 미만인 경우는 장애물에 가까이 왔다는 의미임
                 
                 */
                #endregion
                if (position % 50 < 3) //장애물을 지나고 0~2까지의 위치에 도달했을 때
                {
                    Console.SetCursorPosition(4, 10); //커서를 플레이어가 출력될 위치로 이동(캐릭터는 항상 (4, 10)에 그려지는 설정이야)
                    Render(playerFrame, false); //플레이어가 그려지는 위치에 장애물 흔적을 지우고 플레이어를 그려줌

                }
                else
                {
                    RenderObstacle(false); //장애물 흔적을 지우고 플레이어를 그려줌
                    Console.SetCursorPosition(4, 10);
                    Render(playerFrame, false); //플레이어가 그려지는 위치에 장애물 흔적을 지우고 플레이어를 그려줌
                }
                runningFrame = runningFrame.HasValue//★★★★★★★
                    ? (runningFrame + 1) % move.runningAnimation.Length
                    : runningFrame;
                jumpingFrame = jumpingFrame.HasValue//★★★★★★★★
                    ? jumpingFrame + 1
                    : jumpingFrame;
                if(jumpingFrame >= move.jumpingAnimation.Length)//점프애니메이션 길이보다 프레임이 같아지면 다시 0부터 시작
                {
                    jumpingFrame = null; //점프 애니메이션이 끝났으므로 null로 초기화
                    runningFrame = 2;
                }
                position++; //플레이어의 위치를 1 증가시킴
                Thread.Sleep(50); //10ms 대기

            }


            #region 매개변수 사용 및 is 연산자
            /*
             함수란??
            ㄴ 어떤 '기능'을 정해놓은 코드 덩어리
            ㄴ 매개변수는 함수에 전달할 값을 받아주는 '입구' 역할임
            ㄴ '소정, 민수' 같은 값을 함수에 "넣어주는 것"을 → 인자(Argument) 전달

            아래에서 void Render(string @string, bool renderSpace)의 매개변수 값은 다른 함수에서 아래와 같이 쓰임
            ㄴ 아래와 같이 사용되면 renderSpace가 참이나 거짓의 값을 가지게 됨
            Render("ABC", true);  // 공백도 포함해서 출력
            Render("A B C", false); // 공백은 무시하고 출력

            --------------------------------------------------------------------------------------------------

            [CursorTop, CursorLeft]
            ㄴ Console 클래스에 있는 '속성'임
            ㄴ C#이 제공해주는 기능임

             이름	                     의미
             Console.CursorTop	         커서의 현재 세로(y) 위치
             Console.CursorLeft	         커서의 현재 가로(x) 위치

            --------------------------------------------------------------------------------------------------

            [is 연산자란]
            ㄴ a가 b와 같은 값 또는 같은 타입인지 확인하는 연산자
            ㄴ 뒤에 타입이 오느냐 값이 오느냐에 따라 해석이 달라짐
            ㄴ 뒤에 오는 타입이나 값이 앞에 변수와 일치하는지 확인하는 것임
            ㄴ c# 9.0부터는 x is \n도 가능해짐 but, 8.0에서는 기존 방법이 안전함

            형태	                    의미                        	예시                	설명
            x is 타입	            타입 확인	                x is int	        x가 int 타입이냐?
            x is 값	                값 비교 (C# 9부터 지원)	    x is 5	            x의 값이 5냐?
            x == 값	                값 비교	                    x == '\n'	        x가 줄바꿈 문자냐?

            **9.0부터는 !=를 is not으로 쓸 수 있음

             */
            #endregion
            void Render(string image, bool renderSpace) //캐릭터 문자열 출력하는 방식(출력만 담당)-> 매개변수 값에 따라 지우고 그리고 할 수 있음
            {
                int x = Console.CursorLeft; //현재 커서의 가로 위치
                int y = Console.CursorTop; //현재 커서의 세로 위치
                foreach (char imageText in image)
                {
                    if (imageText == '\n') //imageText라는 문자가 줄바꿈(\n)인지 확인하는 조건
                    {
                        Console.SetCursorPosition(x, ++y); //줄바꿈이 맞다면 y좌표를 1 증가시킴 -> y좌표는 1증가시키면 커서가 아래로 이동함(글쓴다는 개념으로 이해하면 될 듯)
                    }
                    else if (imageText != ' ' || renderSpace) //문자가 공백이 아니거나 renderSpace가 true이면 실행
                    {
                        #region 위 조건 설명
                        /*
                        else if(imageText != ' '||renderSpace) 
                        ㄴ ismageText가 공백(스페이스)이 아니거나, renderSpace가 true이면 실행
                        ㄴ 공백이 있어도, renderSpace가 false라면 → 공백은 출력하지 말고 건너뛰어라
                        ㄴ clear를 하는 경우에는 화면 전체가 날아가고 그 위에 다시 그림이 그려지는 것이기 때문에 화면이 깜빡이는 것 처럼 보임
                        ㄴ 캐릭터가 뭉직일 대마다 화면 전체가 지워지니까 위와 같은 현상 생김
                        ㄴ but 화면 전체가 아닌 캐릭터 하나만 지우고 그 위에 그리는 경우에는 깜빡거림 현상이 없음
                        ㄴ 해당 자리에 공백 문자로 덮어쓰는 방식

                        **renderSpace = true인 경우에는 해당 화면 자체를 다 지워버림 -> 기존 캐릭터는 깨지지 않지만, 배경까지 지워질 수 있음
                        **renderSpace = false인 경우에는 공백은 무시하고 지나가기 때문에 기존에 있던 문자가 그대로 남아있음 -> 잘못하면 캐릭터가 깨질 수 있지만, 배경은 유지한 채 진행 가능

                        기능	               공백 무시 (renderSpace = false)	     Console.Clear()
                        지우는 범위	       특정 그림(한 캐릭터)만 부분 지움	     콘솔 전체 화면을 싹 지움
                        효과	               조심스럽게 덮거나 안 보이게 함	         콘솔을 초기화 (화면 리셋)
                        속도/부드러움	       부드럽고 빠르게 애니메이션 가능          갑자기 “화면 번쩍” 지우기
                        위치 유지	       커서 위치, 화면 상태 유지됨	         커서 위치도 (0,0)으로 초기화됨

                        renderSpace = false	                        renderSpace = true
                        공백 ' '은 출력 안 함 → 커서만 이동함	        공백 ' '도 출력해서 실제로 덮음
                        기존 글자가 남을 수 있음	                    기존 글자를 완전히 덮음
                        "조심스럽게 덮기"                         	"진짜 완전히 밀어버리기"

                         */
                        #endregion
                        Console.Write(imageText);
                    }
                    else//imageText가 공백이 맞다면
                    {
                        Console.SetCursorPosition(Console.CursorLeft + 1, Console.CursorTop);  //커서의 가로 위치를 1 증가시킴
                    }
                }
            }
            //-------------------------------------------------------------------------------------- 다시 공부하기
            #region 아래 코드 설명
            /*
            플레이어의 위치(position)에 따라 콘솔 홤녀에 장애물을 출력하는 함수
            bool renderSpace: 공백을 출력할지 여부를 결정하는 옵션

            for (int i = 5; i < Console.WindowWidth - 5; i++)
            ㄴ 화면의 **가로 방향(x축)**을 따라 5부터 끝-5까지 순회
            ㄴ i는 장애물의 위치 후보라고 보면 돼

            ******아래부분 이해 안감...-> 다시 다시 다시 보기*********************************************************

            if (position + i >= 100 && (position + i - 7) % 50 is 0)
            지금 위치에 장애물을 그릴지 말지를 판단하는 조건이야
            
            🔹 position + i >= 100
            플레이어가 100 이상 달렸을 때만 장애물 등장!
            
            🔹 (position + i - 7) % 50 is 0
            장애물은 50칸 간격으로 등장
            
            -7은 장애물 그림의 위치 보정(가운데 정렬 느낌)
            
            ✅ 결과: 장애물이 등장해야 할 위치에 도달했을 때만 true

            **************************************************
            
            Console.SetCursorPosition(i - 3, 13);
            ㄴ 커서를 (x: i-3, y: 13) 위치로 이동
            ㄴ -3도 장애물의 가운데 위치 맞추기 위한 보정
            ㄴ 13: 장애물이 항상 13번째 줄에 출력되도록 고정
            
            Render(move.hurdleFrame, renderSpace);
            ㄴ move: 애니메이션, 프레임 등을 담은 객체 (예: AnimatedMovie 클래스)
            ㄴ hurdleFrame: 장애물 도트 문자열 (string)
            ㄴ renderSpace: 공백도 출력할지 여부 옵션
            
            ✅ 최종적으로 장애물을 그리는 실제 출력 함수 호출!

            *******************************************************************

            */
            #endregion

            void RenderObstacle(bool renderSpace)
            {
                for (int i = 5; i < Console.WindowWidth - 5; i++)
                {
                    if (position + i >= 100 && (position + i - 7) % 50 is 0)
                    {
                        Console.SetCursorPosition(i - 3, 13);
                        Render(move.hurdleFrame, renderSpace);  //->> 허들 바꾸기
                    }
                }
            }



        }

    }
}
