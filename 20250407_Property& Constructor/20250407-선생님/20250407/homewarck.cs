/******************************************************
 [실습]

1. 프로퍼티를 이용하여 학생의 정보를 출력하는 클래스를 만들 것
ㄴ 이름, 나이, 성별, 취미, 성적, 반, 학년 등

2. 캐릭터 클래스를 생성하고 생성자를 이용해 각기 다른 캐릭터를 생성해볼 것,
ㄴ기본 생성자, 매개변수가 있는 생성자(오버로딩)
ㄴ오버로딩 : 이름, 레벨...
            이름, 레벨, 공격력...
            이름, 레벨, 공격력, 방어력...
 
 *****************************************************/

namespace _20250407
{
    public class Student//캐릭터라는 클래스 생성(캐릭터와 속성이 비슷한 것들은 아래서 여러개의 객체를 만들어서 활용할 수 있음
    {
        public string school { get; set;}//학급
        public int grade { get; set; }//학년
        public string name { get; set; }//이름
        public string gender { get; set; }//성별
        public int age { get; set; }//나이
        public string hobby { get; set; }//취미
        public int rating { get; set; }//체력

        public Student(string school, int grade, string name, string gender, int age, string hobby, int rating)
        {
            this.school = school;
            this.grade = grade;
            this.name = name;
            this.gender = gender;
            this.age = age;
            this.hobby = hobby;
            this.rating = rating;
        }

    }
    internal class Output
    {
        static void Main()
        {
            Student student1 = new Student("김화영초등학교", 3, "김마리", "여", 12, "뜨개질", 24);

            Console.WriteLine(student1);
        }
         

    }
}
