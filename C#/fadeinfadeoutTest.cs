using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadeinfadeoutTest : MonoBehaviour
{
    BGMManager bgm;
    // Start is called before the first frame update
    void Start()
    {
        bgm = FindObjectOfType<BGMManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(FadeInFadeOut());
    }

    IEnumerator FadeInFadeOut(){
        bgm.FadeOutMusic(); //fade out 하고
        yield return new WaitForSeconds(3f); //3초 후
        bgm.FadeInMusic(); //faide in 함
    }
}
