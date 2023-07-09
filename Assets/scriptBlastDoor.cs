using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptBlastDoor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.queriesHitTriggers = true;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        Debug.Log("Clicked on trapdoor!");
        Animator animator = gameObject.GetComponent<Animator>();
        animator.SetBool("Is_Open", true);
        animator.speed = 2.0f;
        Collider2D[] colliders = gameObject.GetComponents<Collider2D>();
        colliders[0].enabled = false;
        colliders[1].enabled = false;
    }
}
