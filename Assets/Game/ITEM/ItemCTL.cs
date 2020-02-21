using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*モブにアタッチするアイテム生成用のスクリプト*/
public class ItemCTL : MonoBehaviour
{
    //アイテムのRigidbodyを取得
    [SerializeField] Rigidbody2D rb;

    //プレイヤーへ吸い込まれるときの速度
    private float speed = 15f;

    //吸い込まれても良い距離かどうかの判定
    private bool ch = false;
    private bool ch2 = false;

    //プレイヤーのパワー取得用
    public int pow;

    // Start is called before the first frame update
    void Start()
    {
        //アイテムに対して上方向へ一度だけ力を加える
        rb.AddForce(new Vector2(0, 5f + Random.Range(-1, 1f)), ForceMode2D.Impulse);

        //プレイヤーのパワーを取得
        pow = GameObject.FindWithTag("Player").GetComponent<playerCYL>().power;
    }

    // Update is called once per frame
    void Update()
    {
        //アイテムとプレイヤーの座標を取得
        var P = GameObject.FindWithTag("Player").transform.position;
        var I = transform.position;

        //その距離を計算する
        var kyori = Vector2.Distance(P, I);

        //距離が1.5Fより近くになったら
        if (kyori <= 1.5f)
        {
            ch = true;
        }

        /*距離が更に近づいたとき(プレイヤーの移動速度についてこられなかった時の保険)と
         プレイヤーが条件を満たした時*/
        if (kyori <= 1f||GameObject.FindWithTag("Player").transform.position.y>=2.5f&& GameObject.FindWithTag("Player").GetComponent<playerCYL>().power >= 160)
        {
            ch = true;
            ch2 = true;
        }

        if (ch == true)
        {
            //重力を０にする
            rb.gravityScale = 0;
            //質量を０にする
            rb.mass = 0;

            //アイテムをプレイヤーの位置へ移動させる
            transform.position = Vector2.MoveTowards(I, P, speed * Time.deltaTime);

            if (ch2 == true)
            {
                //ブースト用
                transform.position = Vector2.MoveTowards(I, P, speed * 2 * Time.deltaTime);
            }
        }
    }

    //何かにぶつかった時
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //画面外の壁なら削除
        if (collision.CompareTag("kabe2"))
        {
            Destroy(gameObject);
        }

        //プレイヤーの中心点に当たった時
        if (collision.CompareTag("point"))
        {
            //アイテムがパワー小だった時
            if (this.gameObject.CompareTag("po1"))
            {
                if (GameObject.FindWithTag("Player").GetComponent<playerCYL>().power <= 160)
                {
                    GameObject.FindWithTag("Player").GetComponent<playerCYL>().power += 10;
                }
                else
                {
                    GameObject.FindWithTag("EPO").GetComponent<scoreCTL>().score += 1000;

                }
            }

            //アイテムがパワー大だった時
            else if (this.CompareTag("po2"))
            {
                if (GameObject.FindWithTag("Player").GetComponent<playerCYL>().power <= 160)
                {
                    GameObject.FindWithTag("Player").GetComponent<playerCYL>().power += 20;
                }
                else
                {
                    GameObject.FindWithTag("EPO").GetComponent<scoreCTL>().score += 5000;

                }
            }

            //それ以外、つまり点数アイテムだった時
            else
            {
                GameObject.FindWithTag("EPO").GetComponent<scoreCTL>().score += 3000;
            }

            Destroy(gameObject);
        }
    }
}



