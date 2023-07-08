using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptWallSpawner : MonoBehaviour
{
    public GameObject wallToSpawn;
    public float spawnPositionY = -25;
    private GameObject currentWall;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Colliding with trigger");

        // This is to check only one wall and not duplicate spawns
        if (collision.gameObject.CompareTag("RightWall"))
        {
            // This is the wall colliding with us
            currentWall = collision.gameObject.transform.parent.gameObject;

            Vector3 spawnPosition = currentWall.transform.position;
            spawnPosition.y = spawnPositionY;

            // Spawn a new wall in the same horizontal position as the current one, but just below the camera
            Instantiate(wallToSpawn, spawnPosition, currentWall.transform.rotation);
        }


    }
}
