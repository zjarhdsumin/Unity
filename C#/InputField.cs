using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputField : MonoBehaviour
{
    public Text inputtext;
    
    private OrderManager theOrder;
    private GameObject input;
    // Start is called before the first frame update
    void Start()
    {
        input = this.gameObject;
        if (input != null)
        {
            input.SetActive(false);
        }
        else
        {
            Debug.LogError("error");
        }
    }

    public int check() //답이 맞으면 true를 반환함
    {
        Debug.Log("이곳은 check");
        input.SetActive(true);
        theOrder.NotMove();
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (inputtext.text == "0401")
            {
                print("와 맞았다.");
                input.SetActive(false);
                theOrder.YesMove();
                return 1; //정답
            }
            else
            {
                print("와 틀렸다.");
                input.SetActive(false);
                theOrder.YesMove();
                return 2; //오답
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            input.SetActive(false);
            theOrder.YesMove();
            return 3; //입력 종료
        }
        input.SetActive(false);
        theOrder.YesMove();
        return 4; //에러
    }
}
