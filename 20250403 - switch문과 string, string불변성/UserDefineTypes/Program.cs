using System.Runtime.InteropServices;

namespace UserDefineTypes
{
    /********************************************************
     [사용자 정의 자료형]
    - int, string 등은 기본적으로 제공되는 자료형임
    - 사용자 정의 자료형은 기본적으로 제공되는 자료형 외에 사용자가 직접 정의하여 사용할 수 있는 자료현
    - 열거형, 구조체, 클래스, 인터페이스, 델리게이트 등이 있음.

    1. 열거형(Enum)
    - 기본 정수 숫자의 형식의 명명된 상수 집합에 의해 정의되는 형식(상수라는 뜻)
    - 열거형 멤버의 이름으로 고나리되어 코드의 가독성적인 측면에 도움이 됨.
     
    
     
     ********************************************************/
    //[기본 사용법]
    //enum 열거형이름 { 멤버 이름, 멤버이름.....}

    enum Direction //{Up, Down, Lefr, Right } -> 이런 식으로 써도 됨
    {
        Up, Down, Left, Right //열거형 정의 : 열거형 이름과 멤버이름 작성
    }

    enum Season
    {
        Spring,
        Summer,
        Autumn = 20, //값을 넣으면 그 다음 열거는 값을 넣은 수에서 +1씩 증가함
        Winter //커서 가져다 대면 21이라고 나오는데, 이는 열거 값이라고 생각하면 됨
    }
    enum WeaponType
    {
        Sword,
        Bow,
        Staff
    }


    internal class Program
    {

        public int GetWeaponDamage(WeaponType weapon)
        {
            switch (weapon)
            {
                case WeaponType.Sword:
                    return 50;
                case WeaponType.Bow:
                    return 35;
                case WeaponType.Staff:
                    return 25;
                default:  // 예상하지 못한 버그가 생길 수 있으니 디폴트까지 다 써라 -> c#은 안전성을 중시
                    return 0;
                    // 안전성을 중시여기기 때문에 함수(메서드) 내부에서는 다 써야 함 - main 말고 return은 아무것도 아니면 0 내뱉고 끝내라는 뜻임
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Direction dir = Direction.Up;    //열거형 변수

            switch (dir)
            {
                case Direction.Up:
                    Console.WriteLine("위쪽 방향으로 이동한다.");
                    break;
                case Direction.Down:
                    Console.WriteLine("아래쪽 방향으로 이동한다.");
                    break;
                case Direction.Left:
                    Console.WriteLine("왼쪽 방향으로 이동한다.");
                    break;
                case Direction.Right:
                    Console.WriteLine("오른쪽 방향으로 이동한다.");
                    break;


            }

            Program program = new Program();
            WeaponType weapon = WeaponType.Sword;

            int damage = program.GetWeaponDamage(weapon);

            Console.WriteLine($"사용한 무기 : {weapon}, 공격력 : {damage}");







        }
    }
}
