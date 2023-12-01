using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BodyEvent : MonoBehaviour
{
    public Dialogue dialogue1;
    public Dialogue dialogue2; //대화가 두 번 진행되기 때문
    private DialogueManager theDM; //다이얼로그 실행
    private PlayerManager thePlayer;
    private bool flag = false;
    private static bool first = false;
    private void Awake()
    {
        if(first){
            Destroy(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        theDM = FindObjectOfType<DialogueManager>();
        thePlayer = FindObjectOfType<PlayerManager>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!flag && Input.GetKey(KeyCode.Space) && thePlayer.animator.GetFloat("DirY") == 1)
        {
            flag = true;
            if (thePlayer.key)
            {
                first = true;
                StartCoroutine(DestroyBodyGurd());
            }
            else
            {
                theDM.ShowDialogue(dialogue1);
            }
        }
    }

    IEnumerator DestroyBodyGurd()
    {
        theDM.ShowDialogue(dialogue2);
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
    }

    public void ResetFlag()
    {
        flag = false;
    }
}
