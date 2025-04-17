
namespace _20250407
{
    /*************************************
     [복사생성자]
    - 기존 객체의 값을 복사형 새로운 객체를 생성
    - 새로운 객체를 기존 객체를 동일한 속성으로 초기화할 때 사용

    [복사생성자 주의할 점]
    - 객체를 새로 생성하는 것이므로 복사본을 수정해도 원본에는 영향x
    - string은 참조 타입이지만, 불변성이라는 특징때문에 문제x
    - 만약에 클래스 내부에 참조 타입이 있다면 수정했을 경우 원본에도 영향을 미치게 됨
    - 이런 경우에는 깊은 복사를 직접 구현해야 함.


     *************************************/
    class NPC
    {
        public string name;
        public int aeg;

        public
         //복사 생성자
        public NPC(NPC other)
        {
            name = other.name;
            age = other.age;
        }
        class Player
        {
            public string name;
            public int age;
            public int hp;
            publi
        }
        internal class CopyContructor
        {

        }
    }
}
