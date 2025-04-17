using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20250401
{
    /***********************************************
     배열
    - 동일한 자료형의 요소들로 구성된 데이터 집합
    - 인덱스를 통하여 배열 요소(Element)에 접근할 수 있음
    - 배열의 처음 요소의 인덱스는 0부터 시작
    - 배열의 크기는 한 번 실행하면 변경할 수 없지만, 리스트(List<T>)와 같은 컬렉션을 사용하면 동적으로 크기조절 가능함
     
     
     
     ***********************************************/

    internal class Array01
    {
        static void Main()
        {
            //[배열의 기본]
            //배열을 만들기 위해 자료형과 크기를 정하여 생성
            //배열의 요소에 접근하기 위해[인덱스]를 사용
            //배열의 Length를 통해 크기를 확인
            //자료형[] 배열의 이름 = new 자료형[크기];

            int[] scores = new int[5];
            scores[0];
            scores[1];
            scores[2];
            scores[3];
            scores[4];
            scores[5];

            Console.WriteLine($"배열의 0번째 요소 : {scores[0]}"); // 4버ㅗㄴ째



            Console.WriteLine(scores.Length); //Length는 크기가 길이 출력

            int[] array1;
            array1 = new int[3];

            int[] array2 = new int[3] { 1, 2, 3 }; //크기가 3인 배열을 선언하고 초기화
            int[] attay3 = new int[] { 1. 2. 3 }; //배열의 요소들을 초기화하는 경우 배열의 크기를 생략 가능
            int[] array4 = { 1, 2, 3 };//배열의 요소들을 초기화하는 경우 배열 생성을 생략 가능

            for(int i =0; i < scores.Length; i++)
            {
                scores[i] += 2;
                Console.WriteLine(scores[i]);
            }
            Console.WriteLine();
            Console.WriteLine();

            foreach (int item in scores) //scores 배열 안에 있는 아이템을 아래서 출력
            {
                //scores[item] += 2 -> ???????반복 가능한 집합을 처음부터 끝까지 돌릴 때 많이 씀(내부 수정이 필요없는 경우) -> 상황에 따라 이게 더 편할 수 있음
                Console.WriteLine(item);
            }

            int[] intArr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            //int num = 0;
            //foreach (Version item in intArr) ;
            //{
            //    sum += item;
            //}
            //nt average = sum / intARR ??

            int[,] matrix = new int[3, 4];
            matrix[2, 1] = 10;

            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1)); // 행과 열의 길이를 리텅

            //배열의 형식과 길이를 명시
            //3개의  원소를 가진 배열이 2개
            int[,] arr = new int[2, 3] { { 1, 2, 3, }, { 4, 5, 6, } }; //중괄호가 2개, 3이 각 중괄호에 3개씩

            //배열의 길이를 생략
            int[,] arr1 = new int[,] { { 1, 2, 3, }, { 4, 5, 6, } };

            //형식과 길이를 모두 생략
            int[,] arr2 = { { 1, 2, 3 }, { 4, 5, 6 } };

            for(int i = 0; i < arr.GetLength(0); i++)
            {
                for (int k = 0; k < arr.GetLength(1); k++)
                {
                    Console.Write($"[{i},{k}] : {arr[i, k]}");
                }
                Console.WriteLine();

            }
            /***********************************************************
             [jaggedArray](가변배열)
            - 배열의 []괄호를 배열갯수만큼 추가
            - 배열의 크기를 각각 설정가능
             
             **********************************************************/

            int[][] jagged = new int[3][];
            jagged[0] = new int[5];
            jagged[1] = new int[2];
            jagged[2] = new int[3];

            //[0][0] [0][1] [0][2] [0][3] [0][4]    -> new int[5]
            //[1][0] [1][1]                         -> new int[2];
            //[2][0] [2][1] [2][2]                  -> new int[3];

            jagged[0] = [1, 2, 3, 4, 5];
            jagged[1] = [6, 7];
            jagged[2] = [8, 9, 100];


            /////////////////////////////////
            int[] array10 = { 5, 3, 1, 2, 7};
            int Length = array10.Length; //배열의 크기
            int max = array10.Max();
            Console.WriteLine(max); //max는 배열의 최대값을 구해주는 녀석임

            Array.Sort(array10);   //Sort는 배열 정렬
            Array.Reverse(array10); //반전시켜주는 녀석

            int index = Array.IndexOf(array10, 3);  //탐색
            Console.WriteLine(index);

            int[] shallow = array10;
            int[] deep = new int[array10, Length]; //??

            Array.Copy(array10, deep, array10.Length);


        }
    }
}
