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

        if(iGUI.clickedItemsString[0] == "Nothing" && iGUI.clickedItemsString[1] == "Nothing"){
            iGUI.clickedItems[0] = gameObject;
        }

        else if(iGUI.clickedItemsString[0] != "Nothing" && iGUI.clickedItemsString[1] == "Nothing"){
            iGUI.clickedItems[1] = gameObject;
        }

        for(int i = 0; i < iGUI.background.Length; i++){
            if(iGUI.clickedItems[0] == iGUI.background[i]){
                itemName = iGUI.inventoryItems[i];
                iGUI.inventoryItems[i] = "Nothing";
            }
            
            else if(iGUI.clickedItems[1] == iGUI.background[i]){
                iGUI.inventoryItems[i] = itemName;
                iGUI.UpdateGUI(true, itemName);
            }
        }
    }

    void OnMouseDown()
    {
        
    }
}
