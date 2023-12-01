using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BGMManager : MonoBehaviour
{
    static public BGMManager instance;

    public AudioClip[] clips; //배경음악들
    private AudioSource source;

    private WaitForSeconds waitTime = new WaitForSeconds(0.01f); //-> new 생성자가 한 번 실행됨

    private void Awake() //스크립트 실행 시 Start보다 먼저 실행됨
    {
        if(instance != null){
            Destroy(this.gameObject);
        }
        else{
            DontDestroyOnLoad(this.gameObject); //해당 게임 오브젝트는 다른 씬을 로드할 때마다 파괴하지 말라는 의미
            instance = this;
            source = GetComponent<AudioSource>();

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // source = GetComponent<AudioSource>();
        
    }

    public void Play(int playMusicTrack){
        source.volume = 1; //음악 시작 시 무조건 음량을 1로 초기화
        source.clip = clips[playMusicTrack]; //clips 중 원하는 트랙 번호에 해당하는 파일을 가져옴
        source.loop = true;
        source.Play(); //실행
    }

    public void Pause(){ //일시 정지
        source.Pause(); //AudioSource에서 지원하는 기능
    }

    public void UnPause(){ //다시 재생
        source.UnPause();
    }

    public void SetVolume(float v){ //음량 설정
        source.volume = v;
    }

    public void Stop(){
        source.Stop();
    }

    public void FadeOutMusic(){ //서서히 종료
        StopAllCoroutines(); //fadeout과 fadein이 동시에 진행된다면 꼬일 수 있어서 실행되고 있는 coroutine을 멈춤
        //coroutine 사용
        StartCoroutine(FadeOutMusicCoroutine());
    }

    IEnumerator FadeOutMusicCoroutine(){
        for(float f = 1.0f; f >= 0f; f -= 0.01f){
            source.volume = f; //100번 반복하면서 점점 감소
            yield return waitTime; //-> new 생성자 100번 반복 -> 성능에 악영향 -> 반복문 내에 new가 자주 호출된다면, 따로 선언하는 것이 좋음
        }
    } 

    public void FadeInMusic(){
        StopAllCoroutines(); //fadeout과 fadein이 동시에 진행된다면 꼬일 수 있어서 실행되고 있는 coroutine을 멈춤
        StartCoroutine(FadeInMusicCoroutine());
    }

    IEnumerator FadeInMusicCoroutine(){
        for(float f = 0f; f <= 1f; f += 0.01f){
            source.volume = f; //100번 반복하면서 점점 증가
            yield return waitTime; //-> new 생성자 100번 반복 -> 성능에 악영향 -> 반복문 내에 new가 자주 호출된다면, 따로 선언하는 것이 좋음
        }
    }
}
