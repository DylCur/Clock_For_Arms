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
                iGUI.SpriteChanger(itemName, i, true);

            }
        }

        for(int i = 0; i < iGUI.background.Length; i++){
            if(iGUI.clickedItems[1] == iGUI.item[i]){ // Sets the new item slot to the OG item
                string tempItemName = iGUI.inventoryItems[i];
                iGUI.inventoryItems[tempI] = tempItemName;
                iGUI.inventoryItems[i] = itemName;
                iGUI.SpriteChanger(tempItemName, tempI, true);
                iGUI.SpriteChanger(itemName, i, true);
                
                i++;

                if(i == 1){
                    iGUI.ItemSelection(iGUI.oneKey);
                }

                else if(i == 2){
                    iGUI.ItemSelection(iGUI.twoKey);
                }

                else if(i == 3){
                    iGUI.ItemSelection(iGUI.threeKey);
                }

                else if(i == 4){
                    iGUI.ItemSelection(iGUI.fourKey);
                }

                else if(i == 5){
                    iGUI.ItemSelection(iGUI.fiveKey);
                }

                else if(i == 6){
                    iGUI.ItemSelection(iGUI.sixKey);
                }

                else if(i == 7){
                    iGUI.ItemSelection(iGUI.sevenKey);
                }

                else if(i == 8){
                    iGUI.ItemSelection(iGUI.eightKey);
                }

                else if(i == 9){
                    iGUI.ItemSelection(iGUI.nineKey);
                }

                Debug.Log("Found second item");
            }
        }
    }

    
}
