using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptParallax : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] bool scrollDown;

    float singleTextureHeight;

    // Start is called before the first frame update
    void Start()
    {
        SetupTexture();
        if(scrollDown) { moveSpeed = -moveSpeed; }
    }
    void SetupTexture() 
    { 
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        singleTextureHeight = sprite.texture.height / sprite.pixelsPerUnit;
    }

    void Scroll()
    {
        float delta = moveSpeed * Time.deltaTime;
        transform.position += new Vector3(0f, delta, 0f);
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
