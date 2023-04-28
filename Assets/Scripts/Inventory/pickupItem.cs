using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class pickupItem : MonoBehaviour
{
    // Item : Quantity
    public Dictionary<string, int> inventory = new Dictionary<string, int>(){
        {"Wood", 0},
        {"Clock", 0}

    };


    public string[] possibleItemTags = {"Wood", "Stone", "Clock"};

    [Header("Keycodes")]

    public KeyCode getKey = KeyCode.F;

    [Header("Bools")]

    bool canGetItem;
    
    [Header("Item properties")]

    public int itemMultiplier;


    string otherTag;
    GameObject itemPickedUp;

    inventoryGUI invGUI;

    // Start is called before the first frame update
    void Start()
    {
        invGUI = GetComponent<inventoryGUI>();
    }

    void Update() {
        if(Input.GetKeyDown(getKey) && canGetItem){
            GetItem(otherTag, itemPickedUp);
        }    
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(Array.Exists(possibleItemTags, element => element == other.tag)){ // If the tag of the other object
            Debug.Log("Is real");
            canGetItem = true;
            otherTag = other.tag;
            itemPickedUp = other.gameObject;
        }    
    }

    public void OnTriggerExit2D(Collider2D other) {
        if(Array.Exists(possibleItemTags, element => element == other.tag)){ // If the tag of the other object
            canGetItem = false;
            otherTag = "";
            itemPickedUp = null;
        }
    }

    public void GetItem(string otherTag, GameObject itemPickedUp){
        
        inventory[otherTag] += itemMultiplier;
        Debug.Log($"Item = {otherTag} : Quantity {inventory[otherTag]}");
        itemPickedUp.SetActive(false);
        invGUI.UpdateGUI(true, otherTag);
        
    }

    
}
