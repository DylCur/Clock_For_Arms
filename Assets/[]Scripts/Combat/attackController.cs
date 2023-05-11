using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackType{
    Sword,
    Bow,
    Axe,
    Pickaxe
}
 


public class attackController : MonoBehaviour
{
    playerController playerControl;


    [Header("Enums")]
    [Space(30)] // Put all enums between the [Space(30)]'s

    public AttackType attackType;

    
    [Space(30)] // Put all enums between the [Space(30)]'s
 


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
    public float swordTimeBetweenAttack = 0.2f;

    [Header("Bow Parameters")]

    public int bowAttackDamage = 1000;
    public float bowTimeBetweenAttack = 0.5f;

    [Header("Axe Parameters")]

    public int axeAttackDamage = 10;
    public float axeTimeBetweenAttack = 0.5f;

    [Header("Pickaxe Parameters")]

    public int pickaxeAttackDamage = 10;
    public float pickaxeTimeBetweenAttack = 0.5f;

    [Header("Current Attacking Parameters")]
    
    public float timeBetweenAttack;
    public int attackDamage;





    
    
    
 

    



    // Start is called before the first frame update
    void Start()
    {

        
        playerControl = GetComponent<playerController>();
        shouldAttack = canAttack && Input.GetKeyDown(attackKey);
    }

    // Update is called once per frame
    void Update()
    {
        if(attackType == AttackType.Sword){
            attackDamage = swordAttackDamage;
            timeBetweenAttack = swordTimeBetweenAttack;
        }

        else if(attackType == AttackType.Bow){
            attackDamage = bowAttackDamage;
            timeBetweenAttack = bowTimeBetweenAttack;
        }

        else if(attackType == AttackType.Axe){
            attackDamage = axeAttackDamage;
            timeBetweenAttack = axeTimeBetweenAttack;
        }

        else if(attackType == AttackType.Pickaxe){
            attackDamage = pickaxeAttackDamage;
            timeBetweenAttack = pickaxeTimeBetweenAttack;
        }



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
