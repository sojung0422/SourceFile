/*
 bool	참/거짓을 저장하는 타입
 [,]	2차원 배열 (행, 열)
 bool[,]	**"참/거짓 값으로 이루어진 2차원 공간"**을 표현
 사용 예시	맵 정보, 벽 유무, 방문 여부 등


int[,] → 숫자 맵 (아이디, 단계 등)

char[,] → 문자 맵 (미로 모양 출력)

string[,] → 아이템 이름 저장 맵




bool[,] map = new bool[행, 열];
             →           ↑   ↑
             →         (0) (1)

첫 번째 차원 = (0) = 행 (세로)

두 번째 차원 = (1) = 열 (가로)


 */

namespace CCrash
{
    internal class Crash
    {
        public static bool[,] map = new bool[10, 10];//2차원 배열로 (세로, 가로) 칸을 만들 수 있어 -> map[y, x] ← 이렇게 읽어야 해!
        public static void move()
        {
            
            //5행 5열, 총 25개의 칸
            for (int i = 0; i < map.GetLength(0); i++)//행을 만듦
            {
                for(int j =0; j < map.GetLength(1); j++)//열을 만듦 -> 위에서 행이 열의 1을 가지고 가므로 (1)로 시작
                {
                    if(i == 0 || i == map.GetLength(0) - 1)//map.GetLength(0) → 5 (세로줄 개수)
                    {// i == map.GetLength(0) - 1는 아래 가로줄을 의미함 -> 0부터 0, 1, 2, 3, 4이기 때문에 갯수는 5이지만 실제 행의 값은 4이므로 -1함
                        map[i, j] = false;
                        Console.Write("a");
                    }
                    else if(j==0||j==map.GetLength(1) - 1)//map.GetLength(1) → 7 (가로칸 개수)
                    {
                        map[i, j] = false;
                        Console.Write("a");
                    }
                    else
                    {
                        map[i, j] = true;
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();//열을 만든 후 줄바꿈 안하면 그냥 하나로 쭉 나열됨
            }
        }






    }
}
