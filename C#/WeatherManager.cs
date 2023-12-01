using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherManager : MonoBehaviour
{
    static public WeatherManager instance;
    public ParticleSystem rain;
    public string rain_sound;
    // private audioManager theAudio; //날씨 효과음을 사용하기 위함
    private void Awake() //싱글톤
    {
        if(instance != null){
            Destroy(this.gameObject);
        }
        else{
            DontDestroyOnLoad(this.gameObject); //해당 게임 오브젝트는 다른 씬을 로드할 때마다 파괴하지 말라는 의미
            instance = this;
        }
    }

    void Start()
    {
        // theAudio = FindObjectOfType<audioManager>();

    }

    public void Rain(){
        // theAudio.Play(rain_sound);
        rain.Play();
    }
    public void StopRain(){
        // theAudio.Stop(rain_sound);
        rain.Stop();
    }
    public void RainDrop(){
        rain.Emit(10); //특정 개수만큼의 파티클만 떨어지게 함
        //이 함수를 사용해서 점점 많이 떨어지다가 쏴아아 떨어지게 할 수도 있고, 쏴아아 내리다가 점점 줄도록 만들 수도 있음
    }
}
