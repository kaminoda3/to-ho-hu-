using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOBfab3CTL : MonoBehaviour
{
    private float speed = 0.05f;
    //メモ　X　左端：-6f 右端　2f 　Y　上:4f下-4 間隔１

    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        //１段目開始位置から→方向へ動かす
        if (transform.position.y == 4f)
        {
            Debug.Log(1);
            transform.position = new Vector2(transform.position.x - speed, transform.position.y);
        }
        //右端に到達とき↓に動かす
        if (transform.position.x >= 2f && transform.position.y >= 2)
        {
            Debug.Log(2);
            transform.position = new Vector2(transform.position.x, transform.position.y - speed);
        }
        //２段目右端に到達したとき←に動かす
        if (transform.position.y <= 2f)
        {
            Debug.Log(3);
            transform.position = new Vector2(transform.position.x - speed, transform.position.y);
        }
        //２段目左端に到達した時↓に動かす
        if (transform.position.x <= -6f && transform.position.y <= 3f)
        {
            Debug.Log(4);
            transform.position = new Vector2(transform.position.x + speed, transform.position.y - speed);
        }
        //３段目左端に到達したとき→に動かす
        if (transform.position.y <= 0f)
        {
            Debug.Log(5);
            transform.position = new Vector2(transform.position.x + speed * 2, transform.position.y);
        }
        //右端に到達とき↓に動かす
        if (transform.position.x >= 2f && transform.position.y <= 1f)
        {
            Debug.Log(6);
            transform.position = new Vector2(transform.position.x - speed, transform.position.y - speed);
        }
    }
}

