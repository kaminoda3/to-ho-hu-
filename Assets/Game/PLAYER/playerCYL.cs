using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*プレイヤーにアタッチするスクリプト
 色々管理してるので説明がめんどくさい！！*/
public class playerCYL : MonoBehaviour
{
    //残機数
    private int hp = 4;
    //残機表示用(リストで云々しようとしたけどあきらめた
    [SerializeField] Image php1;
    [SerializeField] Image php2;
    [SerializeField] Image php3;
    [SerializeField] Image php4;
    private List<Image> mylist = new List<Image>();
    //リジットボディ
    [SerializeField] Rigidbody2D rb;
    //移動speed
    [SerializeField] float MAXspeed;
    [SerializeField] float MINspeed;
    //移動用の画像
    [SerializeField] GameObject D;
    [SerializeField] GameObject R;
    [SerializeField] GameObject L;
    //プレイヤー弾AとB
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject bullet2;
    //プレイヤーの周囲に浮いている謎の物体AとB
    [SerializeField] GameObject obj1;
    [SerializeField] GameObject obj2;
    //当たり判定用オブジェクト
    [SerializeField] GameObject hantei;
    //力こそパワー
    public int power;
    //弾発射用SE
    [SerializeField] public AudioSource shotse;
    //弾撃ってもいいかの判定
    public bool shot = true;

    //会話進行時に必要なオブジェクト
    [SerializeField] GameObject enemyPOPobj;
    //
    public int count = 0;
    public bool bl = true;
    public bool bl2 = true;
    //会話文を管理しているオブジェクト
    [SerializeField] GameObject cb;
    //
    [SerializeField] GameObject ht;
    //
    [SerializeField] float tim;
    //
    public bool ch2 = true;
    //
    [SerializeField] GameObject Mtk;

    // Start is called before the first frame update
    void Start()
    {
        //var sin_ = Mathf.Sin(Time.time) / 2 + 0.5f;
        mylist.Add(php1);
        mylist.Add(php2);
        mylist.Add(php3);
        mylist.Add(php4);
    }

    // Update is called once per frame
    void Update()
    {
        //無敵用オブジェクトが存在するかどうか
        if (GameObject.FindWithTag("muteki") != null)
        {
            Mtk.SetActive(true);
        }
        
        //当たり判定用オブジェクトの位置
        hantei.transform.position = transform.position;

        hantei.SetActive(false);

        //入力認識
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        //通常移動用
        Vector2 idou = new Vector2(x, y).normalized;
        //リジットボディに力を加える
        rb.velocity = idou * MAXspeed;

        //低速移動用
        if (Input.GetKey(KeyCode.LeftShift))
        {
            hantei.SetActive(true);
            rb.velocity = idou * MINspeed;
        }

        //移動制限
        transform.position = new Vector2(
            Mathf.Clamp(transform.position.x, -8.6f, 3.4f),
         Mathf.Clamp(transform.position.y, -4.8f, 4.8f));

        //オブジェクトの位置
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            //画像切り替え
            if (x == 0) { D.SetActive(true); L.SetActive(false); R.SetActive(false); }
            if (x < 0) { D.SetActive(false); R.SetActive(false); L.SetActive(true); }
            if (x > 0) { D.SetActive(false); L.SetActive(false); R.SetActive(true); }
            obj1.transform.position = new Vector2(transform.position.x - 1f, transform.position.y);
            obj2.transform.position = new Vector2(transform.position.x + 1f, transform.position.y);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            D.SetActive(true); L.SetActive(false); R.SetActive(false);
            obj1.transform.position = new Vector2(transform.position.x + 0.5f, transform.localPosition.y + 0.3f);
            obj2.transform.position = new Vector2(transform.position.x - 0.5f, transform.localPosition.y + 0.3f);
        }

        //ボスが存在して弾生成がオンの時（メッセージやり取り時に必要だった
        if (GameObject.FindWithTag("boss") != null && bl2 == true)
        {
            bl = false;
            shotse.volume = 0;
        }

        //弾生成条件を満たした時
        if (bl == true && ch2 == true)
        {
            tamas();
            shotse.volume = 0.1f;
            bl = false;
        }

        //パワーの最低保証
        if (power < 10)
        {
            power = 10;
        }

        //残機が無くなった時
        if (hp == 0)
        {
            var clones = GameObject.FindGameObjectsWithTag("enemytama");
            foreach (var clone in clones)
            {
                Destroy(clone);
            }
            Invoke("Load", 1f);
        }
    }
    //トップページに戻る
    void Load()
    {
        SceneManager.LoadScene("top");
    }

    //何かに接初期した時
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //敵関係に当たった時
        if (collision.CompareTag("enemytama") ||
            collision.CompareTag("enemy") ||
            collision.CompareTag("boss"))
        {
            //無敵設定が機能している場合はダメージを受けない
            if (GameObject.FindWithTag("muteki") == null)
            {
                Destroy(mylist[hp - 1]);
                hp -= 1;
                mylist.RemoveAt(mylist.Count - 1);
                power -= 50;
            }

            //被弾時SEを再生して無敵状態にしプレイヤーを点滅させる
            GetComponent<AudioSource>().Play();
            GetComponent<CapsuleCollider2D>().enabled = false;
            StartCoroutine("Collider");
            StartCoroutine("Blink");
        }
    }
    //点滅用
    IEnumerator Blink()
    {
        int i = 0;
        while (i < 20)
        {
            if (ht.activeSelf == true)
            {
                ht.SetActive(false);
                i++;
                yield return new WaitForSeconds(0.15f);
            }
            else
            {
                ht.SetActive(true);
                i++;
                yield return new WaitForSeconds(0.15f);
            }
        }
    }
    //当たり判定を一時的に消す
    IEnumerator Collider()
    {
        yield return new WaitForSeconds(4f);
        GetComponent<CapsuleCollider2D>().enabled = true;
    }

    //弾生成用
    void tamas()
    {
        StartCoroutine("Tam1");
        StartCoroutine("Tamobj1");
        StartCoroutine("Tamobj2");
        StartCoroutine("Tam2");
        StartCoroutine("Tam3");
        StartCoroutine("Tam8");
        StartCoroutine("Tam9");
        StartCoroutine("Tam10");
        StartCoroutine("Tam11");
        StartCoroutine("Tam12");
        StartCoroutine("Tam13");
    }

    IEnumerator Tamobj1()
    {
        if (power >= 10)
        {
            //弾を生成
            var bullets = Instantiate(bullet2, obj1.transform.position, Quaternion.identity);
            bullets.transform.position = new Vector3(obj1.transform.position.x, transform.position.y + 0.4f);
            yield return new WaitForSeconds(tim);
        }
    }

    IEnumerator Tamobj2()
    {
        if (power >= 10)
        {
            //弾を生成
            var bullets = Instantiate(bullet2, obj2.transform.position, Quaternion.identity);
            bullets.transform.position = new Vector3(obj2.transform.position.x, transform.position.y + 0.4f);
            yield return new WaitForSeconds(tim);
        }
    }

    IEnumerator Tam1()
    {
        if (power >= 10)
        {
            //弾を生成
            var bullets = Instantiate(bullet, transform.position, Quaternion.identity);
            bullets.transform.position = new Vector3(transform.position.x, transform.position.y + 0.4f);
            yield return new WaitForSeconds(tim);
            bl = true;
        }
    }

    IEnumerator Tam2()
    {
        if (power >= 40)
        {
            //弾を生成
            var bullets = Instantiate(bullet, transform.position, Quaternion.Euler(0f, 0f, -2f));
            bullets.transform.position = new Vector3(transform.position.x + 0.3f, transform.position.y + 0.4f); ;
            yield return new WaitForSeconds(tim);
        }
    }

    IEnumerator Tam3()
    {
        if (power >= 40)
        {
            //弾を生成
            var bullets = Instantiate(bullet, transform.position, Quaternion.Euler(0f, 0f, 2f));
            bullets.transform.position = new Vector3(transform.position.x - 0.3f, transform.position.y + 0.4f); ;
            yield return new WaitForSeconds(tim);
        }
    }

    IEnumerator Tam8()
    {
        if (power >= 80)
        {
            //弾を生成
            var bullets = Instantiate(bullet, transform.position, Quaternion.Euler(-10f, 0f, 0f));
            bullets.transform.position = new Vector3(transform.position.x - 0.3f, transform.position.y + 0.4f);
            if (!Input.GetKey(KeyCode.LeftShift))
            {
                bullets.transform.rotation = Quaternion.Euler(0f, 0f, 15f);
                bullets.transform.position = new Vector3(transform.position.x, transform.position.y);
            }
            bullets.transform.position = new Vector3(transform.position.x - 0.2f, transform.position.y + 0.4f);
            yield return new WaitForSeconds(tim);
        }
    }

    IEnumerator Tam9()
    {
        if (power >= 80)
        {
            //弾を生成
            var bullets = Instantiate(bullet, transform.position, Quaternion.Euler(-10f, 0f, 0f));
            bullets.transform.position = new Vector3(transform.position.x + 0.3f, transform.position.y + 0.4f);
            if (!Input.GetKey(KeyCode.LeftShift))
            {
                bullets.transform.rotation = Quaternion.Euler(0f, 0f, -15f);
                bullets.transform.position = new Vector3(transform.position.x, transform.position.y);
            }
            bullets.transform.position = new Vector3(transform.position.x + 0.2f, transform.position.y + 0.4f);
            yield return new WaitForSeconds(tim);
        }
    }

    IEnumerator Tam10()
    {
        if (power >= 120)
        {
            //弾を生成
            var bullets = Instantiate(bullet, transform.position, Quaternion.Euler(-10f, 0f, 0f));
            bullets.transform.position = new Vector3(transform.position.x - 0.3f, transform.position.y + 0.4f);
            if (!Input.GetKey(KeyCode.LeftShift))
            {
                bullets.transform.rotation = Quaternion.Euler(0f, 0f, 20f);
                bullets.transform.position = new Vector3(transform.position.x, transform.position.y);
            }
            bullets.transform.position = new Vector3(transform.position.x - 0.4f, transform.position.y + 0.4f);
            yield return new WaitForSeconds(tim);
        }
    }

    IEnumerator Tam11()
    {
        if (power >= 120)
        {
            //弾を生成
            var bullets = Instantiate(bullet, transform.position, Quaternion.Euler(-10f, 0f, 0f));
            bullets.transform.position = new Vector3(transform.position.x + 0.3f, transform.position.y + 0.4f);
            if (!Input.GetKey(KeyCode.LeftShift))
            {
                bullets.transform.rotation = Quaternion.Euler(0f, 0f, -20f);
                bullets.transform.position = new Vector3(transform.position.x, transform.position.y);
            }
            bullets.transform.position = new Vector3(transform.position.x + 0.4f, transform.position.y + 0.4f);
            yield return new WaitForSeconds(tim);
        }
    }

    IEnumerator Tam12()
    {
        if (power >= 160)
        {
            //弾を生成
            var bullets = Instantiate(bullet, transform.position, Quaternion.Euler(-10f, 0f, 0f));
            bullets.transform.position = new Vector3(transform.position.x - 0.3f, transform.position.y + 0.4f);
            if (!Input.GetKey(KeyCode.LeftShift))
            {
                bullets.transform.rotation = Quaternion.Euler(0f, 0f, 25f);
                bullets.transform.position = new Vector3(transform.position.x, transform.position.y);
            }
            bullets.transform.position = new Vector3(transform.position.x - 0.5f, transform.position.y + 0.4f);
            yield return new WaitForSeconds(tim);
        }
    }

    IEnumerator Tam13()
    {
        if (power >= 160)
        {
            //弾を生成
            var bullets = Instantiate(bullet, transform.position, Quaternion.Euler(-10f, 0f, 0f));
            bullets.transform.position = new Vector3(transform.position.x + 0.3f, transform.position.y + 0.4f);
            if (!Input.GetKey(KeyCode.LeftShift))
            {
                bullets.transform.rotation = Quaternion.Euler(0f, 0f, -25f);
                bullets.transform.position = new Vector3(transform.position.x, transform.position.y);
            }
            bullets.transform.position = new Vector3(transform.position.x + 0.5f, transform.position.y + 0.4f);
            yield return new WaitForSeconds(tim);
        }
    }
}
