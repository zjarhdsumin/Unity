using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCardEvent : MonoBehaviour
{
    public Dialogue dialogue1;
    public Dialogue dialogue2;
    private DialogueManager theDM; //다이얼로그 실행
    private PlayerManager thePlayer;
    private bool flag = false;
    // Start is called before the first frame update
    void Start()
    {
        theDM = FindObjectOfType<DialogueManager>();
        thePlayer = FindObjectOfType<PlayerManager>();
    }

    // Update is called once per frame
    private void OnTriggerStay2D(Collider2D other)
    {
        if (!flag && Input.GetKey(KeyCode.Space))
        {
            flag = true;
            if (thePlayer.key)
            {
                theDM.ShowDialogue(dialogue1);
            }
            else
            {
                thePlayer.key = true;
                theDM.ShowDialogue(dialogue2);
            }
        }
    }
    public void ResetFlag()
    {
        flag = false;
    }
}
