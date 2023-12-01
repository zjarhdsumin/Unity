using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question : MonoBehaviour
{
    public Dialogue dialogue;
    private DialogueManager theDM;
    private PlayerManager thePlayer;
    private bool flag = false;
    // Start is called before the first frame update
    void Start()
    {
        theDM = FindObjectOfType<DialogueManager>();
        thePlayer = FindObjectOfType<PlayerManager>();
    }

    private void OnTriggerStay2D(Collider2D other) {
        if(!flag && Input.GetKey(KeyCode.Space) && other.gameObject.name == "Player"){
            flag = true;
            theDM.ShowDialogue(dialogue);
        }
    }

    public void ResetFlag(){
        flag = false;
    }
}
