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

using JJob;

namespace PPlayer
{
    internal class Player
    {
        public string Name { get; set; }
        public int Hp { get; private set; }// 전투 시 변화하는 값(현재 체력)***
        public JobData Job { get; set; }
        public int MaxHp { get; private set; }//최대 hp - 직업에 따라 고정
        public int Atk { get; private set; }

        public Player(string name, JobData jobData)//JobData에서 정보 가지고 옴
        {
            Name = name;//this는 이름 겹치는 경우 사용 -> 이름은 GameManager에서 작성한 이름으로 실행
            Job = jobData;

            MaxHp = jobData.hp;//직업의 hp를 캐릭터의 최대 hp로 함
            Atk = jobData.atk;

            Hp = MaxHp;//처음 시작 시 최대 hp 값 가져옴
        }
        public void Heal(int heal)
        {
            if(Hp > 0)
            {
                Hp += heal;
                Console.WriteLine($"체력이 {heal} 회복되었습니다. 현재 Hp : {Hp}");
            }
            
        }
    }
   
}













/*
 JobData warriorJob = new JobData(EJob.swordsman);
Player player = new Player("소정", warriorJob);

Console.WriteLine($"이름: {player.Name}");
Console.WriteLine($"직업 공격력: {player.Atk}");
Console.WriteLine($"현재 체력: {player.Hp}/{player.MaxHp}");

public ESkill Skill => Job.skill; // JobData에 있는 skill에 접근

 
 
 */