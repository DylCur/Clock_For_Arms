using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyProperties : MonoBehaviour
{
    attackController attackControl;
    public GameObject attackControlHolder;


    public int health;
    public int contactDamage;


    void Start(){
        attackControl = attackControlHolder.GetComponent<attackController>();
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "AttackBox"){
            TakeDamage(attackControl.attackDamage);
        }
    }





    public void TakeDamage(int attackDamage){
        
        if(!attackControl.canAttack){
            health -= attackDamage;
            Debug.Log("Enemy took damage");
            Debug.Log(health);
        }

        if(health <= 0){
            Die();
        }
    }

    void Die(){
        Destroy(gameObject);
    }
}
