using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class inventoryGui : MonoBehaviour
{
    // Total 27
    public GameObject[] inventorySlotsBG;
    public GameObject[] inventorySlotsItem;
    public SpriteRenderer[] invSlotItemRenderers;
    public TMP_Text[] quantityText;

    public GameObject woodSprite;

    // Total 9 (27 / 3)
    public GameObject[] hotbarSlots;


    

    public int itemQuantity;

    inventoryController invControl;
    getItem gItem;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < invSlotItemRenderers.Length; i++){
            invSlotItemRenderers[i] = inventorySlotsItem[i].GetComponent<SpriteRenderer>();
        }
        invControl = GetComponent<inventoryController>();
        gItem = GetComponent<getItem>();
    }

    // Update is called once per frame
    void Update()
    {
        InventoryUpdate();
    }

    public void InventoryUpdate(){
        for(int i = 0; i < inventorySlotsBG.Length; i++){
            string key = invControl.inventory.FirstOrDefault(x => x.Value == i).Key;
            
            if(key != null){// If finds a key set the quantity equal to the dictionarys quantity
                itemQuantity = invControl.inventory[key];
                
                if(quantityText[i] != null){
                    quantityText[i].text = itemQuantity.ToString(); 
                }

                if(inventorySlotsItem[i] != null){
                    if(gItem.itemName == "Wood"){
                        inventorySlotsItem[i] = woodSprite;
                    }
                }
                    
                    
                
                
            }
        }
    }
}
