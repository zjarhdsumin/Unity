using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bound : MonoBehaviour
{
    private BoxCollider2D bound;
    private cameraManager theCamera;

    // Start is called before the first frame update
    void Start()
    {
        theCamera = FindObjectOfType<cameraManager>();
        if(theCamera.targetBound == 1){
            GameObject macObject = GameObject.FindWithTag("mac");
            if (macObject != null)
            {
                bound = macObject.GetComponent<BoxCollider2D>();
            }
            else
            {
                Debug.LogError("Bound object with tag 'mac' not found.");
            }
        }
        else if(theCamera.targetBound == 2){
            GameObject pumaObject = GameObject.FindWithTag("puma");
            if (pumaObject != null)
            {
                bound = pumaObject.GetComponent<BoxCollider2D>();
            }
            else
            {
                Debug.LogError("Bound object with tag 'puma' not found.");
            }
        }
        else if(theCamera.targetBound == 3){
            GameObject pengObject = GameObject.FindWithTag("peng");
            if(pengObject != null){
                bound = pengObject.GetComponent<BoxCollider2D>();
            }
            else{
                Debug.LogError("Bound object with tag 'peng' not found.");
            }
        }
        else {
            GameObject Object = GameObject.FindWithTag("bound");
            if (Object != null)
            {
                bound = Object.GetComponent<BoxCollider2D>();
            }
            else
            {
                Debug.LogError("Bound object with tag 'bound' not found.");
            }
        }
        theCamera.SetBound(bound);
    }

    public void SetBound(){
        if(theCamera != null){
            theCamera.SetBound(bound);
        }
    }
}
