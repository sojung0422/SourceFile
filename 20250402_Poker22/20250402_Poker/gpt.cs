// 결국 못만듦
// 아래 코드 해석해보기
// 내 머리 한계임


namespace _20250402_Poker
{
    internal class Program
    {
        // 전역 변수: 카드 덱과 현재 뽑는 인덱스
        List<string> cards = new List<string>();
        int currentIndex = 0;

        // 1. 카드 덱 생성 및 셔플 (52장, 조커 제외)
        public void CreateDeck()
        {
            cards.Clear(); //??
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
            string[] suits = { "♥", "◆", "♣", "♠" };

            foreach (string suit in suits) // 기존 했던 거와는 다르지만, 왼쪽 코드는 suite라는 배열에서 카드 한 장을 뽑은 거고, 뽑은 배열의 이름을 suit라고 하겠다는 뜻
            {
                foreach (int num in numbers) // 기존에는 for문을 사용해서 함 for 문을 사용하면 카드를 매열하고 그 중 3가지 카드를 두 배열 섞어서 뽑을 수 있음 - 왜 해당 코드로 작성했는가
                {
                    // 카드 형식: 예 "♥5"
                    cards.Add($"{suit}{num}"); //여기서는 카드 1개를 뽑는거고, for문을 쓰면 52개의 카드 배열을 만들어줌(한 개씩 뽑는게 맞는지랑 왜 이런 코드를 사용했는가?)
                    // foreach는 배열 중 한 장씩 뽑아서 만드는 거라고 알고 있고, Add가 추가한다는 의미인데, 뒤에 만들어진 배열 1개를 cards에 추가하는거 아닌가?? 여기서 52개의 배열이 만들어 지는가??
                }
            }

            // 랜덤 셔플
            Random rand = new Random(); // 얘는 클래스도 아닌데, 왜 클래스를 가져오는 코드로 활용이 되는가? -> Rambom이라는 클래스가 비주얼 스튜디오에 int와 같은 형태로 저장되어 끌어와 쓸 수 있는 건가?? -> 미리 만들어진 클래스를 사용할 수 있게 하는 것인가?
            cards = cards.OrderBy(x => rand.Next()).ToList();
            currentIndex = 0; // 카드 뽑기 시작 인덱스 초기화 : 왜?? -> 초기화하면 해당 값이 어디로 가는가?
        }

        // 2. 카드 3장 뽑기 (컴퓨터 카드 2장, 유저 카드 1장)
        public string[] DrawCards()
        {
            string[] selectedCards = new string[3];
            if (currentIndex + 3 > cards.Count) //currentIndex + 3의 
            {
                return null; // 남은 카드가 부족하면 null 반환 -> null은 값이 없다는 뜻임(존재하지 않는다.)
            }

            for (int i = 0; i < 3; i++)
            {
                selectedCards[i] = cards[currentIndex++]; // cards[currentIndex++]가 뭔지?? -> card리스트에 currentIndex를 1씩 증가시킨다는 거??
                Console.WriteLine($"뽑은 카드: {selectedCards[i]}");
            }
            return selectedCards; //여기서 return하면 해당 값은 어디로 가는가??
        }

        // 3. 카드 문자열에서 숫자만 추출하는 함수
        // 예: "♥5" → 5, "♠10" → 10
        public int ExtractNumber(string card)
        {
            // 문자 중 숫자만 골라내어 문자열로 변환한 후 정수로 파싱
            string numPart = new string(card.Where(char.IsDigit).ToArray());
            return int.Parse(numPart);
        }

        static void Main()
        {
            Program p = new Program();
            p.CreateDeck(); // 카드 덱 생성 및 셔플

            int money = 1000000; // 초기 자금
            int turn = 0;

            // 최대 17턴 동안 게임 진행 (자금 0원 시 종료)
            while (turn < 17 && money > 0)
            {
                Console.WriteLine($"\n[턴 {turn + 1}] 현재 자금: {money}원");
                Console.Write("배팅 금액을 입력하세요: ");
                int bet;
                if (!int.TryParse(Console.ReadLine(), out bet) || bet <= 0 || bet > money)
                {
                    Console.WriteLine("잘못된 배팅 금액입니다. 다시 입력하세요.");
                    continue;
                }

                // 3장 카드 뽑기
                string[] selected = p.DrawCards();
                if (selected == null)
                {
                    Console.WriteLine("남은 카드가 부족합니다. 게임 종료!");
                    break;
                }

                // 카드에서 숫자만 추출 (예: "♥5" → 5)
                int first = p.ExtractNumber(selected[0]);   // 컴퓨터 카드 1
                int second = p.ExtractNumber(selected[1]);  // 컴퓨터 카드 2
                int userCard = p.ExtractNumber(selected[2]);  // 유저 카드

                Console.WriteLine($"상대 카드: {first}와 {second}, 내 카드: {userCard}");

                int min = Math.Min(first, second);
                int max = Math.Max(first, second);

                // 승리 조건: 내 카드가 상대 카드 2장 사이에 있으면 승리 (배팅금만큼 자금 증가)
                if (userCard > min && userCard < max)
                {
                    Console.WriteLine("🎉 승리! 배팅금이 2배로 증가합니다!");
                    money += bet;
                }
                // 비김 조건: 내 카드가 상대 카드와 같은 경우 (배팅금 유지)
                else if (userCard == min || userCard == max)
                {
                    Console.WriteLine("😐 비김! 배팅금은 그대로 유지됩니다.");
                }
                // 패배 조건: 내 카드가 범위를 벗어나면 (배팅금만큼 자금 차감)
                else
                {
                    Console.WriteLine("💥 패배! 배팅금을 잃었습니다.");
                    money -= bet;
                }

                turn++;
            }

            if (money <= 0)
                Console.WriteLine("\n💀 자금이 모두 소진되어 게임 종료!");
            else if (turn >= 17)
                Console.WriteLine("\n🕒 17턴이 지나 게임 종료!");
            else
                Console.WriteLine($"\n게임 종료! 남은 자금: {money}원");
        }
    }
}
