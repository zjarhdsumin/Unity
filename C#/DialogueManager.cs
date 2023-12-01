using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private static DialogueManager instance;

    public Text talkText;
    public SpriteRenderer rendererDialogue;

    private List<Sprite> listDialogue; //Dialogue.cs 내 Dialogue 배열을 넣음
    private List<string> listSentences;

    private int count; //대화 진행 상황

    public Animator animDialogue;
    private OrderManager theOrder;

    public bool talking = false;

    private void Awake() //스크립트 실행 시 Start보다 먼저 실행됨
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject); //해당 게임 오브젝트는 다른 씬을 로드할 때마다 파괴하지 말라는 의미
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        talkText.text = "";
        listSentences = new List<string>();
        listDialogue = new List<Sprite>();
        theOrder = FindObjectOfType<OrderManager>();
    }

    public void ExitDialogue()
    { //화면에 등장했던 이미지와 텍스트바가 사라짐
        count = 0;
        talkText.text = "";
        listSentences.Clear();
        listDialogue.Clear();
        animDialogue.SetBool("append", false);
        talking = false;
        theOrder.YesMove();
        NoticeDialogue[] nds = FindObjectsOfType<NoticeDialogue>();
        foreach(var nd in nds){
            nd.ResetFlag();
        }
        BodyEvent[] bes = FindObjectsOfType<BodyEvent>();
        foreach(var be in bes){
            be.ResetFlag();
        }
        Question[] qs = FindObjectsOfType<Question>();
        foreach(var q in qs){
            q.ResetFlag();
        }
    }

    public void ShowDialogue(Dialogue dialogue)
    {
        talking = true;
        theOrder.NotMove();
        for (int i = 0; i < dialogue.sentences.Length; i++)
        {
            listSentences.Add(dialogue.sentences[i]);
            listDialogue.Add(dialogue.Dialogues[i]);
        }
        animDialogue.SetBool("append", true); //애니메이션 활성화
        StartCoroutine(StartDialogueCoroutine());
    }

    IEnumerator StartDialogueCoroutine()
    {
        if (count > 0) //count가 -1이면 아래 if문에서 터지기 때문에 방지용
        {
            if (listDialogue[count] != listDialogue[count - 1])
            { //대화창 변경
                animDialogue.SetBool("append", false); //기존 대화창 숨김 
                yield return new WaitForSeconds(0.02f);
                rendererDialogue.GetComponent<SpriteRenderer>().sprite = listDialogue[count]; //대화창 변경
                animDialogue.SetBool("append", true); //대화창 띄우기
            }
            else
            { //대화창이 변경되지 않았을 경우
                yield return new WaitForSeconds(0.03f);
            }
        }
        else
        { //count가 0보다 작거나 같을 때
            rendererDialogue.GetComponent<SpriteRenderer>().sprite = listDialogue[count]; //첫 이미지는 무조건 교체가 일어나야 하기 때문
        }
        yield return new WaitForSeconds(0.02f);
        for (int i = 0; i < listSentences[count].Length; i++)
        { //문장 출력
            talkText.text += listSentences[count][i]; //count번째 문장의 i번째 글자를 출력 -> 한글자씩 출력
            yield return new WaitForSeconds(0.02f); //글자 출력 대기 시간 -> 천천히 출력되도록 하기 위함
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (talking)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                count++;
                talkText.text = "";
                if (count == listSentences.Count) //조건 비교 전 count++이 이루어지기 때문에 -1을 빼야 함
                {
                    //카운트가 리스트의 수와 같으면 종료 -> 다 읽은 것이기 때문임
                    StopAllCoroutines(); //모든 코루틴 종료
                    ExitDialogue(); //모든 대화창 사라지게 하기
                }
                else
                {
                    StopAllCoroutines();
                    StartCoroutine(StartDialogueCoroutine());
                }
            }
        }
    }
}
