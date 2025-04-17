using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20250403
{
    internal class StringMethod
    {
        static void Main()
        {
            string str = "Hello Wold Game";
            //indexOf : 현재 문자열 내에서 차지하는 지정된 문자 또는 문자열의 위치를 찾음. 대소문자 구분. 실패(찾을 수 없으면)하면 -1를 리턴
            //LastIndexOf : 위와 동일하지만, 뒤에서부터..
            //StartsWith : 해당문자열로 시작하냐
            //EndsWith : 해당 문자열로 끝나냐
            //Contains : 현재 문자열을 포함하고 있냐
            //Replace : 현재 문자열에서 저장된 문자열이 다른 지정된 문자열이 다른 지정된 문자열로 바뀌어 저장


            // -1은 실패를 의미함
            Console.WriteLine(str.IndexOf("Game")); //게임이라는 문자열이 어디서부터 시작하는가??
            Console.WriteLine(str.IndexOf("w"));

            Console.WriteLine(str.LastIndexOf("Hello")); //문자열을 리턴하므로 인덱스를 리턴함

            Console.WriteLine(str.StartsWith("Hello"));
            Console.WriteLine(str.StartsWith("Wold"));

            Console.WriteLine(str.EndsWith("Hello"));
            Console.WriteLine(str.EndsWith("Game"));

            Console.WriteLine(str.Contains("World"));
            Console.WriteLine(str.Contains("G"));

            Console.WriteLine(str.Replace("World", "test"));

            Console.WriteLine(str.Replace("G", "C"));

            string original = "Hallo, World";
            string subString = original.Substring(7, 5);//7번째부터 5만큼 문자를 뽑아냄(인덱스, 길이)
            Console.WriteLine(subString);

            string withSpaces = "  Hello,  World  ";
            string trimmed = withSpaces.Trim();
            Console.WriteLine(trimmed); // 맨 앞과 끝의 공백이 사라짐
            //만약 모든 공백을 없애고 싶으면 다음과 같이 Replace를 쓰면 됨
            //Console.WriteLine(str.Replace(" ", "")); -> 빈공간을 채운다는 뜻

            string withSpaces1 = "  중간 공 백 까지 없애줌 ";
            string withoutSpaces = withSpaces1.Replace(" ", ""); //빈문자열로 채워버리기
            Console.WriteLine(withoutSpaces);

            string splitStr = "공백으로 문장을 잘게 잘게 조져보기";
            string[] words = splitStr.Split(' ');

            foreach(var word in words)
            {
                Console.WriteLine(words);
            }


        }
    }
}
