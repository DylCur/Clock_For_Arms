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



        for(int i = 0; i < inventorySlotsBG.Length; i++)
        {
            if(gItem.itemName != null){
                if(gItem.itemName == "Wood"){
                    itemInInventory[0] = true; 
                    woodSlot = i;
                }
            }
            
           



        }


        if(gItem.itemName == "Wood"){ // If youre getting wood
            if(itemInInventory[0] == false){ // If its in the inventory
                Color fullOpacity = new Color(255, 255, 255, 255);
                invSlotItemRenderers[0].sprite = woodSprite;
                invSlotItemRenderers[0].color = fullOpacity;
                woodSlot = 0;
            }

            else{
                quantityText[woodSlot].text = (invControl.inventory["Wood"]).ToString();
            }
                        
        }
        for(int i = 0; i < inventorySlotsBG.Length; i++){
            key = invControl.inventory.FirstOrDefault(x => x.Value == i).Key;
            
            if(key != null){// If finds a key set the quantity equal to the dictionarys quantity
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
