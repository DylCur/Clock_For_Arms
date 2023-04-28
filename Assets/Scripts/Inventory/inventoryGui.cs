using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventoryGUI : MonoBehaviour
{
    [Header("Arrays 😭")]
    public string[] inventoryItems; // Used to see where the items are in the inventory
    public GameObject[] background;
    public GameObject[] quantityText;
    public GameObject[] item;




    pickupItem pickItem;

    // Start is called before the first frame update
    void Start()
    {

        for(int i = 0; i < inventoryItems.Length; i++){
            inventoryItems[i] = "Nothing";
        }

        item = GameObject.FindGameObjectsWithTag("item");
        background = GameObject.FindGameObjectsWithTag("background");
        quantityText = GameObject.FindGameObjectsWithTag("quantityText");




        pickItem = GetComponent<pickupItem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateGUI(bool shouldUpdateItem, string itemName){
        if(shouldUpdateItem){
            for(int i = 0; i < inventoryItems.Length; i++){
                if(inventoryItems[i] == "Nothing"){
                    inventoryItems[i] = itemName;
                }
        }
        }
        
    }
}
