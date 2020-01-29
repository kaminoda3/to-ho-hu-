using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOBfab1CTL : MonoBehaviour
{
    [SerializeField] GameObject tama;
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - (3f*Time.deltaTime));

        if (transform.position.y <= -6)
        {
            Destroy(gameObject);
        }
    }
}
