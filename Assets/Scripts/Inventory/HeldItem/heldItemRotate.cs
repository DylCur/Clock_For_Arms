using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heldItemRotate : MonoBehaviour
{

    public Vector3 mousePos;
    public Vector3 direction;
    public float angle;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = (mousePos - transform.position).normalized;
        angle = Vector3.Angle(transform.forward, direction) * Mathf.Sign(Vector3.Cross(transform.forward, direction).y);
        angle = Mathf.Clamp(angle, 0f, 170f);
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    

}
