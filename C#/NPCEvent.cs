using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCEvent : MonoBehaviour
{
    public Dialogue dialogue;
    private DialogueManager theDM; //다이얼로그 실행
    private PlayerManager thePlayer;
    private DatabaseManager theDB;
    private bool flag = false;
    // Start is called before the first frame update
    void Start()
    {
        theDM = FindObjectOfType<DialogueManager>();
        thePlayer = FindObjectOfType<PlayerManager>();
        theDB = FindObjectOfType<DatabaseManager>();
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (!flag && Input.GetKey(KeyCode.Space))
        {
            flag = true;
            theDM.ShowDialogue(dialogue);
            if(theDB.peng){
                theDB.star = true;
            }
        }
    }
    public void ResetFlag()
    {
        flag = false;
    }
}
