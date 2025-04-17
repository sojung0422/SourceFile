/*
 [과제]
1. 델리게이트 체인, 이벤트를 각각 활용하여 스킬 이펙트를 구현하시오.

2. point 클래스를 만든다
연산자 오버로딩을 만드시오
ㄴ==, !=

오늘 한 것 중에 반드시 알아야 하는 내용
1. Func VS Action
2. 델리게이트란?
3. 델리게이트와 이벤트의 차이점
**2,3은 면접 질문으로 많이 출제
 

1. 클릭했을 때 스킬 발동
2. 스킬은 exp가 일정량 이상일 경우 사용 가능(스피드가 빠르면 더 ㅁ낳이 먹을 수 있음 but, 난이도가 올라갈 수 있음)
 */
using System.Security.Cryptography.X509Certificates;
using EEnum;


namespace SSkill
{
    internal class Skill
    {
        Dictionary<ESkill, string> skillNames = new Dictionary<ESkill, string>//딕셔너리로 스킬의 명칭 정함(데이터 타입 외부에 쉽게 확장 가능
        {
            {ESkill.sshield, "쉴드 착용 + 1회"},
            {ESkill.sspeedup, "5초 간 스피드 증가 +1회" },
            {ESkill.srandomitem, "랜덤 아이템 획득 +1회" }
        };
        public void UseSkill(ESkill skill)
        {
            Action skillAction = null;//액션 델리게이트 선언 -> 함수 자체를 저장

            Console.WriteLine($"[스킬 사용]\n {skillNames[skill]}");

            switch (skill)//스위치로 값 당 행동을 나눔 - 나는 직업 3개에 스킬 정해져 있으므로..
            {
                case ESkill.sshield:
                    skillAction = () =>
                    {
                        Console.WriteLine("1회 데미지 무효화");// 여기 코드 들어가야 함 -> 장애물 무효화
                    };
                    break;
                case ESkill.sspeedup:
                    skillAction = () =>
                    {
                        Console.WriteLine("스피드 20 증가");//player speed + 30
                    };
                    break;
                case ESkill.srandomitem:
                    skillAction = () =>
                    {
                        Console.WriteLine("아이템 랜덤 획득");//랜덤 아이템 만드는 거 가지고 오기
                    };
                    break;
            }
            skillAction?.Invoke();//실행
        }
    }
}


/*
 [ Dictionary와 switch 사용 ]
- 직관적이고 정해진 스킬과 직업일 시에는 switch문이 좋음
-하지만 아래 상황의 경우 Dictionary이 좋음
ㄴ직업이 10개 이상으로 많아졌을 때
ㄴ직업마다 여러 스킬을 갖게 되었을 때 (예: Warrior는 스킬 3개, Mage는 5개)
ㄴ스킬의 내용이 다른 클래스/외부에서 따로 관리될 때
ㄴ테스트 코드에서 행동을 바꿔 끼우고 싶을 때

지금 내가 만드는 건 직업 3개에 각 직업 당 슼리 1개씩으로 정해져 있기 때문에 switch가 나을 것 같음
* 장비 교체는 Dictionary가 적합

1. 딕서너리(Dictionary) - 값이나 데이터 저장
2. 스위치(switch) - 행동 별 싱행 나누기(직관적이지만 조건 많아질 수롣 유지보수 어려움)
3. 델리게이트(Delegate) - 함수 자체를 저장하고 실행 가능 (스위치 문 안에서 작동할 수 있게??)

[ 어떤 상황에 델리게이트와 이벤트를 사용하는게 좋을까? ]
스킬 선택 → 실행만 할 때 => 델리게이트 사용(= 사용 시 이전 체인 다 날아감 + 외부 변경 필요 시)
스킬 사용 시 ui 및 애니메이션 동시 발생 => 이벤트 사용(스킬 발동은 내부에서만 발생하고, 외부는 반응만 해야 함)
*/





