using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventoryGUI : MonoBehaviour
{


    pickupItem pickItem;

    // Start is called before the first frame update
    void Start()
    {
        pickItem = GetComponent<pickupItem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
