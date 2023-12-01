# Unity
## Unity로 2D 게임 만들기

## 🔍 화면 예시
(수정 예정)

## 🙋‍♂️ 참여 인원
- 개발 1인
- 캐릭터 디자인 및 아이템 디자인 1인

## Teck Stack
### Languages
- ![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white)
### Tools
- ![Visual Studio Code](https://img.shields.io/badge/Visual%20Studio%20Code-0078d7.svg?style=for-the-badge&logo=visual-studio-code&logoColor=white)
- ![Unity](https://img.shields.io/badge/unity-%23000000.svg?style=for-the-badge&logo=unity&logoColor=white)
- ![GitHub](https://img.shields.io/badge/github-%23121011.svg?style=for-the-badge&logo=github&logoColor=white)
### Record
- ![Notion](https://open-pizza-3d8.notion.site/Unity-ec12976aac374c86b6c1582500615525?pvs=4)

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
