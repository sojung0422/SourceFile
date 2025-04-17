/******************************************
 [generic 제약]
 -일반화 자료형을 선언할때 제약조건을 선언하여, 
  사용당시 쓸수 있는 자료형을 제한
 - 제네릭 타입 제한은 where T : 조건형식 으로 사용. 여러개를 조합할수 있음
 - 불필요한 타입이 들어가는것을 방지.원하는 기능을 보장하는데 유용

 ******************************************/
/******************************************
 class structT<T> where T : struct {}                  T는 구조체만 사용가능
class classT<T> where T : class {}                     T는  클래스만 사용가능
class newT<T> where T : new() {}                       T는  매개변수 없는 생성자가 있는 자료형만 가능


class ParentT<T> where T : Parent {}                  T는  특정 클래스와 하위클래스만 사용가능
 class InterfaceT<T> where T : IComparable { }        T는 인터페이스를 포함한 자료형만 사용가능




 ******************************************/

namespace _20250410_1
{
    //1. 클래스 타입(참조타입)만 허용
    //where T: class  -> 클래스 타입만 허용하고(참조), 구조체 같은 값타입은 사용불가
    class ReferenceOnly<T>where T: class
    {
        public  T data { get; set; }
        public ReferenceOnly(T data)
        {
            this.data = data;
        }
    }
    //2. 값타입만 허용(구조체)
    class ValueOnly<T> where T: struct
    {
        public T data { get; set; }
        public ValueOnly(T data)
        {
            this.data = data;
        }
    }

    class Character { public string name { get; set; } }
    class Warrior : Character { }
    class Mage { }

    //3.where T: Character(특정클래스) -> 특정 클래스 또는 그 하위클래스만 허용
    class CharacterManager<T> where T: Character{}


    //4.
    class InterfaceT<T> where T : IComparable { }


    //여러개의 제한 조건
    class GameObject() { }
    interface IDamagble { void TakeDamage(); }


    class Enemy : GameObject, IDamagble
    {
        public void TakeDamage()
        {
            
        }
    }

    //GameObject를 상속하고, IDamagble를 구현한 타입만 허용
    class DamageHandler<T> where T : GameObject, IDamagble
    {
        public void Damage(T obj)
        {
            obj.TakeDamage();
        }
    }


    internal class _02
    {
        static void Main()
        {
            ReferenceOnly<string> refIns = new ReferenceOnly<string>("Hello");
            
            //int는 값타입->구조체
            //ReferenceOnly<int> intIns = new ReferenceOnly<int>(100);


            ValueOnly<int> intIns = new ValueOnly<int>(100);

            CharacterManager<Character> c1 =  new CharacterManager<Character>();
            CharacterManager<Warrior> c2 =  new CharacterManager<Warrior>();


            //Mage는 Character의 자식이 아님
           // CharacterManager<Mage> c3 =  new CharacterManager<Mage>();


            InterfaceT<int> interT = new InterfaceT<int>();//int IComparable 인터페이스를 포함하므로 사용 가능

            DamageHandler<Enemy> enemyHandler  =  new DamageHandler<Enemy>();
            enemyHandler.Damage(new Enemy());

        }
    }
}
