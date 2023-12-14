using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Bound bound;
    private PlayerManager thePlayer;
    private cameraManager theCamera;
    private FadeManager theFade;

    public void LoadStart()
    {
        StartCoroutine(LoadWaitCoroutine());
    }

    IEnumerator LoadWaitCoroutine()
    {
        yield return new WaitForSeconds(2f);
        thePlayer = FindObjectOfType<PlayerManager>();
        bound = FindObjectOfType<Bound>();
        theCamera = FindObjectOfType<cameraManager>();
        theFade = FindObjectOfType<FadeManager>();

        theCamera.target = GameObject.Find("Player"); //카메라가 따라갈 대상을 플레이어로 설정
        bound.SetBound();
        theFade.FadeIn();
    }
}
