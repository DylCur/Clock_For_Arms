using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class clickDetection : MonoBehaviour, IPointerDownHandler
{

    // Use clickedItemString for gameobjects name

    inventoryGUI iGUI;
    public GameObject invGUIHolder;
    public string itemName;

    void Start()
    {

        iGUI = invGUIHolder.GetComponent<inventoryGUI>();

    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Clicked");

        
        // Checks to see what items are clicked on - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 

        if(iGUI.clickedItems[0] == null && iGUI.clickedItems[1] == null){
            iGUI.clickedItems[0] = gameObject;
        }

        else if(iGUI.clickedItems[0] != null && iGUI.clickedItems[1] == null){
            iGUI.clickedItems[1] = gameObject;
        }

        else{
            for(int i = 0; i < iGUI.clickedItems.Length; i++){
                iGUI.clickedItems[i] = null;
                
            }

            iGUI.clickedItems[0] = gameObject;
        }

        // End - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 


        // Updates the inventory array - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
        int tempI = 0;

        for(int i = 0; i < iGUI.background.Length; i++){ // Sets the OG item to nothing (NEEDS TO BE SET TO WHATEVER IS IN THAT SLOT)
            if(iGUI.clickedItems[0] == iGUI.item[i]){
                itemName = iGUI.inventoryItems[i];
                tempI = i;
                // iGUI.inventoryItems[i] = "Nothing";
                Debug.Log("Found 1st item");
                iGUI.SpriteChanger(itemName, i);

            }
        }

        for(int i = 0; i < iGUI.background.Length; i++){
            if(iGUI.clickedItems[1] == iGUI.item[i]){ // Sets the new item slot to the OG item
                string tempItemName = iGUI.inventoryItems[i];
                iGUI.inventoryItems[tempI] = tempItemName;
                iGUI.inventoryItems[i] = itemName;
                iGUI.SpriteChanger(tempItemName, tempI);
                iGUI.SpriteChanger(itemName, i);

                Debug.Log("Found second item");
            }
        }
    }

    
}
