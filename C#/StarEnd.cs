using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarEnd : MonoBehaviour
{
    public GameObject go;
    public Dialogue dialogue;
    private DialogueManager theDM; //다이얼로그 실행
    private PlayerManager thePlayer;
    private DatabaseManager theDB;
    private FadeManager theFade;
    private bool flag = false;
    // Start is called before the first frame update
    void Start()
    {
        theDM = FindObjectOfType<DialogueManager>();
        thePlayer = FindObjectOfType<PlayerManager>();
        theDB = FindObjectOfType<DatabaseManager>();
        theFade = FindObjectOfType<FadeManager>();
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (!flag && Input.GetKey(KeyCode.Space) && theDB.star)
        {
            flag = true;
            theDM.ShowDialogue(dialogue);
            StartCoroutine(StarEndCouroutine());
        }
    }
    public void ResetFlag()
    {
        flag = false;
    }
    IEnumerator StarEndCouroutine()
    {
        yield return new WaitForSeconds(2f);
        theFade.FadeOut();
        go.SetActive(true);
        if(Input.GetKey(KeyCode.Escape)){
            Application.Quit();
        }
    }
}
