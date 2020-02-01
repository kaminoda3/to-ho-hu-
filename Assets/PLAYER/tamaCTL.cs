using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tamaCTL : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.up.normalized * 15;
    }

    // Update is called once per frame
    void Update()
    {
        //画面外に出たら削除
        if (!GetComponent<Renderer>().isVisible)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision. gameObject.CompareTag("enemy"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("boss"))
        {
            Destroy(gameObject);
        }
    }
}
