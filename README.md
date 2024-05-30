# Unity
![title](https://github.com/zjarhdsumin/Unity/assets/88326586/8d8438b2-f448-475d-9c37-10243a48b2a7)

## Unity로 2D 게임 만들기

## 🔍 화면 예시
### 타이틀 화면

<img width="819" alt="스크린샷 2023-12-14 오후 4 40 14" src="https://github.com/zjarhdsumin/Unity/assets/88326586/31a823d4-972e-4b0d-b913-c9015eacbd4b">

### 게임 시작 시 화면

<img width="820" alt="스크린샷 2023-12-14 오후 4 42 25" src="https://github.com/zjarhdsumin/Unity/assets/88326586/2acebca8-cc1a-43fc-88b7-83ba8bfee2e3">
<img width="823" alt="스크린샷 2023-12-14 오후 4 43 46" src="https://github.com/zjarhdsumin/Unity/assets/88326586/4940212b-ff2b-42bc-bfe9-36265d3a0058">
<img width="820" alt="스크린샷 2023-12-14 오후 4 43 11" src="https://github.com/zjarhdsumin/Unity/assets/88326586/63d4894a-1007-499b-ba3d-50d6b20f02cb">



## 🙋‍♂️ 참여 인원
- 개발 1인
- 캐릭터 디자인 및 아이템 디자인 1인

## :books: Teck Stack

### :pencil2: Languages

- ![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white)
- 
### 🧰 Tools

- ![Visual Studio Code](https://img.shields.io/badge/Visual%20Studio%20Code-0078d7.svg?style=for-the-badge&logo=visual-studio-code&logoColor=white)
- ![Unity](https://img.shields.io/badge/unity-%23000000.svg?style=for-the-badge&logo=unity&logoColor=white)
- ![GitHub](https://img.shields.io/badge/github-%23121011.svg?style=for-the-badge&logo=github&logoColor=white)
- 
### 🖇 Record

- ![Notion](https://img.shields.io/badge/Notion-%23000000.svg?style=for-the-badge&logo=notion&logoColor=white)


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
    - TestOrder.cs : OrderManager 예시
- DialogueManager.cs : 대화창 관리
    - Dialogue.cs
    - NoticeDialogue.cs
    - Question.cs
    - BodyEvent.cs
    - StarEvent.cs
    - StarEnd.cs : 엔딩 스크롤
    - PengEvent.cs
    - PengQuizEvent.cs
    - KeyCardEvent.cs
- FadeManager.cs : 씬이나 맵 이동 시 FadeOut / FadeIn 관리
- audioManager.cs : 플레이어 걸음 소리, 텍스트 출력 소리 등 사운드 관리
- WeatherManager.cs : 비 or 눈 등 날씨 관리
      - testRain.cs : 날씨 사용 예시
- ButtonManager.cs : 버튼 관리
- DatabaseManager.cs : 배열 및 변수를 사용해 데이터 저장
- GameManager.cs
- InputFiled.cs : 키 입력


