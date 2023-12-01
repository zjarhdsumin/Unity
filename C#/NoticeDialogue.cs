using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NoticeDialogue : MonoBehaviour
{
    [SerializeField]
    public Dialogue dialogue;
    private DialogueManager theDM;
    private PlayerManager thePlayer;
    private bool hasTrigger = false;

    // Start is called before the first frame update
    void Start()
    {
        theDM = FindObjectOfType<DialogueManager>();
        thePlayer = FindObjectOfType<PlayerManager>();
    }

    // Update is called once per frame
    private void OnTriggerStay2D(Collider2D other) //트리거 위치에 있으면 계속 실행됨
    {
        //플레이어가 위를 바라보고 있으면서 flag가 not false이고 스페이스바가 눌렸을 때 실행됨
        if (thePlayer.animator.GetFloat("DirY") == 1f && !hasTrigger && Input.GetKey(KeyCode.Space))
        {
            hasTrigger = true;
            theDM.ShowDialogue(dialogue);
        }
    }

    public void ResetFlag()
    {
        hasTrigger = false;
    }
}
