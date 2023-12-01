using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalTransfer : MonoBehaviour
{
    public Transform target; //출구 위치 변수
    public BoxCollider2D targetBound;
    private SpriteRenderer spriteRenderer;
    private Player thePlayer;
    private cameraManager theCamera;
    private FadeManager theFade;

    int fadeDuration = 1;
    int waitDuration = 1;

    void Start()
    {
        thePlayer = FindObjectOfType<Player>();
        theCamera = FindObjectOfType<cameraManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        theFade = FindObjectOfType<FadeManager>();
        StartCoroutine(FadeInOut());
    }

    private IEnumerator FadeInOut()
    {
        while (true)
        {
            yield return StartCoroutine(FadeOut());
            yield return new WaitForSeconds(waitDuration);
            yield return StartCoroutine(FadeIn());
            yield return new WaitForSeconds(waitDuration);
        }
    }
    private IEnumerator FadeOut()
    {
        float timer = 0f;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;

            // 서서히 사라지기
            float alpha = Mathf.Lerp(1f, 0f, timer / fadeDuration);
            Color currentColor = spriteRenderer.color;
            currentColor.a = alpha;
            spriteRenderer.color = currentColor;

            yield return null;
        }
    }

    private IEnumerator FadeIn()
    {
        float timer = 0f;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;

            // 서서히 나타나기
            float alpha = Mathf.Lerp(0f, 1f, timer / fadeDuration);
            Color currentColor = spriteRenderer.color;
            currentColor.a = alpha;
            spriteRenderer.color = currentColor;

            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            StartCoroutine(TransferSameCoroutine());
        }
    }
    IEnumerator TransferSameCoroutine()
    {
        theFade.FadeOut();
        yield return new WaitForSeconds(1f);
        theCamera.SetBound(targetBound);
        // 플레이어의 위치를 목표 위치로 설정
        thePlayer.transform.position = target.position;
        // 카메라의 위치를 목표 위치로 설정 (만약 카메라도 이동해야 한다면)
        theCamera.transform.position = new Vector3(target.position.x, target.position.y, theCamera.transform.position.z);
        theFade.FadeIn();
    }
}
