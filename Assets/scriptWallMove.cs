using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptWallMove : MonoBehaviour
{

    public scriptLogicManager logic;
    public AudioSource audioSource;

    private float fallSpeed = 10;
    public float moveSpeed = 5;
    public float deadZone = 50;
    Vector3 centerPosition;
    float maxMovementWidth = 6;

    private bool reduceAudio = false;

    //CenterPosition reference was causing bad stuff on spawns, decided to cut back to zero
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<scriptLogicManager>();
        centerPosition = transform.position;
        fallSpeed = logic.gameSpeed;
    }

    void ManageAudio()
    {
        if (reduceAudio)
        {
            audioSource.volume -= Time.deltaTime* 0.6f;
        }
        if (audioSource.volume <= 0)
        {
            audioSource.Stop();
        }
    }

    // Update is called once per frame
    void Update()
    {
        fallSpeed = logic.gameSpeed;
        if (logic.isAlive)
        {
            transform.position = transform.position + (Vector3.up * fallSpeed) * Time.deltaTime;

            // Only allows movement inside boundaries

            if (Input.GetKey(KeyCode.A) && (transform.position.x > (0 - maxMovementWidth)))
            {
                if (!audioSource.isPlaying)
                {
                    reduceAudio = false;
                    audioSource.volume = 0.1f;
                    audioSource.time = 1;
                    audioSource.Play();
                }

                transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D) && (transform.position.x < (0 + maxMovementWidth)))
            {
                if (!audioSource.isPlaying)
                {
                    reduceAudio = false;
                    audioSource.volume = 0.1f;
                    audioSource.time = 1;
                    audioSource.Play();
                }
                transform.position = transform.position + (Vector3.right * moveSpeed) * Time.deltaTime;
            }

        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            if (audioSource.isPlaying)
            {
                reduceAudio = true;
                
            }
        }

        ManageAudio();

        // Delete if out of screen
        if (transform.position.y > deadZone) 
        {
            Destroy(gameObject);
        }
    }
}
