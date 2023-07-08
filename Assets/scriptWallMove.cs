using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptWallMove : MonoBehaviour
{
    public float fallSpeed = 2;
    public float moveSpeed = 2;
    Vector3 centerPosition;
    float maxMovementWidth = 3;
    // Start is called before the first frame update
    void Start()
    {
        centerPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.up * fallSpeed) * Time.deltaTime;
        
        // Only allows movement inside boundaries

        if (Input.GetKey(KeyCode.A) && (transform.position.x > (centerPosition.x - maxMovementWidth))) 
        {
            transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D) && (transform.position.x < (centerPosition.x + maxMovementWidth)))
        {
            transform.position = transform.position + (Vector3.right * moveSpeed) * Time.deltaTime;
        }
    }
}
