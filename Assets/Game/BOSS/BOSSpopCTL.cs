using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*ボスにアタッチするスクリプト
 ボスを初期位置へ移動させるためのスクリプト*/
public class BOSSpopCTL : MonoBehaviour
{
    //移動速度
    private float speed = 3f;
    //ボスオブジェクト取得
    [SerializeField] GameObject boss;

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        //ボスを初期位置の座標へstep速度で移動させる
        boss.transform.position = Vector2.MoveTowards(boss.transform.position, new Vector2(-3f, 2.5f), step);
    }
}
