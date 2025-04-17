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
using SSkill;
using JJob;
using IInventory;
using PPlayer;
using System.Xml.Linq;

namespace GGameManager// 여기에서 직업 선택이랑 해당 직업을 player에 적용할 수 잇도록
{
    internal class GameManager
    {
        static void Main(string[] args)
        {

            Console.WriteLine("플레이어 이름을 입력해주세요 : ");
            string name = Console.ReadLine();
            Console.WriteLine($"{name}님 안녕하세요!");

            Player player = null;//아래와 같이 반복문 등 지역함수는 정녁함수처럼 사용하기 어렵기 대문에 객체를 밖에서 null로 설정하고 이후에 수정하는 방식으로 진행하면 while문 밖에서도 사용 가능
            JobData jobData = null;
            EJob selectJob = default;//열거형은 null이 아닌 default를 사용함 -> default는 기본값을 의미하며, Ejob은 enum이므로 0에 해당하는 EJob.woodcotter이 기본값임 -> 아직 선택하지 않았지만 기본값만 넣자는 의미
            int jobInput = -1;//jobinput에서 유효한 입력값은 0,1,2임(직업) 때문에 초기화 상태임을 알기 위해 일부러 잘못된 값(-1)을 넣어둠

            while (true)
            {
                Console.WriteLine("당신의 직업을 선택해주세요! \n0 : 나무꾼, 1 : 검사, 2 : 상인");
                jobInput = int.Parse(Console.ReadLine());//위 객체에서 수정 -> int.Parse()는 문자열을 정수로 변환함 -> '1'이라는 텍스트를 숫자 '1'로 변환

                while(jobInput < 0 || jobInput > 2)//아래서 유효성 검사를 하면 너무 복잡해짐.. -> 여기서 값 확인 후 선택한 값에 따라 직
                {
                    Console.WriteLine("0 : 나무꾼, 1 : 검사, 2 : 상인 중 다시 선택해주세요");
                    continue;
                }

                selectJob = (EJob)jobInput;//위 객체에서 수정 -> [형변환] -> EJob는 열거형이고 jobinput은 int형임 -> 형이 맞지 않으니, 비교 자체가 불가 -> 이를 형변환하여 selectJob에 저장
                jobData = new JobData(selectJob);//위 객체에서 수정 -> jobdata를 보면 다른 부분은 다 값이 있지만, job에는 값이 없음 때문에 해당 부분의 값을 사용자가 입력한 값으로 넣어주는 것임
                                                         //위 부분은 주기적으로 다시 보기
                player = new Player(name, jobData);//위 객체에서 수정 -> new JobData(selectJob)와 같이 바로 만들어도 됨 -> jobData는 기존에 있는 직업 중 jobData에서 가지고 옴   예는 클래스를 받는 애고 이는 변수로 전달해야 함 -> 클래스 job에서는 열거타입으로 되어 있기 때문에 이를 가져오기 때문에 

                if (jobData.jobtype == EJob.woodcotter)//같은 타입끼리 비교해야 함 -> 위에서 데이터 긁어왔기 때문에 
                {
                    Console.WriteLine($"당신이 선택한 직업은 {jobData.name} 입니다!");
                    break;
                }
                else if (jobData.jobtype == EJob.swordsman)
                {
                    Console.WriteLine($"당신이 선택한 직업은 {jobData.name} 입니다!");
                    break;
                }
                else if (jobData.jobtype == EJob.merchant)
                {
                    Console.WriteLine($"당신이 선택한 직업은 {jobData.name} 입니다!");
                    break;
                }
            }// 해당 코드 그냥 job으로 옮길까??

            Console.WriteLine("아이템을 선택하시겠습니까??");
            Inventory inventory = new Inventory(player);

            //나중에 상점 만들어서 상점에서 인벤토리로 갈 수 있게 하기(상점 아이템 수량은 지금 하는 것 처럼 정해놓고, 인벤토리 이동 시 상점에서 하나 깎이게.. 할 수 있어..)
            Item speedup = ItemData.inven[EItem.speedUp];//"토끼 물약"이라는 문자열 대신, EItem.speedUp이라는 열거형(enum) 값을 직접 사용
            Item lifepotion = ItemData.inven[EItem.lifePotion];
            Item shield = ItemData.inven[EItem.shield];
            Item reflection = ItemData.inven[EItem.reflection];// 아이템(변수이름)에 아이템데이터 - 인벤에 정의한 나열형아이템. reflection을 저장한다.

            //아이템에 해당 함수값 넣어야 하나? main에서 하기는 좀 귀찮고, 매번 달라짐..
            inventory.AddItem(EItem.lifePotion, 3);
            inventory.UseItem(EItem.lifePotion);

            



        }
    }
}
