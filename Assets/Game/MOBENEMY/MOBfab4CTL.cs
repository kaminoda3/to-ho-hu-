using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOBfab4CTL : MonoBehaviour
{
    private float speed;
    private bool check = false;
    // Start is called before the first frame update
    void Start()
    {
        speed = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - speed*Time.deltaTime);

        if (transform.position.y <= 4f && check == false)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + speed*Time.deltaTime);
            Invoke("Str", 5f);
        }
        if (transform.position.y <= -6)
        {
            Destroy(gameObject);
        }
    }
    private void Str()
    {
        check = true;
    }
}
