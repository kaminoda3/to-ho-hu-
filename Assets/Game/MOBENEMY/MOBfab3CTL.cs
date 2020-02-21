using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOBfab3CTL : MonoBehaviour
{
    private float speed;
    //メモ　X　左端：-6f 右端　2f 　Y　上:4f下-4 間隔１

    // Start is called before the first frame update
    void Start()
    {
        speed = 3f * Time.deltaTime;
    }
    // Update is called once per frame
    void Update()
    {
        //１段目開始位置から左方向へ動かす
        if (transform.position.y == 4f)
        {
            transform.position = new Vector2(transform.position.x - speed, transform.position.y);
        }
        //右端に到達とき下に動かす
        if (transform.position.x <= -7f && transform.position.y >= 2)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - speed);
        }
        //２段目右端に到達したとき→に動かす
        if (transform.position.y <= 2f)
        {
            transform.position = new Vector2(transform.position.x + speed, transform.position.y);
        }
        //２段目左端に到達した時下に動かす
        if (transform.position.x >= 2f && transform.position.y <= 3f)
        {
            transform.position = new Vector2(transform.position.x - speed, transform.position.y - speed);
        }
        //３段目左端に到達したとき左に動かす
        if (transform.position.y <= 0f)
        {
            transform.position = new Vector2(transform.position.x - speed * 2, transform.position.y);
        }
        //右端に到達とき下に動かす
        if (transform.position.x <= -7f && transform.position.y <= 1f)
        {
            transform.position = new Vector2(transform.position.x + speed, transform.position.y - speed);
        }
        if (transform.position.y <= -6)
        {
            Destroy(gameObject);
        }
    }
}

