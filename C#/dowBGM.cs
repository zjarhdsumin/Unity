using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Test : MonoBehaviour
{
    static public Test instance;
    private BGMManager bgm;
    public int playMusicTrack;
    private PlayerManager thePlayer;
    // Start is called before the first frame update
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
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerManager>();
        bgm = FindObjectOfType<BGMManager>();

        if(thePlayer.currentMapName == "SampleScene"){
            bgm.SetVolume(0f);
            bgm.FadeInMusic();
            bgm.Play(playMusicTrack);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(thePlayer.currentMapName == "PumaMaze"){
            bgm.Pause();
        }
        else{
            bgm.UnPause();
        }
    }
}
