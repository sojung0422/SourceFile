/*
 [과제]
1. 아이템 클래스
2. 인벤토리 클래스
3. 플레이어 클래스

기능
ㄴ 인벤토리 내에 있는 아이템 장착하기(플레이어)
ㄴ 플레이어는 해당 아이템 장착 시 기본 스탯이 올라감
ㄴ ex) 검 착용 시 플레이어 공격력이 상승
ㄴ 착용전 : 10          착용 후 20

이건 추가 기능(하라는 건 아니고)
ㄴ ex) 인벤토리에 칼 수량 3개
ㄴ 탈착을 하면 수량이 다시 채워짐

2일 과제임(16일까지)
상점도 만들 수 있음
인벤토리에 있는 건 상점에 팔 수도 있음
플레이어는 아이템을 알 이유는 없음
플레이어는 인벤토리만 알면 됨

 */

using EEnum;
using IItem;
using PPlayer;

namespace IInventory
{
    internal class Inventory
    {
        Dictionary<EItem, int> inventory = new Dictionary<EItem, int>();
        private Player player; // ✅ 플레이어 정보를 저장할 변수 -> 이거 어렵다.. 다시 알압괴

        public Inventory(Player player) // ✅ 생성자에서 전달받음 -> 다시 알아보기
        {
            this.player = player;
        }//이거 아이템에서는 가지고 못 하나??


        public void AddItem(EItem itemName, int count)
        {
            if(ItemData.inven.ContainsKey(itemName)==false)//ContainsKey(...)는 해당 키가 있는지 확인하는 함수(있으면 true) -> 존재하지 않는 아이템 추가를 방지
            {
                Console.WriteLine($"{itemName}이 존재하지 않습니다.");
                return;
            }
            
            if (inventory.ContainsKey(itemName))
            {
                inventory[itemName] += count;
            }
            else
            {
                inventory[itemName] = count;
            }
            Console.WriteLine($"인벤토리에 {itemName}을(를) {count}개 추가함!\n {inventory[itemName]}개");
        }

        public void UseItem(EItem itemName)
        {
            if(inventory.TryGetValue(itemName, out int count)&&count>0)
            {
                inventory[itemName]--;
                Console.WriteLine($"{itemName} 사용!\n 남은 갯수 : {inventory[itemName]}");

                Item item = ItemData.inven[itemName];//이거 아이템에서는 가지고 못 하나??

                if (itemName == EItem.lifePotion)//lifePotion 사용 시 -> 이거 아이템에서는 가지고 못 하나??
                {
                    player.Heal(item.hp);
                }

                if (inventory[itemName]==0)
                {
                    inventory.Remove(itemName);
                    Console.WriteLine($"마지막 남은 {itemName}을 사용하였습니다. \n {itemName}이 인벤토리에서 삭제됩니다.");
                }
            }
            else
            {
                Console.WriteLine($"더 이상 사용 가능한 {itemName}이 없습니다.");
            }
        }

        public void ShowInventory()
        {
            Console.WriteLine("===========================현재 인벤토리==========================");//이거 창으로 띄울 수 있는지 알아보기 아니면 화면 상단에서 볼 수 있는지 알아보기
            foreach (var item in inventory)
            {
                Console.WriteLine($"{item.Key} : {item.Value}개");
            }
        }
    }
}
