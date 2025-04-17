
/*************************************
 [Queue]
 -FIFO(FirstInFirstOut)구조를 따르는 컬렉션으로. 먼저 들어온 데이터가 먼저나간다
 -동적배열기반 원형 큐 구조를 사용
 -일반적으로 작업 대기열, 이벤트처리, 순차적 데이터 처리 등에 사용
 -턴 기반 게임의 행동순서 관리(플레이어와 적의 행동을 큐로 관리해서 먼저 등록된 순서대로 실행)
 -스킬 / 버프 지속 관리(특정 시간 동안 유지되는 버프를 큐에 넣고, 시간이 제거.)
 
 *************************************/
namespace _20250411
{


    class Skill
    {
        private Queue<string> skillQueue = new Queue<string>();

        public void AddSkill(string skillName)
        {
            skillQueue.Enqueue(skillName);
        }
        public void UseSkill()
        {
            if(skillQueue.Count>0)
            {
                string skill = skillQueue.Dequeue();
                Console.WriteLine($"스킬 발동 : {skill}");
            }
            else 
            {
                Console.WriteLine("스킬 없당");
            }
        }
        public void Show()
        {
            Console.WriteLine("현재 스킬 대기 ");
            foreach (var skill in skillQueue)
            {
                Console.Write($"{skill}");
            }
        }
    }


    internal class CQueue
    {


        static void Main()
        {
            Queue<string> queue = new Queue<string>();

            queue.Enqueue("플레이어 1");
            queue.Enqueue("플레이어 2");
            queue.Enqueue("플레이어 3");

            Console.WriteLine($"첫번째 플레이어{queue.Peek()}");

            while (queue.Count>0)
            {
                Console.WriteLine($"{queue.Dequeue()}가 행동 한다");
            }


            Console.WriteLine();
            Skill skill = new Skill();
            skill.AddSkill("정화");
            skill.AddSkill("천상의 축복");
            skill.AddSkill("탈진");

            Console.WriteLine();
            skill.Show();

            Console.WriteLine();
            skill.UseSkill();
            skill.UseSkill();
            Console.WriteLine();

            skill.Show();


        }
    }
}
