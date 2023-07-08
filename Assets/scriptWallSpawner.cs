using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptWallSpawner : MonoBehaviour
{
    public GameObject wallToSpawn1, wallToSpawn2, wallToSpawn3, wallToSpawn4;
    public float spawnPositionY = -25;
    private GameObject currentWall;
    private int spawnCounter = 0;
    private int maxSpawn = 3;
    private List<GameObject> spawnList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        spawnList.Add(wallToSpawn1);
        spawnList.Add(wallToSpawn2);
        spawnList.Add(wallToSpawn3);
        spawnList.Add(wallToSpawn4);
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

            if (spawnCounter > maxSpawn)
            {
                spawnCounter = 0;
            }

            // Spawn a new wall in the same horizontal position as the current one, but just below the camera
            Instantiate(spawnList[spawnCounter], spawnPosition, currentWall.transform.rotation);
            spawnCounter++;
        }


    }
}
