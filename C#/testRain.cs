using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testRain : MonoBehaviour
{
    private WeatherManager theW;
    public bool rain;
    // Start is called before the first frame update
    void Start()
    {
        theW = FindObjectOfType<WeatherManager>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(rain){
            // theW.Rain();
            theW.RainDrop();
        }
        else{
            theW.StopRain();
        }
    }
}
