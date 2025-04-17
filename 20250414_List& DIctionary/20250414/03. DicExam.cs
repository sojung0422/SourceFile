

namespace _20250414
{
    class Inventory
    {
        private Dictionary<string, int> inventory =  new Dictionary<string, int>();


        public void AddItem(string itemName, int count)
        {
            if(inventory.ContainsKey(itemName))
            {
                inventory[itemName] += count;
            }
            else
            {
                inventory[itemName] = count;
            }
            Console.WriteLine($"[인벤토리]{itemName}을{count}개 추가함!.{inventory[itemName]}개");
        }
        public void UseItem(string itemName)
        {
            if(inventory.TryGetValue(itemName,out int count)&&count>0)
            {
                inventory[itemName]--;
                Console.WriteLine($"[사용]{itemName}사용! 남은 갯수 : {inventory[itemName]}");

                if (inventory[itemName]==0)
                {
                    inventory.Remove(itemName);
                    Console.WriteLine($"[삭제]{itemName}가 인벤토리에서 제거됨");
                }
            }
            else
            {
                Console.WriteLine($"[실패]{itemName}이 없다");
            }
        }
        public void ShowInventory()
        {
            Console.WriteLine("=============현재 인벤토리=============");
            foreach (var item in inventory)
            {
                Console.WriteLine($"{item.Key} : {item.Value}개");
            }
        }
    }
    internal class _03
    {
        static void Main()
        {
            Inventory inventory = new Inventory();
            inventory.AddItem("Potion", 3);
            inventory.AddItem("Gold", 100);
            inventory.UseItem("Potion");
            inventory.UseItem("Potion");
            inventory.UseItem("Potion");

            inventory.ShowInventory();
        }
    }
}
