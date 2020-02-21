using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*背景画像へアタッチするスクリプト*/
public class haikeiCTL : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        //一定の速度で下へ移動させる
        transform.position = new Vector2(transform.position.x, transform.position.y - 0.01f);

        //画面下まで来たら元の位置へ戻す
        if (transform.position.y < -9f)
        {
            transform.position = new Vector2(-3f, 9);
        }
    }
}
