using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class signCollision : MonoBehaviour
{

    public string signTag = "Sign";

    public TMP_Text signText;

    signContents sContent;

    void Start(){
        GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
        
        foreach (GameObject obj in allObjects)
        {
            if (obj.name.ToLower().Contains("sign"))
            {
                obj.tag = "Sign";
            }
        }
    }

    void OnTriggerEnter(Collider other) {
        Debug.Log("Collision");
        if(other.gameObject.tag == "Sign"){
            sContent = other.GetComponent<signContents>();
            if(sContent != null){
                signText.text = sContent.contents;
                Debug.Log("Sign");
            }
            
        }
    }

    void OnTriggerExit(Collider other){
        signText.text = "";
    }
}
