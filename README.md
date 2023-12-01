# Unity
## <svg role="img" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><title>Unity</title><path d="m12.9288 4.2939 3.7997 2.1929c.1366.077.1415.2905 0 .3675l-4.515 2.6076a.4192.4192 0 0 1-.4246 0L7.274 6.8543c-.139-.0745-.1415-.293 0-.3675l3.7972-2.193V0L1.3758 5.5977V16.793l3.7177-2.1456v-4.3858c-.0025-.1565.1813-.2682.318-.1838l4.5148 2.6076a.4252.4252 0 0 1 .2136.3676v5.2127c.0025.1565-.1813.2682-.3179.1838l-3.7996-2.1929-3.7178 2.1457L12 24l9.6954-5.5977-3.7178-2.1457-3.7996 2.1929c-.1341.082-.3229-.0248-.3179-.1838V13.053c0-.1565.087-.2956.2136-.3676l4.5149-2.6076c.134-.082.3228.0224.3179.1838v4.3858l3.7177 2.1456V5.5977L12.9288 0Z"/></svg> Unity로 2D 게임 만들기

## 🙋‍♂️ 참여 인원
- 

### 🛠 스크립트 소개
- PlayerManager.cs : 플레이어 이동 관리
    - Player.cs : PlayerManager.cs 부모 클래스. 중복 변수/함수 정의
- cameraManager.cs : 메인 카메라 관리
    - Bound.cs : 카메라 이동 가능 영역 제한

- TransferPoint.cs : 씬 이동
- TransferSamePoint.cs : 맵 이동
- homePoint.cs : 씬 이동 시 도착 지점
- portalTransfer.cs : 포탈을 통한 맵 이동

- BGMManager.cs : 배경 음악 관리
    - dowBGM.cs
    - fadeinfadeoutTest.cs : BGMManager.cs 예시
- OrderManager.cs : 플레이어 or NPC 등 움직임 관리
    - BodyEvent.cs
    - TestOrder.cs : OrderManager 예시
- DialogueManager.cs : 대화창 관리
    - Dialogue.cs
    - NoticeDialogue.cs
    - Question.cs
- FadeManager.cs : 씬이나 맵 이동 시 FadeOut / FadeIn 관리
- audioManager.cs : 플레이어 걸음 소리, 텍스트 출력 소리 등 사운드 관리
