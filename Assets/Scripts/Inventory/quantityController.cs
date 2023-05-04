using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quantityController : MonoBehaviour
{

    pickupItem pickItem;
    public GameObject player;

    public int markiplier; // Hello everybody my name is markiplier

    // Start is called before the first frame update
    void Start()
    {
        pickItem = player.GetComponent<pickupItem>();
    }


    public void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player"){
            pickItem.itemMultiplier = markiplier;
        }
    }

    public void OnTriggerExit2D(Collider2D other) {
        pickItem.itemMultiplier = 1;
    }



    
}
