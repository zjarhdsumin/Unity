using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound{
    public string name; //사운드 이름
    public AudioClip clip; //사운드 파일
    private AudioSource source; //사운드 플레이어
    public float volumn; //음량
    public bool loop; //반복 여부

    public void SetSource(AudioSource _source){
        source = _source;
        source.clip = clip; //_source의 clip과 loop를 위 변수값으로 설정
        source.volume = volumn;
        source.loop = loop;
    }

    public void Play(){
        source.Play();
    }

    public void Stop(){
        source.Stop();
    }

    public void SetVolume(){
        source.volume = volumn;
    }

    public void SetLoop(){
        source.loop = true;
    }

    public void SetLoopCance(){
        source.loop = false;
    }
}
public class audioManager : MonoBehaviour
{
    static public audioManager instance;
    [SerializeField]
    public Sound[] sounds; //sound는 여러 개이기 때문
    private void Awake() //스크립트 실행 시 Start보다 먼저 실행됨
    {
        if(instance != null){
            Destroy(this.gameObject);
        }
        else{
            DontDestroyOnLoad(this.gameObject); //해당 게임 오브젝트는 다른 씬을 로드할 때마다 파괴하지 말라는 의미
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < sounds.Length; i++){
            GameObject soundObject = new GameObject("사운드 파일 이름 : " + i + " = " + sounds[i].name); //->Hierarchy에 설정한 오디오들이 띄워짐 -> 오디오가 많을수록 Hierarchy를 많이 씀
            sounds[i].SetSource(soundObject.AddComponent<AudioSource>());
            soundObject.transform.SetParent(this.transform); //이 소스코드를 실행하는 오브젝트를 부모로 삼겠다는 의미
        }
    }

    public void Play(string _name){
        for(int i = 0; i < sounds.Length; i++){
            if(_name == sounds[i].name){
                sounds[i].Play(); //Sound 클래스의 Play
                return;
            }
        }
    }

    public void Stop(string _name){ //재생 중이던 사운드 파일 중단
        for(int i = 0; i < sounds.Length; i++){
            if(_name == sounds[i].name){
                sounds[i].Stop(); //Sound 클래스
                return;
            }
        }
    }

    public void SetVolume(string _name, float v){ //음악 반복 재생 취소
        for(int i = 0; i < sounds.Length; i++){
            if(_name == sounds[i].name){
                sounds[i].volumn = v;
                sounds[i].SetVolume(); //Sound 클래스
                return;
            }
        }
    }

    public void SetLoop(string _name){ //음악이 반복 재생될 수 있도록 설정
        for(int i = 0; i < sounds.Length; i++){
            if(_name == sounds[i].name){
                sounds[i].SetLoop(); //Sound 클래스
                return;
            }
        }
    }

    public void SetLoopCance(string _name){ //음악 반복 재생 취소
        for(int i = 0; i < sounds.Length; i++){
            if(_name == sounds[i].name){
                sounds[i].SetLoopCance(); //Sound 클래스
                return;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
