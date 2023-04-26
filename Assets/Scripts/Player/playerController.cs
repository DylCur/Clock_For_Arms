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

    Rigidbody2D rb;





    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void FixedUpdate()
    {
        
        movement(playerMoveSpeed, horizontalInput = Input.GetAxisRaw("Horizontal"), verticalInput = Input.GetAxisRaw("Vertical")); // Inputs the speed and the inputs 😲
    }

    public void movement(float playerMoveSpeed, float horizontalInput, float verticalInput){

        

        Vector2 movementVector = new Vector2(horizontalInput, verticalInput);

        rb.velocity = movementVector;

    }
}
