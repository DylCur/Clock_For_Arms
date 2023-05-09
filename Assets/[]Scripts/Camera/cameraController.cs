using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{

    public Transform playerPosition;
    public Vector3 cameraPosition;
    public float zOffset;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        cameraPosition = new Vector3(playerPosition.position.x, playerPosition.position.y, playerPosition.position.z - zOffset);
        transform.position = cameraPosition;
    }
}
