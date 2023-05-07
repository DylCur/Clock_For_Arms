using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyProperties : MonoBehaviour
{

    public int health;
    public int contactDamage;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void TakeDamage(int attackDamage){
        
        health -= attackDamage;

        if(health <= 0){
            Die();
        }
    }

    void Die(){
        Destroy(gameObject);
    }
}
