using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PnegQuizEvent : MonoBehaviour
{
    public Dialogue dialogue1;
    public Dialogue dialogue2;
    public Dialogue dialogue3;
    private DialogueManager theDM;
    private PlayerManager thePlayer;
    private InputField theInput;
    private bool flag = false;
    private static bool first = false;
    private void Awake()
    {
        if (first)
        {
            Destroy(this.gameObject);
        }
        // theInput = FindObjectOfType<InputField>();
    }

    void Start()
    {
        theDM = FindObjectOfType<DialogueManager>();
        thePlayer = FindObjectOfType<PlayerManager>();
        theInput = FindObjectOfType<InputField>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!flag && other.transform.tag == "Player")
        {
            Debug.Log("durldkjfslkdjf");
            flag = true;
            theDM.ShowDialogue(dialogue1);
            int result = theInput.check();
            if (result == 1)
            {
                DestroyBodyGurd();
            }
            else
            {
                theDM.ShowDialogue(dialogue3);
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
