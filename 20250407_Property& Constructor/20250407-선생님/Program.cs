
/**********************************************
[접근제한자]
 - 클래스, 필드, 메서드, 프로퍼티 등에 접근할수 있는 범위를 결정
 - 접근 제한자를 적절히 활용하면 캡슐화를 통해 데이터를 보호하고 필요한 부분만 공개


접근 제한자                      내용                                                              범위
private                     클래스 내부에서만 접근가능                                            같은 클래스 내부에서만 사용가능
public                      어디서든지 접근가능                                                  모든 클래스, 모든 파일
protected                   현재 클래스 +  상속받은 클래스에서 접근 가능                          같은 클래스+ 자식클래스
protected internal          같은 프로젝트+상속받은 클래스에서 접근 가능                            같은 프로젝트의 모든 클래스 + 다른 프로젝트라도 상속받은 클래스에서 접근 가능
private protected          같은 클래스 + 같은 프로젝트 내에서 상속받은 클래스에서 접근 가능        같은 프로젝트에서 상속받은 경우에만 접근 가능

 **********************************************/
namespace _20250407
{
    //[public]
    //어디서든 접근할수 있음
    // 라이브러리에서 외부로 공개해야하는 기능을 만들때 사용
    // 생성자나 메서드를 선언할때 주로 사용

    class Student
    {
        public string name = "홍길동";
    }
    //[private]
    //같은 클래스내부에서만 접근 가능
    //외부에서 직접 변경할 필요가 없는 데이터를 보호할때 사용
    //필드에 있는 멤버변수를 선언할때 주로 사용
    class Character
    {
        //외부에서는 접근 불가
        private int level = 1;

        public void SetLevel(int newLevel)
        {
            if (newLevel > 0)
            {
                level = newLevel;    //클래스 내부에서는 접근허용
            }
        }
        public void Show()
        {
            Console.WriteLine($"레벨 : {level}");
        }
    }

    //[protected]
    //현재 클래스와 자식 클래스에서만 접근 가능
    //부모 클래스(Character1)에서 정의하고 자식 클래스에서 사용가능
    class Character1
    {
        protected int health = 100;
    }
    class Warrior : Character1
    {
        public void TakeDamage()
        {
            health -= 10;//자식 클래스에서는 접근 가능
            Console.WriteLine($"남은 체력 : {health}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student();
            //public 이기 때문에 접근 가능
            Console.WriteLine(student.name);

            Character character = new Character();
            //character.level은 private이기 때문에 접근 불가
            //Console.WriteLine(character.level);

            character.SetLevel(2);
            character.Show();

            Warrior warrior = new Warrior();
            warrior.TakeDamage();
          //  warrior.health = 10;


        }
    }
}
