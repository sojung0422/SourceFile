/**************************************************
 [확장 메서드]
 - 확장 메서드는 기존 클래스에 새로운 메서드를 추가할수 있는 기능
 - 정적메서드에 첫번째 매개변수를 this 키워드 후 확장하고자 하는 자료형을 작성 
 
 

public static class ExtensionClass
{
    public static returnType MethodName(this type, parameters)
    {
        //메서드 구현
    }
}

[연산자 재정의]
- 기존의 연산자를 사용자 정의 클래스나 구조체에서 직접정의하여 사용할수 있도록 하는 기능
- 사용자 정의 자료형이나 클래스의 연산자를 재정의하여 여러의미로 사용
- 연산자 오버로딩을 하려면 operator 키워드를 사용하며, 반드시 static메서드로 정의

-연산자의 의미를 유지해야함.
- 짝을 이루는 연산자는 함께 오버로딩하는게 좋음(==를 오버로딩한다면  !=도 함께 구현)

-게임 개발, 벡터연산, 수학관련 클래스에서 자주활용
 **************************************************/

namespace _20250415
{
    public static class StringExtensions
    {
        //확장메서드 정의
        //this : 확장하려는 타입을 명시하는 역할
        //예를 들어 string클래스에 대한 확장메서드를 정의할때 this는 그 메서드가
        //string 인스턴스에서 호출될수 있도록 함.
        public static string ReverseString(this string str)
        {
            char[] array = str.ToCharArray();
            Array.Reverse(array);
            return new string(array);
        }
        public static int WordCount(this string str)
        {
            return str.Split(' ').Length;
        }
    }

    //연산자 오버로딩
    class Vector
    {
        public int x { get; }
        public int y { get; }

        public Vector(int x, int y) 
        {
            this.x = x;
            this.y = y;
        }
        //연산자 오버로딩(벡터 덧셈)
        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a.x + b.x, a.y + b.y);
        }
        public override string ToString()
        {
            return $"({x},{y})";
        }

    }
    internal class _04
    {
        static void Main()
        {
            //확장 메서드
            string original = "Hello, World";
            string reverse = original.ReverseString();
            Console.WriteLine(reverse);

            string str = "Hello world";
            Console.WriteLine(StringExtensions.WordCount(str));
            Console.WriteLine(str.WordCount());

            //오버로딩

            Vector v1 = new Vector(2, 3);
            Vector v2 = new Vector(4, 5);

            Vector res = v1 + v2;

            Console.WriteLine(res);
        }
    }
}
