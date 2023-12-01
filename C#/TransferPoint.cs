using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransferPoint : MonoBehaviour
{

    public string transferMapName; //이동할 맵 이름
    public int targetStartPoint;
    private PlayerManager thePlayer; //player의 currentMapName에 transferMapName을 넣어주기 위해 선언
    private FadeManager theFade;
    private OrderManager theOrder;
    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerManager>(); //GetComponent<>와 유사하나 검색 범위의 차이가 존재함. FOOT는 하이어라키에 있는 모든 객체의 <> 컴포넌트를 검색해 리턴
        theFade = FindObjectOfType<FadeManager>();
        theOrder = FindObjectOfType<OrderManager>();
    }

    //해당 스크립트가 있는 collider에 닿으면 실행되는 내장 함수로, 해당 collider의 is Trigger가 활성화되어 있을 때 실행됨
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        { //collider에 닿은 오브젝트 이름이 반환됨
            StartCoroutine(TransferCoroutine());//페이드아웃 -> 페이드인 사이에 대기를 주기 위해 코루틴 사용
            //코루틴을 사용하지 않았을 경우 변수와 반복문, deltaTime 등을 사용해야 함
        }
    }

    IEnumerator TransferCoroutine() 
    {
        theOrder.NotMove();
        theFade.FadeOut();
        yield return new WaitForSeconds(1f);
        thePlayer.currentMapName = transferMapName;
        thePlayer.targetStartPoint = this.targetStartPoint;
        SceneManager.LoadScene(transferMapName);
        theFade.FadeIn();
        theOrder.YesMove();
    }
}
