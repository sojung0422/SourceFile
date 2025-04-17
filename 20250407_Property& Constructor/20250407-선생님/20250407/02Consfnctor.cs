/**************************************************
 생성자 (Constructor)
- 클래스 또는 구조체의 인스턴스를 생성할 때 자동으로 호출되는 메서드
- 클래스 또는 구조체와 동일한 이름을 가짐
- 반환형 명시하지 않음
- 매개변수를 가질 수도 있고, 생성자도 오버로딩 가능함
- 생성자가 없다면(사용자 정의 생성자가 없다면) 기본 생성자를 생성(default)
 
 
 *************************************************/



namespace _20250407
{
    class Point
    {
        public int x;
        public int y;

        public Point()
        {
            x = 1;
            y = 2;


            Console.WriteLine($"{x}, {y}");
        }
        //??
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;

            Console.WriteLine($"{x}, {y}");
        }

        // private int x;
        //private int y;
        //
        //public Point()//얘가 생성자이며, 얘는 외부에서 호출이 되어야기 때문에 반드시 퍼블릭으로 세팅 되어 있어야 함
        //{
        //    x = 1;
        //    y = 2;

        //    Console.WriteLine($"{x}, {y}");
        //}
    }

    class Player
    {
        private string name;
        private int hp;
        private int mp;

        public string

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
        public Player(string name, int hp, int mp)
        {
            this.name = name;
            this.hp = hp;
            this.mp = mp;
        }
    }
    internal class _02Consfnctor
    {
        static void Main()
        {
            Point p = new Point();
            Point p1 = new Point(3, 4);//서로 다른 매개변수를 가진 생성자를 만들면 각기다른 객체 생성이 가능함
            
            
            Player Player = new Player();
            Player Player = new Player("홀기럿",10);
        }
    }
}
