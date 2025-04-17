/******************************************
 [generic]
 -데이터 형식에 의존하지 않고 재사용 가능한 코드 작성을 
  가능하게 하는 기능

 ******************************************/
namespace _20250410_1
{
    //1. 제네릭 메서드
    class Utils
    {
        public static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
        public static void ArrayCopy<T>(T[] source, T[] output)
        {
            for (int i = 0; i < source.Length; i++)
            {
                output[i] = source[i];  
            }
        }
    }
    //2.제네릭 클래스
    class Box<T>
    {
        private T item;
        public void SetItem(T item)
        {
            this.item = item;
        }
        public T GetItem() 
        {
            return item;
        }
    }
    internal class _01
    {
        static void Main()
        {
            int x = 10, y = 20;
            Utils.Swap(ref x, ref y);
            Console.WriteLine($"{x},{y}");
            string str1 = "Hello";
            string str2 = "World";

            Utils.Swap(ref str1, ref str2);
            Console.WriteLine($"{str1},{str2}");

            int[] isrc = { 1, 2, 3, 4, 5 };
            float[] fSrc = { 1f, 2f, 3f, 4f, 5f };
            double[] dSrc = { 1d, 2d, 3d, 4d, 5d };


            int[] iDst = new int[isrc.Length];
            float[] fDst = new float[fSrc.Length];
            double[] dDst = new double[dSrc.Length];

            Utils.ArrayCopy<int>(isrc, iDst);
            Utils.ArrayCopy<float>(fSrc, fSrc);
            Utils.ArrayCopy(dSrc, dDst);    //매개변수를 통해 추측가능한 경우 생략이 가능

            Box<int> intBox = new Box<int>();
            intBox.SetItem(100);

            Box<string> stringBox = new Box<string>();


        }
    }
}
