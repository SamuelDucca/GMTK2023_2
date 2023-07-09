using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    public scriptLogicManager logic;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<scriptLogicManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //animator.speed = 1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Animator animator = gameObject.GetComponent<Animator>();
        animator.SetBool("Is_Crashed", true);

        logic.GameOver();
    }
}
