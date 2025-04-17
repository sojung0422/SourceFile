
/****************************************
생성자 (Constructor)
 - 클래스 또는 구조체의 인스턴스를 생성할때 자동으로 호출되는 메서드
 - 클래스 또는 구조체와 동일한 이름을 가짐
 - 반환형 명시하지 않음
 - 매개변수를 가질수도 있고, 생성자 오버로딩도 가능함.
 - 생성자가 없다면(사용자 정의 생성자가 없다면) 기본생성자를 생성(default)
 ****************************************/
using System.Runtime.InteropServices;

namespace _20250407
{
    class Point
    {
        private int x;
        private int y;
        public Point()
        {
            x = 1;
            y = 2;

            Console.WriteLine($"{x} , {y}");
        }
        //생성자 오버로딩
        //초기화할 값을 외부에서 받는 생성자
        //오버로딩을 통해 다양한 생성자를 정의 할수 있음.
        public Point(int x,int y)
        {
            this.x = x; 
            this.y = y;
            Console.WriteLine($"{x} , {y}");
        }
    }

    class Player
    {
        //private string name;
        //private int hp;
        //private int mp;

        //프로퍼티로 만들면?
        public string name { get; set; }
        public int hp { get; set; }
        public int mp {  get; set; }    
        public Player() 
        {
            name = "홍길동";
            hp = 10;
        }
        public Player(string name, int hp)
        {
            this.name = name;   
            this.hp = hp;   
        }
        public Player(string name, int hp,int mp)
        {
            this.name = name;
            this.hp=hp;
            this.mp = mp;
        }
    }
    internal class _02
    {
        static void Main()
        {
            Point p = new Point();
            Point p1 = new Point(3,4);

            Player player = new Player();
            Player player1 = new Player("홍길서",10);
            Player player2 = new Player("홍길북",10,30);

        }
    }
}
