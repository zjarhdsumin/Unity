using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransferSamePoint : MonoBehaviour
{
    public Transform target; //출구 위치 변수
    public BoxCollider2D targetBound;
    private Player thePlayer;
    private cameraManager theCamera;

    void Start()
    {
        thePlayer = FindObjectOfType<Player>();
        theCamera = FindObjectOfType<cameraManager>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name == "Player")
        {
            theCamera.SetBound(targetBound);
            // 플레이어의 위치를 목표 위치로 설정
            thePlayer.transform.position = target.position;
            // 카메라의 위치를 목표 위치로 설정 (만약 카메라도 이동해야 한다면)
            theCamera.transform.position = new Vector3(target.position.x, target.position.y, theCamera.transform.position.z);
        }
    }
}
