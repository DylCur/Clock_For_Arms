using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventoryController : MonoBehaviour
{
    
    // Name : Quantity
    public Dictionary<string, int> inventory = new Dictionary<string, int>()
    {
        {"Wood", 0},
        {"Clock", 0},
        {"Sword", 0}
    };
    



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
