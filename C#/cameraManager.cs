using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cameraManager : MonoBehaviour
{
    static public cameraManager instance;
    public GameObject target; //카메라가 따라갈 대상
    public float moveSpeed; //카메라가 얼마나 빠른 속도로 대상을 쫓을 것인지 속도 지정
    private Vector3 targetPosition; //대상의 현재 위치값
    public int targetBound;

    public BoxCollider2D bound;
    //박스 컬라이더 영역의 최대 최소 xyz값을 가짐
    private Vector3 minBound;
    private Vector3 maxBound;

    //영역을 벗어났을 때 너비의 절반과 높이의 절반을 빼주기 위함
    private float halfWidth;
    private float halfHeight;

    //카메라의 반높이 값을 구할 속성을 이용하기 위한 변수
    private Camera theCamera;

    private void Awake() //스크립트 실행 시 Start보다 먼저 실행됨
    {
        if(instance != null){
            Destroy(this.gameObject);
        }
        else{
            DontDestroyOnLoad(this.gameObject); //해당 게임 오브젝트는 다른 씬을 로드할 때마다 파괴하지 말라는 의미
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        theCamera = GetComponent<Camera>();
        minBound = bound.bounds.min; //위에서 선언한 bound의 영역의 최소값을 minBound에 넣음
        maxBound = bound.bounds.max;
        halfHeight = theCamera.orthographicSize;
        halfWidth = halfHeight * Screen.width / Screen.height; //반너비를 구하는 공식. Screen은 해상도를 의미함
    }

    // Update is called once per frame
    //카메라는 매 프레임마다 호출이 이루어지기 때문에 update() 내에 작성
    void Update()
    {
        if(target.gameObject != null){
            targetPosition.Set(target.transform.position.x, target.transform.position.y, this.transform.position.z);
            //this : 해당 스크립트가 적용될 객체. 따라서 카메라를 가리킴 (생략 가능)
            this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, moveSpeed * Time.deltaTime);
            //Lefp : A와 B 사이의 선형 보간으로 중간값을 리턴함. (A값, B값, 속도값) 순으로 인자값 설정 (ex) (1, 10, 0.5f) -> 5)
            //deltaTime : 1초에 실행되는 프레임의 역수로 1초에 60 프레임이 실행된다면 60분의 1 값을 가짐. 즉, 1초 동안 moveSpeed만큼 이동시키겠다는 의미

            //Clamp() : (판단하고자 하는 값, 최소값, 최대값) -> 만약 판단하고자 하는 값이 최소값보다 작으면 최소값으로, 최소값과 최대값 사이에 있으면 판단하고자 하는 값으로, 최대값보다 크면 최대값으로 설정됨
            float clampedX = Mathf.Clamp(this.transform.position.x, minBound.x + halfWidth, maxBound.x - halfWidth ); //범위 안에 가둬두는 함수 : Clamp()
            float clampedY = Mathf.Clamp(this.transform.position.y, minBound.y + halfHeight, maxBound.y - halfHeight);

            this.transform.position = new Vector3(clampedX, clampedY, this.transform.position.z); //this 생략 가능
        }
    }

    public void SetBound(BoxCollider2D newBound){
        bound = newBound;
        minBound = bound.bounds.min;
        maxBound = bound.bounds.max;
    }

    public void SetOrthographicSize(float newSize){
        theCamera.orthographicSize = newSize;
    }
}