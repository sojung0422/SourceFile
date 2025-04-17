using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20250402
{
    //숫자맞추기 게임
    //1~100까지 내는거야
    //컴은 내가 낸 숫자를 보고 업인지 다운인지 알려줌

    //메서드는..
    //1. 랜덤 한 숫자를 발생시키는(기능) 메서드
    //2. 유저가 입력받는 메서드
    //3. 업인지 다운인지 알려주는 메서드
    internal class GuessNumbers
    {

        //1. 랜덤 한 숫자를 발생시키는(기능) 메서드

        public int GenerateRandomNumber(in int min, in int max)
        {
            Random random = new Random();
            return random.Next(min, max+1);   
        }
        //2. 유저가 입력받는 메서드
        public void GetUserGuess(ref int guess)
        {
            while (true)
            {
                //if(int.TryParse(Console.ReadLine(), out guess) && guess>=1 && guess <=100)
                //{
                //    break;
                //}

                string input = Console.ReadLine();
                bool isValidNumber = int.TryParse(input, out guess);//입력된 문자열을 정수로 변환시도

                //변환이 성공했으면
                if (isValidNumber) 
                {
                    if(guess>=1 && guess<=100)//1~100사이인지 확인
                    {
                        break;
                    }
                }
                Console.WriteLine("1~100사이의 숫자인지 확인해라 요놈아");
            }
        }
        //3. 업인지 다운인지 알려주는 메서드

        public void PrintHint(params string[] hints) 
        {
            foreach (var hint in hints)
            {
                Console.WriteLine(hint);    
            }
        }

        static void Main()
        {
            GuessNumbers guessNumbers = new GuessNumbers();

            int min = 1;
            int max = 100;  
            int target = guessNumbers.GenerateRandomNumber(min, max);

            int userGuess = 0;
            int count = 0;

            Console.WriteLine("숫자 맞추기 게임 시작!(1~100)");
            while (userGuess!=target)
            {
                //사용자 입력받는거
                guessNumbers.GetUserGuess(ref userGuess);
                Console.WriteLine(userGuess);
                count++;

                if(userGuess<target)
                {
                    guessNumbers.PrintHint("더 큰숫자를 입력해라");
                }
                else if (userGuess > target)
                {
                  guessNumbers.PrintHint("더 작은 숫자를 입력해라");
                }
                else
                {
                  guessNumbers.PrintHint($"정답  : {count}번 만에 맞춤!");
                }
            }
        }
    }
}
