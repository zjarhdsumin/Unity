using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseManager : MonoBehaviour
{
    private static DatabaseManager instance;
    // public string[] var_name;
    // public float[] var;
    // public string[] switch_name;
    // public bool[] switches; //true or false 값 저장
    public bool star = false;
    public bool peng = false;

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

    }
}
