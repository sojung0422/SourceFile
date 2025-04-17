//c#에서는 property라는 문법을 지원
//값을 뭔가를 세팅한다 -> set이라는 키워드 씀
/**********************************************************
 [property]
- 필드를 캡슐화하여 안전하게 접근하도록 도와주는 기능
- Getter(읽기)와 Setter(쓰기)를 통해 내부 데이터를 보호하면서, 필요할 때만 값을 읽거낭 변경
- 외부에서는 필드에 직접 접근하지 못하고, 프로퍼티를 통해 조작이 가능





***********************************************************/

using System.Globalization;

namespace _20250407
{
    class Circle
    {
        private double pi = 3.14; //옛날 방식 -> 필드 접근은 불가

        //구 방식
        public double GetArea() //은행원을 통해 값을 가지고 오거나 변경
        {
            return pi;
        }//옛날 방식
        public void SetPi(double radius) //은행원을 통해 값을 가지고 오거나 변경
        {
            pi = radius;
        }

    }
    //기본적인 프로퍼티
    class Character
    {
        //private이기 때문에 직접 접근 불가
        private string name;
        public string Name //프로퍼티
        {
            get { return name; } //값 읽기(Getter)
            set { name = value; } //값 설정(setter) value는 할당된 값을 의미(사용자가 프로퍼티에 값을 설정할 때 전달되는 값)
        }
    }
    //[읽기전용 프로퍼티]
    //get만 제공하고 ste만 없으면 읽기만 가능한 프로퍼티
    //객체의 데이터를 외부에서 변경하지 못하도록 보호가능
    class Character1
    {
        private int level1 = 1;
        public int Level
        {
            get { return level1; }  //읽기만 가능
        }
    }
    //[쓰기전용]
    //set만 제공하고 get을 없애면 쓰기만 가능한 프로퍼티
    class Character2
    {
        private string secret;
        public String Secret
        {
            set { secret = value; }   //쓰기만 가능
        }  
    }
    //[자동구현 프로퍼티]
    //필드를 직접 선언하지 않고도 자동으로 필드를 생성하는 프로퍼티 제공
    //간단한 속성을 정의할 때 유용
    class Caracter3
    {
        public string name { get; set; }//자동구현 프로퍼티 - 위 매릭터처럼 필드를 자도 생성 
    }
    //[프로퍼티에 로직추가할 수도 있음]
    //set에서 유효성 검사를 통해 잘못된 값이 입력되지 않도록 보호를 할 수 있음
    class Character4
    {
        private int level;
        public int Level
        {
            get { return level; }
            set
            {
               
            }
        }
    }

    //[private set]
    //외부에서는 읽기만 가능(get)만 가능. 값 설정(set)은 내부에서만 가능하게 설정 가능
    //한 번 설정된 값이 외부에서 변경되지 않도록 보호할 때 사용함.
    //메서드나 생성자에서 값 변경 가능
    class Character5
    {
        public string name { get; private set; }//읽기는 가능하지만 쓰기는 불가능
        public Character5(string name)
        {
            this.name = name;//this는 내 자신 위에 있는 name이고 매개변수로 들어오는 이름으로 초기화를 하겠다는 뜻임

        }
    }
    //[private 프로퍼티]
    //클래스 내부에서만 접근 가능 -> 외부에서 읽거나 변경 불가
    //객체의 내부 상태를 보호하고, 특정 메서드를 통해서만 값을 변경할 때 사용

    class Game
    {
        private int score { get; set; }
        public void Increase
    }


    internal class _01Property
    {
        static void Main()
        {
            Character player = new Character();
            player.Name = "홍길동";               //set
            Console.WriteLine(player.Name);      //get

            Character1 player1 = new Character1();

            Console.WriteLine(player);


            Caracter3 player3 = new Caracter3();
            player3.name = "홍길서";
            Console.WriteLine(player3.name);



        }
    }
}
