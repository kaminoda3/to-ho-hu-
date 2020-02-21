using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*ボスオブジェクトにアタッチする
  ボスの移動用スクリプト*/
public class BOSSCTL : MonoBehaviour
{
    //ボスオブジェクト取得
    [SerializeField] GameObject boss;
    //移動先の座標を計算するかどうかの判定
    public bool bl = true;
    //
    private int con = 0;
    //移動時の速度用
    private float speed = 3f;
    //移動先の座標用
    private Vector3 pos;
    //
    private Vector3 Spos;
    //座標代入用
    private float x;
    private float y;

    // Start is called before the first frame update
    void Start()
    {
        //初動,ランダムな位置への移動用
        x = Random.Range(-2f, 2f);
        y = Random.Range(-1f, 1f);
        pos = new Vector2(boss.transform.position.x + x, boss.transform.position.y + y);
    }

    // Update is called once per frame
    void Update()
    {
        //新たな移動先を計算してもよいかどうか
        if (bl == true)
        {
            //新たな移動先を計算する
            Invoke("ZH", 3f);
            bl = false;
        }
        //速度に時間を入れることで処理速度によらず一定の時間で移動できるようにするため
        float step = speed * Time.deltaTime;

        //ボスの座標をボス座標とpos間にstepの速度で移動できるようにする
        boss.transform.position = Vector2.MoveTowards(boss.transform.position, pos, step);
    }
    //移動計算式
    void ZH()
    {
        //ボス座標がボスの移動フィールドの中心からどれだけ離れているかを測定する
        var xr = -2.5f - boss.transform.position.x;
        var yr = 3f - boss.transform.position.y;

        //ボス座標が中央より右側に居る場合
        if (boss.transform.position.x > -2.5f)
        {
            //中央より3.5f以上遠い場合
            if (xr < -3.5f)
            {
                //それ以上外に行かない様にしつつランダムで値を決める
                x = Random.Range(0f, -3f);
            }
            //気持ち中央寄りに動いてもらう
            else if (xr < -2.5f)
            {
                x = Random.Range(1f, -3f);
            }
            //好きなところに動いていいお
            else
            {
                x = Random.Range(-2f, 2f);
            }
        }
        //ボス座標が中央より左側だった場合(以下略
        else
        {
            if (xr > 3.5f)
            {
                x = Random.Range(3f, 0f);
            }
            else if (xr > 2.5f)
            {
                x = Random.Range(3f, 1f);
            }
            else
            {
                x = Random.Range(-2f, 2f);
            }
        }
        //ボス座標が移動フィールドの中心点より上に居る時(残り以下略
        if (boss.transform.position.y > 2.6f)
        {
            if (yr < -1.5f)
            {
                y = Random.Range(0f, -1f);
            }
            else if (yr < -0.5f)
            {
                y = Random.Range(-1f, 0.5f);
            }
            else
            {
                y = Random.Range(-1f, 1f);
            }
        }
        //ボス座標が移動フィールドの中心より下に居る時(残り以下略
        else
        {
            if (yr > 1.5f)
            {
                y = Random.Range(1f, 0f);
            }
            else if (yr > 0.5f)
            {
                y = Random.Range(1f, -0.5f);
            }
            else
            {
                y = Random.Range(-1f, 1f);
            }
        }
        //新たな移動先を代入する
        pos = new Vector2(boss.transform.position.x + x, boss.transform.position.y + y);
        bl = true;
    }
}