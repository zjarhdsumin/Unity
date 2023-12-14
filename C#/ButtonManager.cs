using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    private FadeManager theFade; //시작할 때 화면이 어두워졌다가 시작하도록 함
    // private AudioManager theAudio; //버튼 클릭 시 소리
    // private PlayerManager thePlayer;
    // private cameraManager theCamera;
    // private GameManager theGM;
    public SpriteRenderer black;
    private Color color;
    private WaitForSeconds waitTime = new WaitForSeconds(0.01f);

    // Start is called before the first frame update
    void Start()
    {
        theFade = FindObjectOfType<FadeManager>();
        // thePlayer = FindObjectOfType<PlayerManager>();
        // theGM = FindObjectOfType<GameManager>();
        // theCamera = FindObjectOfType<cameraManager>();
    }

    // Update is called once per frame
    public void StartGame()
    {
        StartCoroutine(GameStartCoroutine());
    }

    IEnumerator GameStartCoroutine()
    {
        color = black.color;

        while (color.a < 1f)
        {
            color.a += 0.02f;
            black.color = color;
            yield return waitTime;
        }
        yield return new WaitForSeconds(2f);
        // Color color = thePlayer.GetComponent<SpriteRenderer>().color;
        // color.a = 1f;
        // thePlayer.GetComponent<SpriteRenderer>().color = color;
        // thePlayer.currentMapName = "SampleScene";
        SceneManager.LoadScene("SampleScene");
        // thePlayer.transform.position = new Vector3(-5f, 0f, 0f);
        // theCamera.transform.position = new Vector3(-0.2f, 0f, -10f);
        // theCamera.targetBound = 0;
        // theFade.FadeIn();
    }


    public void NoticeGame()
    {
        //방법 소개 오브젝트 띄우기
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
