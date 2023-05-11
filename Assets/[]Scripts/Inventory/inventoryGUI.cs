using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
using System.Linq;


public class inventoryGUI : MonoBehaviour
{




    
    [Header("Arrays")]
    [Space(5)]

    public string[] inventoryItems; // Used to see where the items are in the inventory
    public GameObject[] background;
    public TMP_Text[] quantityText;
    public GameObject[] item;
    public GameObject[] hotbar;
    public GameObject[] invExlusive;
    

    [Space(50)]
    [Header("Sprites")]
    [Space(5)]

    public Sprite invBgSprite;
    public Sprite woodSprite;
    public Sprite clockSprite;
    public Sprite swordSprite;
    public Sprite axeSprite;


    public Sprite disabledBG;
    public Sprite enabledBG;

    [Space(50)]
    [Header("Layermasks")]
    [Space(5)]

    public LayerMask hotbarMask;
    public LayerMask invExlusiveMask;

    [Space(50)]
    [Header("Click Parameters")]
    [Space(5)]

    public GameObject[] clickedItems;
    public string[] clickedItemsString;

    [Space(50)]
    [Header("Keycodes")]
    [Space(5)]

    public KeyCode hotbarKey = KeyCode.Tab;

    public KeyCode oneKey = KeyCode.Alpha1;
    public KeyCode twoKey = KeyCode.Alpha2;
    public KeyCode threeKey = KeyCode.Alpha3;
    public KeyCode fourKey = KeyCode.Alpha4;
    public KeyCode fiveKey = KeyCode.Alpha5;
    public KeyCode sixKey = KeyCode.Alpha6;
    public KeyCode sevenKey = KeyCode.Alpha7;
    public KeyCode eightKey = KeyCode.Alpha8;
    public KeyCode nineKey = KeyCode.Alpha9;

    [Space(50)]
    [Header("Item Selection Parameters")]
    [Space(5)]

    public string currentlySelectedItem;






    bool isHotbar;




    pickupItem pickItem;

    // Start is called before the first frame update
    void Start()
    {

        hotbar = FindObjectsOfType<GameObject>().Where(go => (hotbarMask.value & 1 << go.layer) != 0).ToArray();
        invExlusive = FindObjectsOfType<GameObject>().Where(go => (invExlusiveMask.value & 1 << go.layer) != 0).ToArray();


        for(int i = 0; i < inventoryItems.Length; i++){
            inventoryItems[i] = "Nothing";
        }

        // item = GameObject.FindGameObjectsWithTag("item");
        // background = GameObject.FindGameObjectsWithTag("background");
        

      
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
        
        
            if(Input.GetKeyDown(KeyCode.U)){
                for(int i = 0; i < inventoryItems.Length; i++){
                    Debug.Log($"Inventory: {inventoryItems[i]} {i}");
                }
            }

            if(Input.GetKeyDown(hotbarKey)){
                HotbarChanger();
            }



            if(Input.GetKeyDown(oneKey)){
                ItemSelection(oneKey);
            }

            else if(Input.GetKeyDown(twoKey)){
                ItemSelection(twoKey);
            }

            else if(Input.GetKeyDown(threeKey)){
                ItemSelection(threeKey);
            }

            else if(Input.GetKeyDown(fourKey)){
                ItemSelection(fourKey);
            }

            else if(Input.GetKeyDown(fiveKey)){
                ItemSelection(fiveKey);
            }

            else if(Input.GetKeyDown(sixKey)){
                ItemSelection(sixKey);
            }
            
            else if(Input.GetKeyDown(sevenKey)){
                ItemSelection(sevenKey);
            }

            else if(Input.GetKeyDown(eightKey)){
                ItemSelection(eightKey);
            }

            else if(Input.GetKeyDown(nineKey)){
                ItemSelection(nineKey);
            }

            
        
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
            if(itemName != "Nothing"){
                int Value = pickItem.inventory[itemName];
            }

            for(int i = 0; i < inventoryItems.Length; i++)
            {
                if(inventoryItems[i] != "Nothing"){
                    SpriteChanger(itemName, i, true);
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



    public void SpriteChanger(string itemName, int i, bool shouldChangeQuantity){

        if(shouldChangeQuantity){
            Image tempImage;
            tempImage = item[i].GetComponent<Image>();
            
            if(inventoryItems[i] == "Wood"){
                Color visable = new Color(255, 255, 255, 255);
                tempImage.sprite = woodSprite;
                tempImage.color = visable;
            }

            else if(inventoryItems[i] == "Clock"){ 
                Color visable = new Color(255, 255, 255, 255);
                tempImage.sprite = clockSprite;
                tempImage.color = visable;

            }

            else if(inventoryItems[i] == "Sword"){ 
                Color visable = new Color(255, 255, 255, 255);
                tempImage.sprite = swordSprite;
                tempImage.color = visable; // For new item add here

            }

            else if(inventoryItems[i] == "Axe"){ 
                Color visable = new Color(255, 255, 255, 255);
                tempImage.sprite = axeSprite;
                tempImage.color = visable; // For new item add here

            }

            else if(inventoryItems[i] == "Nothing"){
                tempImage.sprite = null;
                Color invis = new Color(255, 255, 255, 0);
                tempImage.color = invis;
            }
         

            QuantityChanger(itemName);
        }

      
        
        
        
    }



    public void QuantityChanger(string itemName){

        int j = 0;

        foreach(string str in inventoryItems){ // Looks through the whole inventory
            
            if(str != "Nothing"){
                quantityText[j].text = pickItem.inventory[inventoryItems[j]].ToString();
            }

            else{
                quantityText[j].text = "";
            }
            
            j++;
        }
        

        
    }

    public void HotbarChanger(){ // Take a guess at what this does

        if(!isHotbar){
            foreach(GameObject obj in hotbar){
                obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y - 358, obj.transform.position.z);
            }

            foreach(GameObject obj in invExlusive){
                obj.SetActive(false);
            }

            isHotbar = true;
        }

        else if(isHotbar){ // I even added this incase its too difficult
            foreach(GameObject obj in hotbar){
                obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y + 358, obj.transform.position.z);
            }

            foreach(GameObject obj in invExlusive){
                obj.SetActive(true);
            }

            isHotbar = false;
        }
        

    }




    public void ItemSelection(KeyCode keyPressed){

        

        
        if(keyPressed == oneKey){
            currentlySelectedItem = inventoryItems[0];
            Image tempObj = background[0].GetComponent<Image>();
            ItemSelectionRenderer(tempObj);           
        }

        else if(keyPressed == twoKey){
            currentlySelectedItem = inventoryItems[1];
            Image tempObj = background[1].GetComponent<Image>();
            ItemSelectionRenderer(tempObj);           
        }

        else if(keyPressed == threeKey){
            currentlySelectedItem = inventoryItems[2];
            Image tempObj = background[2].GetComponent<Image>();
            ItemSelectionRenderer(tempObj);           
        }

        else if(keyPressed == fiveKey){
            currentlySelectedItem = inventoryItems[3];
            Image tempObj = background[3].GetComponent<Image>();
            ItemSelectionRenderer(tempObj);           
        }

        else if(keyPressed == fourKey){
            currentlySelectedItem = inventoryItems[4];
            Image tempObj = background[4].GetComponent<Image>();
            ItemSelectionRenderer(tempObj);           
        }

        else if(keyPressed == sixKey){
            currentlySelectedItem = inventoryItems[5];
            Image tempObj = background[5].GetComponent<Image>();
            ItemSelectionRenderer(tempObj);           
        }

        else if(keyPressed == sevenKey){
            currentlySelectedItem = inventoryItems[6];
            Image tempObj = background[6].GetComponent<Image>();
            ItemSelectionRenderer(tempObj);           
        }

        else if(keyPressed == eightKey){
            currentlySelectedItem = inventoryItems[7];
            Image tempObj = background[7].GetComponent<Image>();
            ItemSelectionRenderer(tempObj);           
        }

        else if(keyPressed == nineKey){
            currentlySelectedItem = inventoryItems[8];
            Image tempObj = background[8].GetComponent<Image>();
            ItemSelectionRenderer(tempObj);           
        }
    }


    public void ItemSelectionRenderer(Image tempObj){
        
        
        for(int i = 0; i < background.Length; i++){
            Image tempObj2 = background[i].GetComponent<Image>();
            tempObj2.sprite = disabledBG;
            tempObj.sprite = enabledBG;

            
        }
        
        

    }
}
