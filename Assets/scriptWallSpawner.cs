using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptWallSpawner : MonoBehaviour
{
    public GameObject wallToSpawn0, wallToSpawn1, wallToSpawn2, wallToSpawn3, wallToSpawn4, wallToSpawn5, wallToSpawn6, wallToSpawn7,
        wallToSpawn8, wallToSpawn9, wallToSpawn10, wallToSpawn11, wallToSpawn12, wallToSpawn13, wallToSpawn14, wallToSpawn15;
    public scriptLogicManager logic;

    public bool disableRandom = true;

    public float spawnPositionY = -25;
    private GameObject currentWall;
    private int spawnCounter = 0;
    private int maxSpawn = 15;
    private int nextSpawn = 0;
    private List<GameObject> spawnList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<scriptLogicManager>();
        spawnList.Add(wallToSpawn0);
        spawnList.Add(wallToSpawn1);
        spawnList.Add(wallToSpawn2);
        spawnList.Add(wallToSpawn3);
        spawnList.Add(wallToSpawn4);
        spawnList.Add(wallToSpawn5);
        spawnList.Add(wallToSpawn6);
        spawnList.Add(wallToSpawn7);
        spawnList.Add(wallToSpawn8);
        spawnList.Add(wallToSpawn9);
        spawnList.Add(wallToSpawn10);
        spawnList.Add(wallToSpawn11);
        spawnList.Add(wallToSpawn12);
        spawnList.Add(wallToSpawn13);
        spawnList.Add(wallToSpawn14);
        spawnList.Add(wallToSpawn15);

    }

    // Update is called once per frame
    void Update()
    {
    }

    void InstantiateWall(Vector3 spawnPos, Quaternion spawnRot)
    {
        if (disableRandom)
        {
            if (spawnCounter > maxSpawn)
            {
                spawnCounter = 0;
            }

            // Spawn a new wall in the same horizontal position as the current one, but just below the camera
            Instantiate(spawnList[spawnCounter], spawnPos, spawnRot);
            spawnCounter++;
        }
        else
        {
            int currentSpawn = nextSpawn;
            int randomValue = Random.Range(0, 100);

            // We didn't spawn 0, so we need more chance to spawn it
            if (currentSpawn > 0)
            {
                if (randomValue < 30)
                {
                    nextSpawn = 0;
                }
                else
                {
                    nextSpawn = Random.Range(1, maxSpawn);
                }
            }
            else
            {
                if(randomValue < 40) 
                {
                    nextSpawn = Random.Range(0, 5);
                }
                else
                {
                    nextSpawn = Random.Range(1, maxSpawn);
                }
            }

            Instantiate(spawnList[nextSpawn], spawnPos, spawnRot);
        }

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

            InstantiateWall(spawnPosition, currentWall.transform.rotation);
        }


    }
}
