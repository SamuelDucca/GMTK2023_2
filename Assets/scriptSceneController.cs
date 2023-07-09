using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptSceneController : MonoBehaviour
{

    private float desiredAlpha;
    private float currentAlpha;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentAlpha = Mathf.MoveTowards(currentAlpha, desiredAlpha, 2.0f * Time.deltaTime);
    }
}
