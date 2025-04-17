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

namespace IItem
{
    internal class Item
    {
        public string name { get; set; }
        public int hp { get; set; }
        public int atk { get; set; }
        public int def { get; set; }
        public int speed {  get; set; }
        
        public Item(string name, int hp, int atk, int def, int speed)
        {
            this.name = name;
            this.hp = hp;
            this.atk = atk;
            this.def = def;
            this.speed = speed;
        }
        public void ShowInfo()
        {
            Console.WriteLine($"{name}의 공격력은 +{atk}, 방어력은 +{def}입니다.");
        }
    }

    internal class ItemData//아이템이 많을 시에는 해당 데이터만 사용하게 하면 유지보수가 쉽지만, 오류 가능성 있음 아이템이 고정되어 있고 없는 경우 enum과 함께 사용하면 안전성 높일 수 있음
    {
        //정해진 아이템만 사용 가능하며, 아이템 이름 바뀌어도 enum 이름만 유지하면 내부 로직 영향 없음
        public static Dictionary<EItem, Item> inven = new Dictionary<EItem, Item>//inven은 Dictionary 자료형이고, int를 키값(ID), Item을 **값(아이템 인스턴스)**로 가지는 구조 -> 여기서 inven은 실제 인벤토리가 아니라,게임에 존재하는 모든 기본 아이템 목록을 모아놓은 데이터셋임
        {
            {EItem.speedUp, new Item ("토끼 물약", 0, 0, 0, 50)},//new Item(...)은 **"해당 이름과 능력치를 가진 새 아이템 객체를 메모리에 생성"**한다는 의미
            {EItem.lifePotion, new Item ("생명의 물약", 50, 0, 0, 0) },
            {EItem.shield, new Item ("방패", 0, 0, 10, 0) },
            {EItem.reflection, new Item ("회고의 거울", 0, 0, 0, 0)}//이거 문제인데, 여기에 함수를 넣을 수 있나?? 아래 스킬처럼 델리게이트 걸어야 할수도? 델리게이트 말고 다른 방법있나??
        };
        //public static으로 바꿔야 위 코드를 인벤에서 사용할 수 이씀
    }


}


/*


speedUp,//속도증가
lifePotion,//생명물약
shield,//방어
reflection//반사 -> 레벨 2부터 사용 가능



 Action usePotion = () => {
    Console.WriteLine("🧪 포션 사용!");
    player.hp += 50;
};
usePotion();  // 출력: 포션 사용!, HP +50

 
 ----------------------------------------------------

위 처럼 아이템 데이터를 item에 정의함
static void Main()
{
    // ItemData 클래스의 inven 딕셔너리를 그대로 가져옴
    Dictionary<int, Item> inven = ItemData.inven;

    int itemkey = 1;
    if (inven.TryGetValue(itemkey, out Item item))
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

 */