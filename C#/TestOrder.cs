using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TestMove{
    public string name;
    public string direction;
}

public class TestOrder : MonoBehaviour
{
    [SerializeField]
    public TestMove[] move;
    private OrderManager theOrder;
    // Start is called before the first frame update
    void Start()
    {
        theOrder = FindObjectOfType<OrderManager>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.name == "Player"){
            theOrder.PreLoadCharacter();
            for(int i = 0; i < move.Length; i++){
                theOrder.Move(move[i].name, move[i].direction);
            }
        }
    }
}
