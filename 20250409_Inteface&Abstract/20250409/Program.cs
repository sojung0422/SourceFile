namespace _20250409
{

    internal class Program
    {
        static void Main(string[] args)
        {
            BingoGame bingoGame = new BingoGame();
            bingoGame.Start();
        }
    }
    class BingoGame
    {
        private Board board = new Board();
        private int inputNum;

        public void Start()
        {
            board.Shuffle();

            while (true)
            {

                Console.Clear();
                board.ShowBingo();

                Console.Write("입력하시용 :");

                if(!int.TryParse(Console.ReadLine(),out inputNum))
                {
                    continue;
                }
                board.MarkNumber(inputNum);

                if(board.bingoCount==3)
                {
                    Console.WriteLine("이겼당");
                    break;
                }
            }
        }
    }
    class Board
    {
        private int[] bingo = new int[25];

        private const int MARK = 100;

        public int bingoCount { get; private set; }

        //생성자
        public Board() 
        {
            Init();
        }
        public void Init()
        {
            for (int i = 0; i < bingo.Length; i++)
            {
                bingo[i] = i + 1;
            }
        }
        public void Shuffle()
        {
            Random random = new Random();
            for(int i =0;i<100;i++)
            {
                int idx1 = random.Next(25);
                int idx2 = random.Next(25);

                int temp = bingo[idx1];
                bingo[idx1] = bingo[idx2];
                bingo[idx2] = temp;
            }
        }
        public void ShowBingo()
        {
            Console.WriteLine("=========빙고=========");
            Console.WriteLine($"{bingoCount}개 빙고\n");

            for (int i = 0; i < bingo.Length; i++)
            {
                if (bingo[i] == MARK)
                {
                    Console.Write("★\t");
                }
                else
                {
                    Console.Write($"{bingo[i]}\t");
                }
                if ((i + 1) % 5 == 0)
                {
                    Console.WriteLine("\n");
                }
            }
        }
        public void MarkNumber(int number)
        {
            for(int i = 0;i<bingo.Length;i++)
            {
                if (bingo[i] == number)
                {
                    bingo[i] = MARK;
                    break;
                }
            }
            CountBingo();
        }
        public void CountBingo()
        {
            bingoCount = 0;

            //가로
            for(int i = 0;i<5;i++)
            {
                if (IsLineCheck(i * 5, 1))
                {
                    bingoCount++;
                }
            }
            //세로
            for(int i = 0;i<5;i++)
            {
                if(IsLineCheck(i,5))
                {
                    bingoCount++;
                }
            }
            //좌상단->우하단
            if(IsLineCheck(0,6))
            {
                bingoCount++;
            }
            //우상단->좌하단
            if(IsLineCheck(4,4))
            {
                bingoCount++;
            }
        }
        public bool IsLineCheck(int start, int space)
        {
            for(int i = 0;i<5;i++)
            {
                if (bingo[start + i * space] != MARK)
                {
                    return false;
                }
            }
            return true;
        }
          
    }
}
