using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20250409
{
    //1.두개의 인터페이스
    //IAttackable, IHealable

    //2.추상 클래스
    //Character : 캐릭터의 기본정보를 가지고 있음

    //3.Warrior, Mage 클래스-> 추상클래스를 상속받아서 기본기능 제공하고
    //Warrior는 IAttackable를 구현하여 공격기능을 강제시킴
    //Mage는 IHealable를 추가로 구현하여 힐링 기능 제공

    interface IAttackable
    {
        void Attack();
    }
    interface IHealable
    {
        void Heal();
    }
    abstract class Character
    {
        public string name { get; set; }
        public int hp { get; set; }
        public int atk { get; set; }

        public Character(string name, int hp, int atk)
        {
            this.name = name;
            this.hp = hp;
            this.atk = atk;
        }

        public void ShowStatus()
        {
            Console.WriteLine($"이름 : {name}, 체력 :{hp},공격력{atk} ");
        }
        public void TakeDamage(int damage)
        {
            hp -= damage;
            Console.WriteLine($"{name}이 {damage}만큼 피해를 입었음.남은 체력{hp}");
        }
        public abstract void Die();
    }
    class Warrior : Character, IAttackable
    {
        public Warrior(string name, int hp, int atk):base(name, hp, atk) { }

        public void Attack()
        {
            Console.WriteLine($"{name}이 검을 휘두른다! 공격력 : {atk}");
        }
        public override void Die()
        {
            Console.WriteLine("책상을 탁 치니 엌! 하고 죽었다");
        }
       
    }
    class Mage: Character, IAttackable, IHealable
    {
        public Mage(string name, int hp, int atk):base(name, hp, atk) { }
        public void Attack()
        {
            Console.WriteLine($"{name}이 지팡이를 휘두른다! 공격력 : {atk}");
        }
        public void Heal()
        {
            Console.WriteLine("치유 마법!");
        }
        public override void Die()
        {
            Console.WriteLine("길다가 그냥 쓰러졌어요..");
        }
    }
    internal class _03
    {
        static void Main()
        {
            Warrior w = new Warrior("홍길동", 200, 10);
            Mage m = new Mage("홍길서", 500, 5);

            w.ShowStatus();
            m.ShowStatus();

            w.Attack();
            m.Attack();

            m.Heal();

            w.TakeDamage(5);
            m.TakeDamage(1);

            w.Die();
            m.Die();
        }
    }

    //실습
    //아이템 클래스(추상 클래스)
    //ㄴ설명, 이름..기타등등..공통적인 부분들..
    //ㄴUse()->추상메서드로..(아이템마다 사용방법이 다를수 있으니까?)

    //인터페이스
    //장착 가능한 아이템
    //void Equip
    //void UnEquip

    //일반클래스는 2개이상 만들고 위에 인터페이스와 추상을 상속받아서 만들어보자
    //Sword, Bow, Potion...
}
