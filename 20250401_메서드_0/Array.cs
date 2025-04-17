
namespace _20250401
{
    /************************************************
     배열
     - 동일한 자료형의 요소들로 구성된 데이터 집한
     - 인덱스를 통하여 배열요소(Element)에 접근 할수 있음
     - 배열의 처음 요소의 인덱스는 0부터 시작
     - 배열의 크기는 한번설정하면 변경할 수 없지만 리스트(List<T>)같은 컬렉션을
       사용하면 동적으로 크기조절 가능함.
     
     ************************************************/
    internal class Array01
    {
        static void Main()
        {
            //[배열기본]
            //배열을 만들기 위해 자료형과 크기를 정하여 생성
            //배열의 요소에 접근하기 위해[인덱스]를 사용
            //배열의 Length를 통해 크기를 확인
            //자료형[] 배열이름 = new 자료형[크기];

            int[] scores = new int[5];
            scores[0] = 1;
            scores[1] = 2;
            scores[2] = 3;
            scores[3] = 4;
            scores[4] = 5;

            Console.WriteLine($"배열의 0번째 요소 : {scores[0]}");
            Console.WriteLine($"배열의 1번째 요소 : {scores[1]}");
            Console.WriteLine($"배열의 2번째 요소 : {scores[2]}");
            Console.WriteLine($"배열의 3번째 요소 : {scores[3]}");
            Console.WriteLine($"배열의 4번째 요소 : {scores[4]}");

            Console.WriteLine(scores.Length);

            int[] array1;
            array1  = new int[3];

            int[] array2 = new int[3] { 1, 2, 3 };//크기가 3인 배열을 선언하고 초기화
            int[] array3 = new int[] { 1, 2, 3 };//배열의 요소들을 초기화 하는 경우 배열의 크기를 생략가능
            int[] array4 = { 1, 2, 3 };//배열의 요소들을 초기화 하는 경우 배열 생성을 생략가능

            for(int i = 0;i<scores.Length;i++)
            {
                scores[i] += 2;
                Console.WriteLine(scores[i]);   
            }
            Console.WriteLine();
            Console.WriteLine();

            foreach (int item in scores)
            {
               // scores[item] += 2;
                Console.WriteLine(item);
            }

            Console.WriteLine();
            Console.WriteLine();
            int[] intArr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            int[,] matrix = new int[3, 4];
            matrix[2, 1] = 10;

            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));


            //배열의 형식과 길이를 명시
            //3개의 원소를 가진 배열이 2개
            int[,] arr = new int[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } };

            //배열의 길이를 생략
            int[,] arr1 = new int[,] { { 1, 2, 3 }, { 4, 5, 6 } };

            //형식과 길이를 모두 생략
            int[,] arr2 = { { 1, 2, 3 }, { 4, 5, 6 } };

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int  k = 0; k < arr.GetLength(1); k++)
                {
                    Console.Write($"[{i},{k}] : {arr[i, k]}");
                }
                Console.WriteLine() ;   
            }

            /****************************************************************
             [jaggedArray](가변배열)
             - 배열의 []괄호를 배열갯수만큼 추가
             - 배열의 크기를 각각 설정가능
             
             ****************************************************************/

            int[][] jagged = new int[3][];
            jagged[0] = new int[5];
            jagged[1] = new int[2];
            jagged[2] = new int[3];
            //[0][0] [0][1] [0][2] [0][3] [0][4]        --->new int[5];
            //[1][0] [1][1]                             -->new int[2];
            //[2][0] [2][1] [2][2]                      --->new int[3];

            jagged[0] = [1, 2, 3, 4, 5];
            jagged[1] = [6,7];
            jagged[2] = [8,9,10];

            ///////////////////////////////////////
            int[] array10 = { 5, 3, 1, 2, 7 };
            int length = array10.Length;    //배열의 크기
            int max = array10.Max();
            Console.WriteLine(max) ;

            Array.Sort(array10);    //배열정렬
            Array.Reverse(array10);     //반전

            int index = Array.IndexOf(array10, 3);//탐색

            int[] shallow = array10;                
            int[] deep = new int[array10.Length];

            Array.Copy(array10, deep, array10.Length);
        }
    }
}
