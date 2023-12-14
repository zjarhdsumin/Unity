using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarEvent : MonoBehaviour
{
    private DatabaseManager theDB;

    // Start is called before the first frame update
    void Start()
    {
        theDB = FindObjectOfType<DatabaseManager>();
        if(theDB.star){
            gameObject.SetActive(true);
        }
        else{
            gameObject.SetActive(false);
        }
    }
}
