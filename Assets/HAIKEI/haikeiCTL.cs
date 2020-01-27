using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class haikeiCTL : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - 0.01f);
        if(transform.position.y < -9f)
        {
            transform.position = new Vector2(-3f, 9);
        }
    }
}
