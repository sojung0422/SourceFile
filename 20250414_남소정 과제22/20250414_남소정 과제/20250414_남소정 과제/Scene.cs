/*
 3. 딕셔너리를 활용

ㄴ씬클래스를 만듦(부모 -> 추상)
ㄴ게임씬, 메인씬,,등 한 3개 정도 만듦(위에꺼 상속해야 함)
ㄴ씬 매니저는 위에꺼 다 관리하는 녀석으로 씬매니저 클래스 만듦
ㄴ씬 매니저는 전체 씬을 관리하는 녀석
ㄴDic<string, Scene>
ㄴ 씬을 추가하는 메서드
ㄴ씬을 삭제하는 메서드
ㄴ씬을 바구는 메서드

메인에서는
ㄴAddSene("mainMenu", new MainScene());
ㄴAddSene("mainMenu", new MainScene());
ㄴ출력하면 현재 씬의 이름이 나와야 함
ㄴ예를 들어서 현재 씬인데(main), 특정 키를 누르면 씬이 전환이 됨(도박장 입장)
 
 */

namespace SScene
{
    internal class Scene
    {
     
    }
}
