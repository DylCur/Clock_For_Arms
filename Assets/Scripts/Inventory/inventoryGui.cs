using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class inventoryGUI : MonoBehaviour
{
    [Header("Arrays 😭")]
    public string[] inventoryItems; // Used to see where the items are in the inventory
    public GameObject[] background;
    public TMP_Text[] quantityText;
    public GameObject[] item;
    
    [Header("Sprites")]

    public Sprite invBgSprite;
    public Sprite woodSprite;
    public Sprite clockSprite;

    [Header("Layermasks")]

    public LayerMask hotbarMask;
    public LayerMask invExlusiveMask;

    [Header("Click Parameters")]

    public GameObject[] clickedItems;
    public string[] clickedItemsString;




    pickupItem pickItem;

    // Start is called before the first frame update
    void Start()
    {

        for(int i = 0; i < inventoryItems.Length; i++){
            inventoryItems[i] = "Nothing";
        }

        item = GameObject.FindGameObjectsWithTag("item");
        background = GameObject.FindGameObjectsWithTag("background");
        

      
        for(int i = 0; i < item.Length; i++){
            Image tempImage = item[i].GetComponent<Image>();
            Color invis = new Color(255, 255, 255, 0);
            tempImage.color = invis;
            

        }

       



        pickItem = GetComponent<pickupItem>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
            
        
    }

    public void UpdateGUI(bool shouldUpdateItem, string itemName){

        
        for(int i = 0; i < clickedItems.Length; i++)
        {
            clickedItemsString[i] = clickedItems[i].name;
        }

        bool shouldMakeNewItem = true;

        if(shouldUpdateItem){
            

            // Check to see if its a new item or already in the array - KEY MILESTONE - - KEY MILESTONE - - KEY MILESTONE - - KEY MILESTONE - - KEY MILESTONE - - KEY MILESTONE - 

            for(int i = 0; i < inventoryItems.Length; i++){ // Loops through the inventory and if the item is in the inventory, it will not make a new one.
                if(inventoryItems[i] == itemName){
                    shouldMakeNewItem = false;
                }

            }
          
          
            if(shouldMakeNewItem){ // If it should make a new one, it will loop through the inventory and look for the first available slot, replace that with the item and break out the loop.
                for(int i = 0; i < inventoryItems.Length; i++){
                    if(inventoryItems[i] == "Nothing" && shouldMakeNewItem){
                        inventoryItems[i] = itemName;
                        break;
                    }
                }
            }
           
                
            // END - - KEY MILESTONE - - KEY MILESTONE - - KEY MILESTONE - - KEY MILESTONE - - KEY MILESTONE - - KEY MILESTONE - - KEY MILESTONE - - KEY MILESTONE - - KEY MILESTONE - 
        
            

        


            // Adds value and updates UI - - KEY MILESTONE - - KEY MILESTONE - - KEY MILESTONE - - KEY MILESTONE - - KEY MILESTONE - 
            
            int Value = pickItem.inventory[itemName];

            for(int i = 0; i < inventoryItems.Length; i++)
            {
                if(inventoryItems[i] != "Nothing"){
                    SpriteChanger(itemName, i);
                }

                
            }

            for(int j = 0; j < item.Length; j++){
                Image tempImage = item[j].GetComponent<Image>();
                if(tempImage.sprite == null){    
                    Debug.Log("NULL!");
                    Color invis = new Color(255, 255, 255, 0);
                    tempImage.color = invis;
                }
                else{
                    Color fullOpacity = new Color(255, 255, 255, 255);
                    tempImage.color = fullOpacity;
                    Debug.Log("FOUND SPRITES!");
                }
           
            }

        }

        

        for(int k = 0; k < inventoryItems.Length; k++){
            Debug.Log($"Inventory: {inventoryItems[k]} {k}");
            
        }
        
    }



    public void SpriteChanger(string itemName, int i){


        Image tempImage;
        tempImage = item[i].GetComponent<Image>();
        
        if(inventoryItems[i] == "Wood"){
            tempImage.sprite = woodSprite;
        }

        else if(inventoryItems[i] == "Clock"){ // Find a way to set these to 
            tempImage.sprite = clockSprite;
        }
         

        QuantityChanger(itemName);
        
    }



    public void QuantityChanger(string itemName){

        
        for(int j = 0; j < inventoryItems.Length; j++){
            
            if(inventoryItems[j] != "Nothing"){
                quantityText[j].text = pickItem.inventory[inventoryItems[j]].ToString();
            }
             
        }
        

        
    }
}
