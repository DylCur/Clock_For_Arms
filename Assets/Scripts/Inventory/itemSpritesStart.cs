using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemSpritesStart : MonoBehaviour
{

    public GameObject[] woodObjects;
    public GameObject[] clockObjects;
    public GameObject[] swordObjects;

    inventoryGUI iGUI;

    // Start is called before the first frame update
    void Start()
    {
        iGUI = GetComponent<inventoryGUI>();
        woodObjects = GameObject.FindGameObjectsWithTag("Wood");
        clockObjects = GameObject.FindGameObjectsWithTag("Clock");
        swordObjects = GameObject.FindGameObjectsWithTag("Sword");


        foreach(GameObject obj in woodObjects){
            SpriteRenderer spriteRenderer = obj.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = iGUI.woodSprite;
        }

        foreach(GameObject obj in clockObjects){
            SpriteRenderer spriteRenderer = obj.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = iGUI.clockSprite;
        }

        foreach(GameObject obj in swordObjects){
            SpriteRenderer spriteRenderer = obj.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = iGUI.swordSprite;
        }

    }


    
}
