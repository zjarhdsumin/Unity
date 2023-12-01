using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class homePoint : MonoBehaviour
{
    public string startPoint; //맵 이동 시 플레이어가 시작될 위치
    private PlayerManager thePlayer;
    private cameraManager theCamera;
    public int thePoint;

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerManager>();
        theCamera = FindObjectOfType<cameraManager>();
        if(startPoint == thePlayer.currentMapName && thePoint == thePlayer.targetStartPoint) {
            if(startPoint == "MacMaze" || startPoint == "PengHome"){
                theCamera.SetOrthographicSize(6);
            }
            else{
                theCamera.SetOrthographicSize(5.3f);
            }
            theCamera.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, theCamera.transform.position.z);
            thePlayer.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 0);
            theCamera.targetBound = thePoint;
        }

    }
}