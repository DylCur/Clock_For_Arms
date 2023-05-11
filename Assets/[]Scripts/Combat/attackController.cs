using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum attackType{
    Sword,
    Bow,
    Axe,
    Pickaxe
}
 


public class attackController : MonoBehaviour
{

    playerController playerControl;

    [Header("Bools")]
    public bool canAttack;
    public bool shouldAttack;

    [Header("Keycodes")]

    public KeyCode attackKey = KeyCode.C;
    public KeyCode lastKeyPressed;

    [Header("Arrays")]

    public GameObject[] attackPoints;   


    [Header("Sword Parameters")]

    public int swordAttackDamage = 1;
    public float timeBetweenAttack = 0.2f;


    
    
    
 

    



    // Start is called before the first frame update
    void Start()
    {
        playerControl = GetComponent<playerController>();
        shouldAttack = canAttack && Input.GetKeyDown(attackKey);
    }

    // Update is called once per frame
    void Update()
    {
        shouldAttack = canAttack && Input.GetKeyDown(attackKey);

        if(Input.GetKey(KeyCode.W)){
            lastKeyPressed = KeyCode.W;
        }

        if(Input.GetKey(KeyCode.A)){
            lastKeyPressed = KeyCode.A;
        }

        if(Input.GetKey(KeyCode.S)){
            lastKeyPressed = KeyCode.S;
        }

        if(Input.GetKey(KeyCode.D)){
            lastKeyPressed = KeyCode.D;
        }
        

        if(shouldAttack){

           
            

            
           if(lastKeyPressed == KeyCode.W){
                AttackAnimation("UP");
            }

           else if(lastKeyPressed == KeyCode.A){
                AttackAnimation("LEFT");
            }

            else if(lastKeyPressed == KeyCode.S){
                AttackAnimation("DOWN");
            }

            else if(lastKeyPressed == KeyCode.D){
                AttackAnimation("RIGHT");
            }

            
            else{
                
                lastKeyPressed = KeyCode.D;
                AttackAnimation("RIGHT");
            }
            
        }

        
    }

    public void AttackAnimation(string direction)
    {
        if(direction == "UP"){
            playerControl.anim.SetBool("Up", true);
            playerControl.anim.SetBool("Down", false);
            playerControl.anim.SetBool("Left", false);
            playerControl.anim.SetBool("Right", false);
            StartCoroutine(attackCooldown());
        }

        else if(direction == "DOWN"){
            playerControl.anim.SetBool("Up", false);
            playerControl.anim.SetBool("Down", true);
            playerControl.anim.SetBool("Left", false);
            playerControl.anim.SetBool("Right", false);
            StartCoroutine(attackCooldown());
        }

        else if(direction == "LEFT"){
            playerControl.anim.SetBool("Up", false);
            playerControl.anim.SetBool("Down", false);
            playerControl.anim.SetBool("Left", true);
            playerControl.anim.SetBool("Right", false);
            StartCoroutine(attackCooldown());

        }

        else if(direction == "RIGHT"){
            playerControl.anim.SetBool("Up", false);
            playerControl.anim.SetBool("Down", false);
            playerControl.anim.SetBool("Left", false);
            playerControl.anim.SetBool("Right", true);
            StartCoroutine(attackCooldown());

        }




    }


    public IEnumerator attackCooldown(){
        canAttack = false;
        playerControl.canMove = false;
        yield return new WaitForSeconds(timeBetweenAttack);
        playerControl.anim.SetBool("Up", false);
        playerControl.anim.SetBool("Down", false);
        playerControl.anim.SetBool("Left", false);
        playerControl.anim.SetBool("Right", false);
        playerControl.canMove = true;
        canAttack = true;
    }



    public void Attack(){

    }


}
