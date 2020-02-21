using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//スペル画像にアタッチするスクリプト
public class slpgazoctl : MonoBehaviour
{
    private float speed = 4f;

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(1f, 1f), step);
        Invoke("Des", 2f);
    }
    void Des()
    {
        Destroy(gameObject);
    }
}
