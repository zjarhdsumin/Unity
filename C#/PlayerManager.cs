using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Player
{
    //static : 정적 변수. 해당 스크립트가 적용된 모든 객체는 static으로 선언된 변수의 값을 공유함. 때문에 A의 instance가 1이고, B의 instance가 2일 때, A의 instance를 3으로 바꾸면 B의 값도 3이 됨
    static public PlayerManager instance;
    public string currentMapName; //캐릭터가 있는 맵의 이름. TransferPoint 스크립트에 있는 transferMapName을 저장함
    public int targetStartPoint;
    private audioManager theAudio;
    public float runSpeed;
    private float applyRunSpeed;
    private bool applyRunFlag = false;
    public bool key = false;

    private bool canMove = true;
    public bool notMove = false;

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
        queue = new Queue<string>();
        boxCollider = GetComponent<BoxCollider2D>();
        // audioSource = GetComponent<AudioSource>(); //Player의 Audio Source 컴포넌트를 통제할 수 있음
        animator = GetComponent<Animator>();
        theAudio = FindObjectOfType<audioManager>();
    }
    IEnumerator MoveCoroutine()
    {
        while (Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0 && !notMove)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                applyRunSpeed = runSpeed;
                applyRunFlag = true;
            }
            else
            {
                applyRunSpeed = 0;
                applyRunFlag = false;
            }
            vector.Set(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), transform.position.z);

            if (vector.x != 0)
            {
                vector.y = 0;
            }
            //만약 x가 0이 아니면 좌우로 이동하는 것이기 때문에 상하 이동에 대한 y값은 0으로 만들겠다는 의미

            animator.SetFloat("DirX", vector.x); //파라미터값으로 설정한 DirY가 -1이면 왼쪽으로 가는 모션을 실행하도록 만들었기 때문에 해당 변수의 값인 vector.x를 받음
            animator.SetFloat("DirY", vector.y);

            bool checkCollsionFlag = base.CheckCollsion();
            if (checkCollsionFlag) break; //앞에 무언가 있으면 checkCollsionFlag가 true가 되면서 움직이지 않게 됨

            animator.SetBool("Walking", true); //Standing Tree에서 Walking Tree로 상태전이

            while (currentWalkCount < walkCount)
            {
                if (vector.x != 0)
                {
                    transform.Translate(vector.x * (speed + applyRunSpeed), 0, 0);
                }
                else if (vector.y != 0)
                {
                    transform.Translate(0, vector.y * (speed + applyRunSpeed), 0);
                }
                if (applyRunFlag)
                {
                    currentWalkCount++;
                }
                currentWalkCount++;
                yield return new WaitForSeconds(0.01f);
            }

            currentWalkCount = 0;
        }
        animator.SetBool("Walking", false); //Walking Tree에서 Standing Tree로 상태전이
        canMove = true;
    }
    // Update is called once per frame
    void Update() //게임이 돌아가는 동안 계속 호출됨
    {
        if (canMove && !notMove)
        {
            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                canMove = false;
                StartCoroutine(MoveCoroutine());
            }
        }
    }
}
