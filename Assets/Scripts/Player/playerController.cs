using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [Header("Movement Parameters")]
    public float speed;
    public float maxSpeed = 12f;
    public float acceleration = 1f;
    public float timeBetweenSpeed = 0.2f;
    [HideInInspector] public float ogTimeBetweenSpeed;
    bool canDecrease = true;
    bool canIncrease = true;







    // public float playerMoveSpeed = 12f;


    // Public but hidden

    [HideInInspector] public float horizontalInput;
    [HideInInspector] public float verticalInput;

    [Header("Cans")]
    public bool canMove = true;

    Rigidbody2D rb;
    [HideInInspector] public Animator anim;
    





    
    void Start()
    {

        ogTimeBetweenSpeed = timeBetweenSpeed;

        Debug.Log(transform.localScale);

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        if(!canMove){
            Debug.Log("Can move is false");
        }

      
    }

    
    void FixedUpdate()
    {
        if(canMove){

            horizontalInput = Input.GetAxisRaw("Horizontal");
            verticalInput = Input.GetAxisRaw("Vertical");
            
            Vector3 characterDirection = transform.localScale;

            if(horizontalInput > 0){
                characterDirection.x = -2;
            }

            else if(horizontalInput < 0){
                characterDirection.x = 2;
            }

            transform.localScale = characterDirection;

            Movement();

            

        }
        
        if(canMove){
            //Movement(playerMoveSpeed, horizontalInput = Input.GetAxisRaw("Horizontal"), verticalInput = Input.GetAxisRaw("Vertical")); // Inputs the speed and the inputs
        }

        else{
            rb.velocity = Vector2.zero;
        }

        
        animationCheck();
    }


    public void Movement(){

        if(speed < 0){
            speed = 0;
        }

        if(speed > maxSpeed){
            speed = maxSpeed;
        }

        if(speed == maxSpeed || speed == 0){
            timeBetweenSpeed = ogTimeBetweenSpeed;
        }

        if(horizontalInput != 0 || verticalInput != 0){
            if(speed != maxSpeed && canIncrease){
                StartCoroutine(IncreaseSpeed());
            }
        }

        if(horizontalInput == 0 && verticalInput == 0){
            if(speed != 0 && canDecrease){
                StartCoroutine(DecreaseSpeed());
            }
        }

        rb.velocity = new Vector2(horizontalInput * speed, verticalInput * speed);
    }

    public IEnumerator IncreaseSpeed(){
        
        canIncrease = false;

        speed += acceleration;

        if(speed > maxSpeed){
            speed = maxSpeed;
        }

        yield return new WaitForSeconds(timeBetweenSpeed);

        timeBetweenSpeed *= 0.7f;

        canIncrease = true;
    }

    public IEnumerator DecreaseSpeed(){

        canDecrease = false;
        
        speed -= acceleration * 2.5f;

        if(speed < 0){
            speed = 0;
        }

        yield return new WaitForSeconds(timeBetweenSpeed);

        timeBetweenSpeed *= 0.7f;

        canDecrease = true;
    
    }


















    // public void MovementDecider(){

    //     if(verticalInput > 0){
    //         if(horizontalInput > 0){
    //             StartCoroutine(Movement(true, true, true, true));
    //         }

    //         if(horizontalInput < 0){
    //             StartCoroutine(Movement(true, false, true, true));
    //         }

    //         if(horizontalInput == 0){
    //             StartCoroutine(Movement(true, false, true, false));
    //         }
    //     }

    //     else if(verticalInput < 0){
    //         if(horizontalInput > 0){
    //             StartCoroutine(Movement(true, false, true, true));
    //         }

    //         if(horizontalInput < 0){
    //             StartCoroutine(Movement(true, false, true, true));
    //         }

    //         if(horizontalInput == 0){
    //             StartCoroutine(Movement(true, false, true, false));
    //         }
    //     }

    //     else if(verticalInput == 0){
    //         if(horizontalInput > 0){
    //             StartCoroutine(Movement(true, true, false, true));
    //         }

    //         else if(horizontalInput < 0){
    //             StartCoroutine(Movement(false, false, false, true));
    //         }
    //     }

    //     else if(horizontalInput == 0){
    //         if(verticalInput > 0){
    //             StartCoroutine(Movement(true, true, true, false));
    //         }

    //         else if(verticalInput < 0){
    //             StartCoroutine(Movement(true, false, false, false));
    //         }
    //     }


        
    // }

    // public IEnumerator Movement(bool isPosX, bool isPosY, bool isY, bool isX){

    //     Debug.Log("Movement");

    //     if(verticalInput == 0 && horizontalInput == 0){
    //         speed -= acceleration * 2;

    //         if(speed < 0){
    //             speed = 0;
    //         }
    //     }



    //     yield return new WaitForSeconds(1);

    //     Move(isPosX, isPosY, isY, isX);

    // }

    // public void Move(bool isPosX, bool isPosY, bool isY, bool isX){
    //     float xVelocity = 0;
    //     float yVelocity = 0;

    //     if(speed < maxSpeed){
    //         speed += acceleration;
    //     }

    //     if(isPosX && isPosY){
    //         xVelocity = speed;
    //         yVelocity = speed;
    //     }

    //     if(!isPosX && isPosY){
    //         xVelocity = -speed;
    //         yVelocity = speed;
    //     }

    //     if(!isPosX && !isPosY){
    //         xVelocity = -speed;
    //         yVelocity = -speed;
    //     }

    //     if(isPosX && !isPosY){
    //         xVelocity = speed;
    //         yVelocity = -speed;
    //     }

        

    //     Vector2 velocity = new Vector2(xVelocity, yVelocity);
    //     Debug.Log($"X: {xVelocity} : Y: {yVelocity}");

    //     rb.velocity = velocity;
    // }




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
