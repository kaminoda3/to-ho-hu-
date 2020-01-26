using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//左上端Start

public class MOBfab2CTL : MonoBehaviour
{
    private int con = 0;
    private float speed =0.05f;
    private bool check = false;
    //メモ　X　左端：-6f 右端　2f 　Y　上:4f下-4 間隔１
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (check == false)
        {
            //１段目開始位置から→方向へ動かす
            if (transform.position.y == 4f)
            {
                transform.position = new Vector2(transform.position.x + speed, transform.position.y);
            }
        }
        //右端に到達とき↓に動かす
        if (transform.position.x >= 2f)
        {
            check = true;
            transform.position = new Vector2(transform.position.x, transform.position.y - speed);
        }
        //２段目右端に到達したとき←に動かす
        if (transform.position.y <= 3f)
        {
            transform.position = new Vector2(transform.position.x - speed, transform.position.y);
        }
        //２段目左端に到達した時↓に動かす

            if (transform.position.x <= -6f && transform.position.y!=4f)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - speed);
           }
        
        //３段目左端に到達したとき→に動かす
        if (transform.position.y <= 2f)
        {
            transform.position = new Vector2(transform.position.x + speed, transform.position.y);
        }

    }
}
