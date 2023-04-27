using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using UnityEngine.UI;

public class inventoryGui : MonoBehaviour
{
    // Total 27
    public GameObject[] inventorySlotsBG;
    public GameObject[] inventorySlotsItem;
    public Image[] invSlotItemRenderers;
    public TMP_Text[] quantityText;
    public bool[] itemInInventory = {false};

    public Sprite woodSprite;
    public Sprite clockSprite;
    public Sprite swordSprite;
    

    // Total 9 (27 / 3)

    [Header("Hotbar Parameters")]
    public GameObject[] hotbarSlots;
    public GameObject[] invExlusive;
    public bool isHotbar;
    public Vector2 currentItemPosition;
    public Vector2[] startingPosition;
    public GameObject hotbarHolders;
    



    [Header("Keycodes")]

    public KeyCode inventoryKey = KeyCode.Tab;
    int woodSlot;
    int clockSlot;
    int swordSlot;


    

    public int itemQuantity;
    string key;

    inventoryController invControl;
    getItem gItem;

    // Start is called before the first frame update
    void Start()
    {
        gItem = GetComponent<getItem>();
        invControl = GetComponent<inventoryController>();
        invExlusive = GameObject.FindGameObjectsWithTag("InvExclusive");
        hotbarSlots = GameObject.FindGameObjectsWithTag("Hotbar");

        startingPosition = new Vector2[hotbarSlots.Length - 1]; 

        for (int i = 0; i < hotbarSlots.Length; i++)
        {
            startingPosition[i] = hotbarSlots[i].transform.position;
        }
    
        for(int i = 0; i < invSlotItemRenderers.Length; i++){
            invSlotItemRenderers[i] = inventorySlotsItem[i].GetComponent<Image>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        InventoryUpdate();

        if(Input.GetKeyDown(inventoryKey)){
            HotbarChange();
        }
    }

    public void InventoryUpdate(){


            // Item name is the name of the item you have gotten

        for(int i = 0; i < inventorySlotsBG.Length; i++)
        {
            if(gItem.itemName != null){
                if(gItem.itemName == "Wood"){
                    if(!itemInInventory[0]){
                        woodSlot = i;
                    }
                    itemInInventory[0] = true; 
                    
                }
                
                else if(gItem.itemName == "Clock"){
                    Debug.Log("Item is clock");
                    if(!itemInInventory[1]){
                        Debug.Log("Clock not in inv");

                        if(i != woodSlot && i != swordSlot){
                            clockSlot = i;
                            Debug.Log("Clock Slot");
                        }

                        else{
                            clockSlot = woodSlot + 1;
                        }

                        gItem.itemName = "";
                    }

                    itemInInventory[1] = true; 
                    
                }

                else if(gItem.itemName == "Sword"){
                    Debug.Log("Item is Sword");
                    if(!itemInInventory[2]){
                        Debug.Log("Sword not in inv");

                        if(i != woodSlot && i != clockSlot){
                            swordSlot = i;
                            Debug.Log("Clock Slot");
                        }

                        else{
                            for(int j = 0; j < inventorySlotsBG.Length; j++){
                                if(j!= woodSlot && j!= clockSlot){
                                    swordSlot = j;
                                    break;
                                }
                            }
                        }

                        gItem.itemName = "";
                    }

                    itemInInventory[1] = true; 
                    
                }
            }
            
           
           if(itemInInventory[0]){
                Color invisible = new Color(255, 255, 255, 255);
                quantityText[woodSlot].text = invControl.inventory["Wood"].ToString();
                invSlotItemRenderers[woodSlot].sprite = woodSprite;
                invSlotItemRenderers[woodSlot].color = invisible;
                
           }

           if(itemInInventory[1]){
                Color invisible = new Color(255, 255, 255, 255);
                quantityText[clockSlot].text = invControl.inventory["Clock"].ToString();
                invSlotItemRenderers[clockSlot].sprite = clockSprite;
                invSlotItemRenderers[clockSlot].color = invisible;
                
           }


        }


        
                        
        
        for(int i = 0; i < inventorySlotsBG.Length; i++){
            key = invControl.inventory.FirstOrDefault(x => x.Value == i).Key;
            
            if(key != null && invControl.inventory[key] != 0){// If finds a key set the quantity equal to the dictionarys quantity
                itemQuantity = invControl.inventory[key];
                
                // if(quantityText[i] != null){
                //     quantityText[i].text = itemQuantity.ToString(); 
                // }
                // else{

                // }

                if(inventorySlotsItem[i] != null){
                    
                }

                    
                
                
            }
        }
    }

    public void HotbarChange(){
        if(!isHotbar){
            foreach (GameObject obj in invExlusive)
            {
                obj.SetActive(false);
                
            }

            for(int i = 0; i < hotbarSlots.Length; i++){
                Vector2 newPosition = new Vector2(startingPosition[i].x, 100);
                hotbarSlots[i].transform.position = newPosition;
                isHotbar = true;    

                
            }

            
            
        }
        
        else{
            
            foreach (GameObject obj in invExlusive)
            {
                obj.SetActive(true);
                
            }
            
            for(int i = 0; i < hotbarSlots.Length; i++){
                hotbarSlots[i].transform.position = new Vector2(startingPosition[i].x, startingPosition[i].y);
                isHotbar = false;
                
            }

            
        }

    }


}
