using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heldItemGUI : MonoBehaviour
{


    inventoryGUI iGUI;
    playerController playerControl;
    SpriteRenderer itemSprite;
    public GameObject player;

    public Color invis = new Color(255, 255, 255, 0);
    public Color visable = new Color(255, 255, 255, 255);

    // Start is called before the first frame update
    void Start()
    {
        playerControl = player.GetComponent<playerController>();
        iGUI = player.GetComponent<inventoryGUI>();

        itemSprite = GetComponent<SpriteRenderer>();
        
        iGUI.currentlySelectedItem = "Nothing";


    }

    // Update is called once per frame
    void Update()
    {

        // Vector3 characterDirection = transform.localScale;

        // if(playerControl.horizontalInput > 0){
        //     characterDirection.x = -1;
        // }

        // else if(playerControl.horizontalInput < 0){
        //     characterDirection.x = 1;
        // }

        // transform.localScale = characterDirection;

        if(iGUI.currentlySelectedItem != "Nothing" && iGUI.currentlySelectedItem != null){
            itemSprite.color = visable;
        }

        if(iGUI.currentlySelectedItem == "Nothing"){
            itemSprite.color = invis;
        }



        if(iGUI.currentlySelectedItem == "Wood"){
            itemSprite.sprite = iGUI.woodSprite;
        }

        

        if(iGUI.currentlySelectedItem == "Sword"){
            itemSprite.sprite = iGUI.swordSprite;
        }

        if(iGUI.currentlySelectedItem == "Clock"){
            itemSprite.sprite = iGUI.clockSprite;
        }

        if(iGUI.currentlySelectedItem == "Axe"){
            itemSprite.sprite = iGUI.axeSprite;
        }
    }
}
