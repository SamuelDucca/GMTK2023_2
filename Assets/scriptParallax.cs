using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptParallax : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] bool scrollDown;

    float singleTextureHeight;
    float singleTextureWidth;

    public GameObject wall;

    // Start is called before the first frame update
    void Start()
    {
        SetupTexture();
        if(scrollDown) { moveSpeed = -moveSpeed; }
        wall = GameObject.FindWithTag("RightWall");
    }
    void SetupTexture() 
    { 
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        singleTextureHeight = sprite.texture.height / sprite.pixelsPerUnit;
        singleTextureWidth = sprite.texture.width / sprite.pixelsPerUnit;
    }

    void Scroll()
    {
        wall = GameObject.FindWithTag("RightWall");
        float delta = moveSpeed * Time.deltaTime;
        //float x_delta = moveSpeed * 0.1f * Time.deltaTime * (transform.position.x - wall.transform.position.x);

        //if ((Mathf.Abs(transform.position.x + x_delta) - singleTextureWidth) <= 0)
        //{
        //    x_delta = 0;
        //}

        transform.position = new Vector3(wall.transform.position.x, transform.position.y + delta, 0f);
    }

    void CheckReset() 
    { 
        if ( (Mathf.Abs(transform.position.y) - singleTextureHeight) > 0)
        {
            transform.position = new Vector3 (transform.position.x, 0.0f, transform.position.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Scroll();
        CheckReset();
    }
}
