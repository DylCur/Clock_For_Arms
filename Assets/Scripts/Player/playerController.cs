using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [Header("Movement Parameters")]
    public float playerMoveSpeed = 12f;


    // Public but hidden

    [HideInInspector] public float horizontalInput;
    [HideInInspector] public float verticalInput;

    [Header("Cans")]
    public bool canRotate = false; 
    public bool canMove = true;

    Rigidbody2D rb;
    Animator anim;
    





    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        if(!canMove){
            Debug.Log("Can move is false");
        }

        if(!canRotate){
            Debug.Log("Can rotate is false");
        }
    }

    
    void FixedUpdate()
    {
        if(canMove){
            Movement(playerMoveSpeed, horizontalInput = Input.GetAxisRaw("Horizontal"), verticalInput = Input.GetAxisRaw("Vertical")); // Inputs the speed and the inputs 😲
        }

        if(canRotate){
            RotatePlayer(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }

        animationCheck();
    }

    public void Movement(float playerMoveSpeed, float horizontalInput, float verticalInput){

        

        Vector2 movementVector = new Vector2(horizontalInput * playerMoveSpeed, verticalInput * playerMoveSpeed);

        rb.velocity = movementVector;

    }

    public void RotatePlayer(Vector3 mousePosition){
        
        float angle = Mathf.Atan2(mousePosition.y - transform.position.y, mousePosition.x - transform.position.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    public void animationCheck(){
        if(horizontalInput != 0 || verticalInput != 0){
            anim.SetBool("isRunning", true);
            anim.SetBool("isIdle", false);
            
        }
        if(horizontalInput == 0 && verticalInput == 0){
            anim.SetBool("isRunning", false);
            anim.SetBool("isIdle", true);
        }
    }
}
