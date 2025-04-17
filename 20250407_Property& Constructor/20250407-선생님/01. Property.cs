/**************************************************
 [property]
  - 필드를 캡슐화하여 안전하게 접근하도록 도와주는 기능
  - Getter(읽기) 와 Setter(쓰기)를 통해 내부 데이터를 보호하면서, 필요할때만 값을 읽거나 변경
  - 외부에서는 필드에 직접접근하지 못하고, 프로퍼티를 통해 조작이 가능 
 **************************************************/

namespace _20250407
{

    class Circle
    {
        private double pi = 3.14;
        
        //구 방식
        public double GetArea()
        {
            return pi;
        }
        public void SetPi(double radius)
        {
            pi =  radius;   
        }
    }
    //기본적인 프로퍼티
    class Character
    {
        //private이기 때문에 직접 접근 불가
        private string name;
        public string Name          //프로퍼티  
        {
            get { return name; }    //값 읽기(Getter)
            set { name = value; }  //값 설정(setter) value는 할당된 값을 의미(사용자가 프로퍼티에 값을 설정할때 전달되는 값)
        }
    }
    //[읽기전용 프로퍼티]
    //get만 제공하고 set이 없으면 읽기만 가능한 프로퍼티
    //객체의 데이터를 외부에서 변경하지 못하도록 보호 가능
    class Character1
    {
        private int level = 1;
        public int Level
        {
            get { return level; }  //읽기만 가능 
        }
    }
    //[쓰기전용]
    //set만 제공하고 get을 없애면 쓰기만 가능한 프로퍼티
    class Character2
    {
        private string secret;
        public string Secret
        {
            set { secret = value; }     //쓰기만 가능
        }
    }
    //[자동구현 프로퍼티]
    //필드를 직접선언하지 않고도 자동으로 필드를 생성하는 프로퍼티 제공
    //간단한 속성을 정의할때 유용
    class Character3
    {
        public string name { get; set; }//자동구현 프로퍼티
    }

    //[프로퍼티에 로직추가할수도 있음]
    //set에서 유효성 검사를 통해 잘못된 값이 입력되지 않도록 보호를 할수 있음
    class Character4
    {
        private int level;
        public int Level
        {
            get { return level; }
            set
            {
                if (value < 1)
                {
                    Console.WriteLine("레벨은 1이상 이여야함");
                    level = 1;
                }
                else
                {
                    level = value;  
                }
            }
        }
    }
    //[private set]
    //외부에서는 읽기만 가능(get)만 가능. 값 설정(set)은 내부에서만 가능하게 설정 가능
    //한번 설정된 값이 외부에서 변경되지 않도록 보호할때 사용함.
    //메서드나 생성자에서 값 변경 가능
    class Character5
    {
        public string name { get; private set; } //읽기는 가능, 쓰기는 불가능

        //이녀석은 생성자라는 놈
        public Character5(string name)
        {
            this.name = name;
        }
    }
    //[private 프로퍼티]
    //클래스 내부에서만 접근가능 ->외부에서 읽거나 변경 X
    //객체의 내부 상태를 보호하고, 특정 메서드를 통해서만 값을 변경할때 사용

    class Game
    {
        private int score { get; set; }

        public void IncreaseScore(int point)
        {
            score += point;
            Console.WriteLine($"점수 :{score}");
        }
    }

    internal class Property
    {
        static void Main()
        {
            Character player = new Character();
            player.Name = "홍길동";                //set
            Console.WriteLine(player.Name);        //get


            Character1 player1 = new Character1();  
            //player1.Level = 2;              //읽기 전용이므로 할당 불가
            Console.WriteLine(player1.Level);        //get

            Character2 player2 = new Character2();
            //Console.WriteLine(player2.Secret); //읽기 불가능
            //player2.Secret = "비밀정보";    //쓰기만 가능

            Character3 player3 = new Character3();

            player3.name = "홍길서";
            Console.WriteLine(player3.name);

            Character4 player4 = new Character4();
            player4.Level = -5;
            Console.WriteLine(player4.Level);

            Character5 player5 = new Character5("홍길남");
            //player5.name = "홍길북";
            Console.WriteLine(player5.name);

            Game game = new Game();

            game.IncreaseScore(20);
            //Console.WriteLine(game.score);//외부 접근 불가
            //game.score = 20;              //외부 접근 불가


            //실습
            //1.프로퍼티를 이용하여 학생의 정보를 출력하는 클래스를 만들것.
            //2.캐릭터 클래스를 생성하고
            //생성자를 이용해 각기 다른 캐릭터를 생성해볼것.
            //기본 생성자, 매개변수가 있는 생성자(오버로딩)
            //오버로딩 : 이름, 레벨...
            //          이름, 레벨, 공격력
            //          이름, 레벨, 공격력, 방어력...
        }
    }
}
