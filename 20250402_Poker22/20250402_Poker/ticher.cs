//선생님 코드(기존에 배웠던 거 활용

namespace _99._homeWork
{
    internal class Program
    {
        static void Main()
        {
            // 난수 생성을 위한 Random 객체 생성
            Random random = new Random();
            Program program = new Program();
            // 52장의 카드 배열 생성 (0~51)
            int[] card = new int[52];

            // 뽑은 3장의 카드의 무늬와 숫자를 저장할 배열
            int[] shape = new int[3];
            int[] number = new int[3];

            // 초기 보유 금액
            int money = 10000;

            // 사용한 카드 수를 추적하는 변수
            int useCard = 0;

            // 카드 초기화 (0~51로 설정)
            program.InitializeDeck(card);

            // 카드 섞기
            program.ShuffleDeck(card, random);

            // 게임 루프 실행
            program.GameLoop(card, shape, number, ref money, ref useCard);


        }

        // 카드 배열을 0~51로 초기화
        public void InitializeDeck(int[] card)
        {
            for (int i = 0; i < card.Length; i++)
                card[i] = i;
        }

        // 카드 배열을 섞는 함수
        public void ShuffleDeck(int[] card, Random random)
        {
            for (int i = 0; i < 500; i++) // 500번 랜덤하게 섞음
            {
                int dest = random.Next(52); // 0~51 중 랜덤한 위치 선택
                int sour = random.Next(52); // 0~51 중 랜덤한 위치 선택

                // 두 위치의 카드를 교환
                int temp = card[dest];
                card[dest] = card[sour];
                card[sour] = temp;
            }
        }

        // 게임을 진행하는 루프
        public void GameLoop(int[] card, int[] shape, int[] number, ref int money, ref int useCard)
        {
            while (true)
            {
                // 카드 3장 뽑기
                DrawCards(card, shape, number, useCard);

                // 뽑은 카드 출력
                DisplayCards(shape, number);

                // 현재 보유 금액 출력
                Console.WriteLine("내가 가진 시드머니  : {0}", money);

                // 배팅 금액 입력 받기
                int betting = Betting(ref money);
                //-1은 예외적인 상황을 나타내는 값으로 일반적으로 사용(즉 베팅이 잘되었라는걸 구분하기 위해)
                if (betting == -1) continue; // 배팅이 잘못되었으면 다시 진행

                // 승패 판정
                CheckWinCondition(number, betting, ref money);

                // 사용한 카드 수 증가
                useCard += 3;
                Console.WriteLine("현재 사용한 카드 수 : {0}", useCard);

                // 모든 카드를 사용하면 게임 종료
                if (useCard >= 51)
                {
                    Console.WriteLine("카드가 없으므로 종료한다");
                    break;
                }
            }
        }

        // 카드 3장 뽑기
        public void DrawCards(int[] card, int[] shape, int[] number, int useCard)
        {
            for (int i = 0; i < 3; i++)
            {
                shape[i] = card[i + useCard] / 13; // 무늬 결정 (0:♠, 1:♣, 2:◆, 3:♥)
                number[i] = card[i + useCard] % 13 + 1; // 숫자 결정 (A~K)
            }
        }

        // 뽑은 카드 출력
        public void DisplayCards(int[] shape, int[] number)
        {
            for (int i = 0; i < 3; i++)
            {
                Console.Write(GetShape(shape[i])); // 무늬 출력
                Console.Write(GetNumber(number[i]) + "\t"); // 숫자 출력
            }
            Console.WriteLine();
        }

        // 숫자를 무늬(♠, ♣, ◆, ♥)로 변환
        public string GetShape(int shape)
        {
            switch (shape)
            {
                case 0: return "♠";
                case 1: return "♣";
                case 2: return "◆";
                case 3: return "♥";
                default: return "?";
            }
        }

        // 숫자를 A~K로 변환
        public string GetNumber(int number)
        {
            switch (number)
            {
                case 1: return "A";
                case 11: return "J";
                case 12: return "Q";
                case 13: return "K";
                default: return number.ToString(); // 2~10 숫자 변환
            }
        }

        // 배팅 입력 받기
        public int Betting(ref int money)
        {
            if (money < 1000)
            {
                Console.WriteLine("파산!! 집으로 돌아가라~");
                Environment.Exit(0);
            }

            Console.Write("목숨값을 베팅하시오! ");
            //if (!int.TryParse(Console.ReadLine(), out int betting) || betting < 1000 || betting > money)
            //{
            //    Console.WriteLine("잘못된 배팅 금액입니다. 다시 입력하세요.");
            //    return -1;
            //}
            string input = Console.ReadLine(); // 사용자 입력을 문자열로 받음
            int betting;
            bool isValidNumber = int.TryParse(input, out betting); // 문자열을 정수로 변환 시도

            if (!isValidNumber) // 변환 실패하면 (숫자가 아니면)
            {
                Console.WriteLine("잘못된 입력입니다. 숫자를 입력하세요.");
                return -1;  // 배팅 실패 처리
            }

            if (betting < 1000) // 배팅 금액이 1000보다 작으면
            {
                Console.WriteLine("최소 배팅 금액은 1000원입니다.");
                return -1;  // 배팅 실패 처리
            }

            if (betting > money) // 배팅 금액이 현재 가진 돈보다 크면
            {
                Console.WriteLine("현재 가진 돈보다 많은 금액을 배팅할 수 없습니다.");
                return -1;  // 배팅 실패 처리
            }
            return betting;
        }

        // 승패 판정
        public void CheckWinCondition(int[] number, int betting, ref int money)
        {
            bool isAscending = number[0] < number[2] && number[2] < number[1];
            bool isDescending = number[0] > number[2] && number[2] > number[1]; /

            if (isAscending || isDescending)
            {
                money += betting; // 배팅 금액만큼 획득
                Console.WriteLine($"{betting} 원을 획득했다");
            }
            else
            {
                money -= betting; // 배팅 금액만큼 잃음
                Console.WriteLine($"{betting} 원을 잃었다");
            }
        }
    }
}

