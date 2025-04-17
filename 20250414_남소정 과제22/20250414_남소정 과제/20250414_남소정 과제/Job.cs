using EEnum;//가지고 올 함수나 변수가 있는 네임스페이스 이름 using으로 가져오기
using SSkill;

namespace JJob
{
    internal class JobData
    {
        public EJob jobtype { get; set; } //이 부분은 다시 공부해보기 -> main에서 활용하려면 타입이 같아야 하는데, if문으로 직업 확인하든, 델리게이트나 이벤트를 사용해서 확인할 수도 있나??
        public string name { get; set; }
        public int hp { get; set; }
        public int atk { get; set; }
        public ESkill skill { get; set; }//나른 네임스페이스에서 사용한 것은 왼쪽과 같이 해당 네임스페이스 안에 있는 변수 이름 가지고 와야 함
        public int speed { get; set; }


        public JobData(EJob job)// public 해당 클래스 이름(EEnum에서의 잡 이름 jop)
        {
            switch (job)
            {
                case EJob.woodcotter:
                    jobtype = job;
                    name = "나무꾼";
                    hp = 200;
                    atk = 100;
                    speed = 30;
                    //skill => 적의 방어 1회 무효화 만들기
                    break;
                case EJob.swordsman:
                    jobtype = job;
                    name = "검사";
                    hp = 100;
                    atk = 200;
                    speed = 50;
                    //skill => 스피드 업
                    break;
                case EJob.merchant:
                    jobtype = job;
                    name = "상인";
                    hp = 150;
                    atk = 150;
                    speed = 40;
                    //skill => 랜덤 아이템 출현
                    break;
            }
        }
    }
}


/*
woodcotter,//나무꾼
swordsman,//검사
merchant//상인

sshield,//방패
sspeedup,//스피트 증가
srandomitem//랜덤 아이템
    }

*/