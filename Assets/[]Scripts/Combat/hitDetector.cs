using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;





public class hitDetector : MonoBehaviour
{

    attackController attackControl;
    public bool hasHit;
    public GameObject objectThatHasHit;
    
    //public GameObject attackControlHolder;
    



    // Start is called before the first frame update
    void Start()
    {
        //attackControl = attackControlHolder.GetComponent<attackController>();

        

        objectThatHasHit = gameObject;

        foreach(possibleEnemyTags value in Enum.GetValues(typeof(possibleEnemyTags))){
            Debug.Log(value);
        }
    }


    public void OnTriggerEnter2D(Collider2D other) {
        foreach(possibleEnemyTags value in Enum.GetValues(typeof(possibleEnemyTags))){
            if(other.tag == value.ToString() && !hasHit){

                
     
                enemyProperties enemProp = other.GetComponent<enemyProperties>();
                if(enemProp != null){
                    
                    //enemProp.TakeDamage(attackControl.swordAttackDamage);
                    Debug.Log($"Not Null {other.gameObject}");
                }

                else{
                    Debug.Log($"Null {other.gameObject}");

                }


                hasHit = true;
                StartCoroutine(WaitAttack());
            }
        }
    }

    public IEnumerator WaitAttack(){
        yield return new WaitForSeconds(attackControl.timeBetweenAttack * 1.1f);
        hasHit = false;
    }
}
