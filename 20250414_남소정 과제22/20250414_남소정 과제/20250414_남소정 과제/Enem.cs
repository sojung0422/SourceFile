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

namespace EEnum;// class 안에 아래 것들이 있으면 절대 다른 네임스페이스에서 못 가져옴

public enum EItem//아이템
{
    speedUp,//속도증가
    lifePotion,//생명물약
    shield,//방어
    reflection//반사 -> 레벨 2부터 사용 가능
}
public enum EWeaponItem//무기
{
    axe,//도끼
    sword,//검
    thing//물건(던지는 형식 - 구현 빡셀 듯,,)
}
public enum EJob
{
    woodcotter,//나무꾼
    swordsman,//검사
    merchant//상인
}
public enum EMonsterType
{
    beam,//광성
    bullet,//총알
    mouthmonster//잡아먹는 괴물
}
public enum ESkill//자동으로 숫자가 붙으므로 job에서는 델리게이트에 따로 숫자 넣지 않고 써도 됨
{
    sshield,//방패
    sspeedup,//스피트 증가
    srandomitem//랜덤 아이템
}

//jop과 skill은 부모 관계이지만, 무기는 직업 상관 없이 추가로 획득할 수 있음
// 무기는 서브 재미 요소로 하기로(몇 번의 몬스터 공격을 받으면 사라짐 - 내구도 설정해야 함

