
/********************************************************
 [List]
 - 제네릭 동적배열 클래스
 - 배열과 유사하지만 크기가 자동으로 조정되는 특징이 있음
 - 내부적으로 배열을 사요하지만 크기가 부족하면 새로운 배열을 생성하고 기존 요소를 복사
 - 배열처럼 인덱스를 통해 접근 가능(빠름)
 - 중간 / 삽입 삭제는 느릴수 있다.

Add , Remove, IndexOf, Clear, FInd, Sort, Contains, ToArray...
 ********************************************************/



namespace _20250414
{
   class Item
    {
        public string name { get; set; }
        public int atk { get; set; }

        public Item(string name, int atk)
        {
            this.name = name;
            this.atk = atk;
        }

        public override string ToString()
        {
            return $"{name} atk : {atk}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            #region List
            List<string> items = new List<string>();

            items.Add("Potion");
            items.Add("Sword");
            items.Add("Shield");

            //특정위치에 삽입
            items.Insert(1, "Bow");

            foreach (var item in items)
            {
                Console.WriteLine(item);
            }

            //삭제
            items.Remove("Potion");

            //검색(있냐 없냐)
            if (items.Contains("Sword"))
            {
                Console.WriteLine("Sword가 있다");
            }
            //정렬
            items.Sort();

            foreach (var item in items)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine($"items의 (갯수){items.Count}");
            Console.WriteLine($"items의 (용량){items.Capacity}");
            items.Add("sword1");
            Console.WriteLine($"items의 (용량){items.Capacity}");
            items.Add("sword1");
            Console.WriteLine($"items의 (용량){items.Capacity}");
            #endregion

            List<Item> inven = new List<Item>
            {
                new Item("칼",10),
                new Item("도끼",5),
                new Item("포션",0),
                new Item("방패",2)
            };

            foreach (var item in inven)
            {
                Console.WriteLine($"{item.name},공격력 : {item.atk}");
            }

            //아이템 찾아보기
            Item foundItem = null;
            foreach (var item in inven)
            {
                if(item.name=="포션")
                {
                    foundItem = item;
                    break;
                }
            }
            if (foundItem != null)
            {
                Console.WriteLine($"찾은 아이템 {foundItem}");
            }
            else
            {
                Console.WriteLine("없다!!!");
            }

            //특정 아이템 제거
            Item itemRemove = null;

            foreach(var item in inven)
            {
                if(item.name=="칼")
                {
                    itemRemove = item;
                    break;
                }
            }
            if(itemRemove!=null)
            {
                inven.Remove(itemRemove);
                Console.WriteLine("칼 제거후 아이템 목록");
            }
            foreach (var item in inven)
            {
                Console.WriteLine($"{item.name},공격력 : {item.atk}");
            }


        }
    }
}
