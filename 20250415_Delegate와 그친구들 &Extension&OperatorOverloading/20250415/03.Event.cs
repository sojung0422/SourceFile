
/******************************************
 [이벤트]
 - 일련의 사건이 발생했다라는 사실을 다른객체에 전달
 - 대리자 기반의 알림 시스템
 - UI 프로그래밍이나, 게임, 비동기 프로그래밍에서 사용
 - 옵저버 패턴을 구현하는데 주로 사용
 

[이벤트 선언]

 ******************************************/
namespace _20250415
{
    public class Player
    {
        public event Action OnGetCoin;  //이벤트

        public void GetCoin()
        {
            Console.WriteLine("플레이어가 코인을 얻음");
            //이벤트 발생
            OnGetCoin?.Invoke();

        }
    }
    public class UI
    {
        public void UpdateUI() { Console.WriteLine("UI에 코인 수를 갱신"); }
    }
    public class SFX
    {
        public void CoinSound() { Console.WriteLine("코인을 얻는 효과음 재생"); }
    }
    public class VFX
    {
        public void CoinEffect() { Console.WriteLine("코인이 반짝거리는 효과"); }
    }
    /*
           [델리게이트 체인과 이벤트 차이점]
           델리게이트 또한 체인을 통해 이벤트로서 구현이 가능
           하지만 델리게이트는 두가지 사항 때문에 이벤트로서 사용하기 적합하지 않다.
           1. = 대입연산을 통해 기존의 이벤트의 반응할 객체 상황이 초기화 될수 있음
           2. 클래스 외부에서 이벤트를 발생시켜 원하지 않는 상황에 이벤트가 발생 가능
           event 키워드는 델리게이트에서 기능을 제한하여 이벤트 전용의 기능만으로 사용함.
           */
    public class EventSender
    {
        public Action onDelegate;   //일반 델리게이트
        public event Action onEvent;    //이벤트

        public void DelegateCall()
        {
            onDelegate?.Invoke();  //직접호출가능
        }
        public void EventCall()
        {
            onEvent?.Invoke();  // 클래스 내부에서만 호출가능
        }
    }
    public class EventListner
    {
        public void ReAction() { Console.WriteLine("반응 실행"); }
    }
    internal class _03
    {
        static void Main()
        {
            Player player = new Player();   
            UI ui = new UI();
            SFX sfx = new SFX();
            VFX vfx = new VFX();

            player.OnGetCoin += ui.UpdateUI;
            player.OnGetCoin += sfx.CoinSound;

            player.GetCoin();
            player.OnGetCoin += vfx.CoinEffect;
            Console.WriteLine();
            player.GetCoin();
            Console.WriteLine();
            player.OnGetCoin -= sfx.CoinSound;
            player.GetCoin();


            ////////////////////////////////////////
           EventSender sender = new EventSender();  
            EventListner listner1 = new EventListner();  
            EventListner listner2 = new EventListner();  
            EventListner listner3 = new EventListner();

            //델리게이트는 = 대입 연산 가능
            //이벤트에 반응할 객체들의 상황을 잃을 문제점이 있음
            sender.onDelegate += listner1.ReAction;
            sender.onDelegate += listner2.ReAction;
            sender.onDelegate = listner3.ReAction;  //기존 핸들러 초기화


            sender.onEvent += listner1.ReAction;
            sender.onEvent += listner2.ReAction;
            //이벤트는 = 대입 연산이 불가(안정성 보장)
            //sender.onEvent = listner3.ReAction;


            //델리게이트는 외부에서 호출가능
            //객체가 일련의 사건이 발생하지 않아도 이벤트 발생이 진행될 문제점이 있음
            sender.onDelegate();

            //이벤트는 외부에서 직접 호출 불가능
            //객체가 일련의 사건이 발생한 경우에서만 내부에서 이벤트 발생 보장이 가능
            //sender.onEvent();
        }
    }
}
