/*
[월남뽕] 

카드는 총 52장(조커빼고)
◆♠♥♣﻿
각 문양의 A = 1
JQK = 11,12,13
딜러는 2장의 카드를 보여줌
출력은 보일 때는 AJQK만 보여줌
컴퓨터가 냄 - ◆A♠7/내가 냄 - ♥5(이김 but, ♥k인 경우에는 짐)
문양은 상관 없는 것임
문양은 다르지만 같은 숫자가 나오는 경우 - 돈 다시 돌려주는 걸로﻿
내가 낸 숫자도 랜덤
유저는 배팅금 사라지거나 17번 안에 못 끝내면 losedb
한 번 쓴 카드는 두 번 다시 사용 안됨
 
 */

using System.Linq;

namespace _20250402_Poker
{
    internal class Program
    {

        List<string> cards = new List<string>(); //Random shuffle = new Random();///List<string> card = new List<string>();/// Program p = new Program();  ->>> 모두 객체 선언하는 건데, 앞에 붙는 랜덤,과 리스트는 어떤건지?? 그리고 리스트는 왜 작성 타입이 다른지??
        int me;
        

        //1. 문자 배열
        public void Number()
        {
            int[] number = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
            string[] space = { "♥", "◆", "♣", "♠" };

            //문자 배열 [][]
            for (int i = 0; i < space.Length; i++) //space.Length은 space 배열의 길이 (0~12)
            {
                for(int a = 0; a< number.Length; a++)
                {
                    cards.Add($"{space[i]}{number[a]}"); // space[i]에서 [i]의 의미??????  ->>  Add는 추가한다는 뜻임  ->> 여기에 {}+{}문자열 형태이면 Substring(2)로 잘라도 정수로 변환이 불가함    
                }
            }
            //셔플
            Random shuffle = new Random();
            cards = cards.OrderBy(x => shuffle.Next()).ToList(); //이 부분은 다시 공부하기  --  card는 위에서 두 배열을 합친 정렬등을 담고 있는 리스트임 -> 라는 리스트에서 뽑아서 쓰기
            //OrderBy(x => shuffle.Next()) 얘가 shuffle.Next() 기준으로 리스트를 셔플하는 애/ ToList()가 셔플 결과를 List<string>로 저장                                        
        }

        //출력
        public string[] Output()
        {
            string[] selectedCards = new string[3]; //new string[3] 문자열을 3개 저장할 수 있는 배열  -->>  []에 아무것도 안쓰면 무한으로 배열을 저장할 수 있나?? 

            for (int i =0; i < 3; i++)
            {
                selectedCards[i] = cards[i]; //?? 여기서 card는 다른 함수에 있는데, pubilc 함수에 있는 거라서 가져오는게 가능한가??
                Console.WriteLine(cards[i]); // cards라는 리스트에서 정렬된 배열을 순차적으로 뽑음
            }
            return selectedCards; // selectedCards에의 배열 값을 반환함
        }

        static void Main()
        { 
            Program p = new Program();

            
            for(int i = 0; i < 18; i++)
            {
                p.Number(); // 카드 만들고 셔플

                string[] selected = p.Output(); // 카드 3장 받아오기

                //// 숫자만 추출
                //int first = int.Parse(selected[0].Substring(2));  // "♥ + 5"에서 "5"
                //int second = int.Parse(selected[1].Substring(2)); // "♣ + 10"에서 "10"
                //int user = int.Parse(selected[2].Substring(2));   // "♠ + 9"에서 "9"

                // 비교
                int min = Math.Min(first, second);
                int max = Math.Max(first, second);

                if (user > min && user < max)
                {
                    Console.WriteLine(" 승리! 가운데에 들어왔습니다.");
                }
                else if (user == min || user == max)
                {
                    Console.WriteLine(" 비김! 숫자가 같아요.");
                }
                else
                {
                    Console.WriteLine(" 패배! 범위를 벗어났습니다.");
                }

            }


            //p.Number(); // 카드 만들고 셔플

            //string[] selected = p.Output(); // 카드 3장 받아오기

            //// 숫자만 추출
            //int first = int.Parse(selected[0].Substring(2));  // "♥ + 5"에서 "5"
            //int second = int.Parse(selected[1].Substring(2)); // "♣ + 10"에서 "10"
            //int user = int.Parse(selected[2].Substring(2));   // "♠ + 9"에서 "9"

            //// 비교
            //int min = Math.Min(first, second);
            //int max = Math.Max(first, second);

            //if (user > min && user < max)
            //{
            //    Console.WriteLine("🎉 승리! 가운데에 들어왔습니다.");
            //}
            //else if (user == min || user == max)
            //{
            //    Console.WriteLine("😐 비김! 숫자가 같아요.");
            //}
            //else
            //{
            //    Console.WriteLine("💥 패배! 범위를 벗어났습니다.");
            //}













            //for (int i = 0; i < 18; i++)
            //{
            //    Console.WriteLine(p.Number(num));
            //}



        }
    }
}


//int[][] computer = new int[4][];
//computer[0] = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
//computer[1] = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
//computer[2] = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
//computer[3] = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };

//int[][] me = new int[4][];
//me[0] = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
//me[1] = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
//me[2] = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
//me[3] = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
//            ?????




//int[] number = new int[52];

//// 카드 배열
//for (int i = 0; i < 52; i++)
//{
//    number[i] = i + 1; //값이 할당된 변수이기 때문에 int 안 붙여도 됨
//}
//// 랜덤 섞기
//for (int i = 0; i <= 52; i++)
//{
//    int dest = rand.Next(0, 52);
//    int sour = rand.Next(0, 52); //값이 할당되지 않았기 때문에 int가 붙음

//    temp = number[dest];
//    number[dest] = number[sour];
//    number[sour] = temp;

//}
//int order = 0;
//for (int i = 0; i < 3; i++)
//{
//    Console.WriteLine($"컴퓨터가 뽑은 수는 : {number[i]} 입니다.");
//    order = number[i];
//}



//public int ReandomNumber(in int[] nuumber)
//{
//    int[] number = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
//}
//public string RandShape(in string[] shape)
//{
//    string[] shape = {♥, ♠, ♣, ◆};
//}



//foreach (string card in cards) //여기서 card는 어떻게 생성되는건지 여기서 지정?? -> num이 아니라 뽑는 곳이 cards인 이유??
//   {
//       Console.WriteLine(card);
//   }



////2. 랜덤 섞기
//public void Random(int[] ran)
//{


//}


//int numberbox = shuffle.Next(number.Length);
//int spacebox = shuffle.Next(space.Length);