using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    public scriptLogicManager logic;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<scriptLogicManager>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float gameSpeed = logic.gameSpeed;
        
        animator.speed = 1.34f * gameSpeed/15;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        animator.speed = 1;
        animator.SetBool("Is_Crashed", true);

        logic.GameOver();
    }
}
