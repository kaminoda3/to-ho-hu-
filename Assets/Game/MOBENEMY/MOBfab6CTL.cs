using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOBfab6CTL : MonoBehaviour
{
    private bool ch = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - 3f*Time.deltaTime);
        if (transform.position.y < 4f&&ch==true)
        {
            Invoke("Ch", 15);
            transform.position=new Vector2(transform.position.x, transform.position.y + 3f*Time.deltaTime);
        }
    }
    void Ch()
    {
        ch = false;
    }
}
