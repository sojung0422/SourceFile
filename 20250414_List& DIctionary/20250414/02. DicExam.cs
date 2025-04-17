

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
        public void ShowInfo()
        {
            Console.WriteLine($"{name} - 공격력 {atk}");
        }
    }

    internal class _02
    {
        static void Main()
        {
            Dictionary<int, Item> inven = new Dictionary<int, Item>
            {
                {1,new Item("얼음검",50)},
                {2,new Item("불검",10)},
                {3,new Item("활",30)}
            };


            int itemkey = 1;
            if(inven.TryGetValue(itemkey,out Item item))
            {
                item.ShowInfo();
            }
            else
            {
                Console.WriteLine("아이템이 존재하지 않습니당");
            }
            Console.WriteLine("인벤토리 목록");

            foreach (var pair in inven)
            {
                Console.Write($"{pair.Key} : ");
                pair.Value.ShowInfo();
            }
        }
    }
}
