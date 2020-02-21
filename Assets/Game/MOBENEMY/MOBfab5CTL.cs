using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOBfab5CTL : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y -5f*Time.deltaTime);
        transform.Rotate ( new Vector3(0, 0,Random.Range(270, 420f)*Time.deltaTime));
    }
}
