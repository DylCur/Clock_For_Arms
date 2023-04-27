using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class getItem : MonoBehaviour
{

    public string[] possibleItemTags = {"Wood", "Apple", "Sword", "Clock"};
    public KeyCode getKey = KeyCode.E;
    int value;
    public int itemMultiplier = 1;
    bool collidingWithItem;
    string itemName;
    GameObject otherItem;

    inventoryController invControl;

    // Start is called before the first frame update
    void Start()
    {
        invControl = GetComponent<inventoryController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(getKey) && collidingWithItem)
        {
            CanGetItem(itemName, otherItem);
        }
    }

    public void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Colldied With other trigger");
        
            Debug.Log("Pressed");
            if(Enumerable.Contains(possibleItemTags, other.tag)){
                collidingWithItem = true;
                itemName = other.tag;
                otherItem = other.gameObject;
                
                Debug.Log("Can Get item");
            }
        
    }

    public void CanGetItem(string itemName, GameObject otherItem){

            collidingWithItem = false;
        
            Debug.Log("Get!");

            if(invControl.inventory.TryGetValue(itemName, out value)){
                invControl.inventory[itemName] += itemMultiplier;
                
                foreach(KeyValuePair<string, int> i in invControl.inventory){
                    Debug.Log($"Key : {i.Key}, Value : {i.Value}");
                }

                ItemDestruction(otherItem);
            }

            else{
                invControl.inventory.Add(itemName, itemMultiplier);
                
                foreach(KeyValuePair<string, int> i in invControl.inventory){
                    Debug.Log($"Key : {i.Key}, Value : {i.Value}");
                }
                
                ItemDestruction(otherItem);
            }


        
    }

    public void ItemDestruction(GameObject itemToDestroy){
        itemToDestroy.SetActive(false);
        
    }
}
