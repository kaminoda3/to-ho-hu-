using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*ボスにアタッチするスクリプト
 ボスの行動waveやステータス？を管理する
 ※スペルカードは所謂必殺技というかそんな感じ*/
public class NewBehaviourScript : MonoBehaviour
{
    //ボスのHP
    private int HP = 300;
    //通常攻撃
    [SerializeField] GameObject normal;
    //前哨戦用のスペルカード
    [SerializeField] GameObject spltst1;
    //本戦用のスペルカード
    [SerializeField] GameObject spl1;
    [SerializeField] GameObject spl2;
    [SerializeField] GameObject spl3;

    //ボスの初期位置への移動を管理するスクリプトをアタッチしてあるオブジェクトを取得
    [SerializeField] GameObject bosspop;

    //waveの進行用、各wave事に進める
    public int count = 0;

    //カプセルコライダーを取得
    [SerializeField] CapsuleCollider2D cc;

    //ボスの移動を管理するスクリプトをアタッチしてあるオブジェクトを取得
    [SerializeField] GameObject idou;

    //スペルカード発動時のSE
    [SerializeField] GameObject SplCard;
    private AudioSource sc;

    //ボスが撃破された時のSE
    [SerializeField] GameObject BossBr;
    private AudioSource bb;

    //waveが突破された時の効果音
    [SerializeField] GameObject brSE;
    private AudioSource br;

    //スペルカード発動時の挿絵
    [SerializeField] GameObject SplGazo;

    //ボス戦が前哨戦なのか本戦なのか判断するため
    public bool ch;

    //通常BGM
    private AudioSource bgm1;
    //ラスト用のBGM
    private AudioSource bgm22;

    private mobenemyCTL ct;

    private bool bll;

    private bool cch2;

    private AudioSource sh;

    //アイテム生成用
    [SerializeField] GameObject item1;
    [SerializeField] GameObject item2;
    [SerializeField] GameObject item3;

    //アイテムの生成される位置
    private float s = 0.7f;

    //ボスの中央座標
    private Vector3 Spos = new Vector3(-3f, 2.5f);

    // Start is called before the first frame update
    void Start()
    {   //各々のコンポーネントを取得

        //通常撃破SE
        br = brSE.GetComponent<AudioSource>();

        //ラスト撃破用SE
        bb = BossBr.GetComponent<AudioSource>();

        //スペルカード発動時SE
        sc = SplCard.GetComponent<AudioSource>();

        //BGM
        bgm1 = GameObject.FindWithTag("bgm").GetComponent<AudioSource>();
        bgm22 = GameObject.FindWithTag("bgm2").GetComponent<AudioSource>();

        //ゲーム進行・スコア計算用オブジェクト取得
        ct = GameObject.FindGameObjectWithTag("EPO").GetComponent<mobenemyCTL>();

        //プレイヤーの弾生成判定を取得
        cch2 = GameObject.FindWithTag("Player").GetComponent<playerCYL>();

        //プレイヤーの弾生成時SEを取得
        sh = GameObject.FindWithTag("shotse").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //HP回復
        if (HP < 0)
        {
            //wave突破SEを起動
            br.Play();
            count++;
            HP = 300;
        }

        //初動、通常攻撃
        if (count == 0 && transform.position == Spos)
        {
            Invoke("Normal", 1f);
            count++;
        }

        //位置初期化
        if (count == 2)
        {
            //通常攻撃オフ・初期位置へ移動・スペルカード発動SE起動・挿絵生成(使いまわしでもよかったかも)
            normal.SetActive(false);
            StartPos();
            sc.Play();
            Instantiate(SplGazo, new Vector2(5f, 1f), Quaternion.identity);
        }

        //前哨戦の時
        if (ch == false)
        { 
            //スペカ１
            if (count == 4 && transform.position == Spos)
            {
                //スペルカード起動
                Invoke("Spltst1", 1f);
                count++;
            }

            //前哨戦が突破された時
            if (count == 6)
            {
                Item();
                Des();
            }
        }

        //本戦の場合
        if (ch == true)
        {
            //スペカ１
            if (count == 4)
            {
                //通常攻撃オフ
                normal.SetActive(false);

                //ボスの位置が初期位置に戻った時に進行を進める
                if (transform.position == Spos)
                {
                    Invoke("Spl1", 1f);
                    count++;
                }
            }

            //スペカ１突破された時
            if (count == 6)
            {
                //アイテム生成・spl1を破棄・初期位置への移動
                Item();
                Destroy(spl1);
                StartPos();
            }

            //進行が進み初期位置へ到達したとき
            if (count == 8 && transform.position == Spos)
            {
                //通常攻撃２回目を開始
                Invoke("Normal", 1f);
                count++;
            }

            //通常攻撃２回目が突破されたとき
            if (count == 10)
            {
                //通常攻撃オフ・スコア加算・初期位置へ移動・wave突破SE起動・挿絵生成
                normal.SetActive(false);
                GameObject.FindWithTag("EPO").GetComponent<scoreCTL>().score += 3000;
                StartPos();
                sc.Play();
                Instantiate(SplGazo, new Vector2(5f, 1f), Quaternion.identity);
            }

            //進行が進み初期位置へ到達したとき
            if (count == 12 && transform.position == Spos)
            {
                //スペルカード２発動
                Invoke("Spl2", 1f);
                count++;
            }

            //スペルカード２が突破されたとき
            if (count == 14)
            {
                //スコア加算・BGM1を停止・スペルカード３発動
                GameObject.FindWithTag("EPO").GetComponent<scoreCTL>().score += 10000;
                bgm1.Stop();
                Invoke("Spl3", 1f);
                count++;
            }

            //ボスの位置を初期位置へ移動・プレイヤーの弾生成をオフにする
            if (count == 15)
            {
                GameObject.FindWithTag("Player").GetComponent<playerCYL>().ch2 = false;
                float step = 3f * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(-2.5f, 2.5f), step);
            }

            //スペルカード３が突破されたとき
            if (count == 16)
            {
                count++;
                spl3.SetActive(false);
                Time.timeScale = 0.2f;
                Invoke("Sou", 0.6f);
                Invoke("Des", 1f);
            }
        }
    }

    //アイテム生成用
    void Item()
    {
        //パワーアイテム小を生成
        int im1 = Random.Range(3, 4);
        for (int i = 0; i <= im1; i++)
        {
            Instantiate(item1, new Vector2(transform.position.x + Random.Range(-s, s), transform.position.y), Quaternion.identity);
        }

        //パワーアイテム大2割の確立で生成
        int im2 = Random.Range(0, 5);
        if (im2 == 5)
        {
            Instantiate(item2, new Vector2(transform.position.x + Random.Range(-s, s), transform.position.y), Quaternion.identity);
        }

        //スコア獲得用アイテムを生成
        int im3 = Random.Range(0, 1);
        for (int i = 0; i <= 2 + im2; i++)
        {
            Instantiate(item3, new Vector2(transform.position.x + Random.Range(-s, s), transform.position.y), Quaternion.identity);
        }
    }

    //ボス撃破用SE起動
    void Sou()
    {
        bb.Play();
    }

    //ボスが撃破された時
    private void Des()
    {
        //前哨戦用の進行を進める
        ct.count++;

        //ボスの弾をclonesというオブジェクトに代入する
        var clones = GameObject.FindGameObjectsWithTag("enemytama");

        //それらをcloneという配列へ格納する
        foreach (var clone in clones)
        {   //一括削除
            Destroy(clone);
        }
        //スコア加算
        GameObject.FindWithTag("EPO").GetComponent<scoreCTL>().score += 30000;
        Destroy(gameObject);
        Time.timeScale = 1;
    }

    //通常攻撃
    void Normal()
    {
        //初期位置移動をオフ、カプセルコライダー・通常移動・通常攻撃を起動
        cc.enabled = true;
        bosspop.SetActive(false);
        idou.SetActive(true);
        normal.SetActive(true);
    }

    //初期位置への移動用
    void StartPos()
    {
        //通常移動・カプセルコライダーをオフ、初期位置移動を起動
        idou.SetActive(false);
        cc.enabled = false;
        bosspop.SetActive(true);
        Invoke("Cool", 2f);
        count++;
    }

    //前哨戦用スペルカード
    void Spltst1()
    {
        //初期位置移動をオフ、通常移動・カプセルコライダー・前哨戦スペルカードを起動
        bosspop.SetActive(false);
        idou.SetActive(true);
        cc.enabled = true;
        spltst1.SetActive(true);
    }

    //本戦スペルカード１
    void Spl1()
    {
        //ボスの初期位置移動をオフ、通常移動・カプセルコライダー・本戦スペルカード１を起動
        bosspop.SetActive(false);
        idou.SetActive(true);
        cc.enabled = true;
        spl1.SetActive(true);
    }

    //本戦スペルカード２(ほぼ１と一緒
    void Spl2()
    {
        Destroy(normal);
        bosspop.SetActive(false);
        idou.SetActive(true);
        cc.enabled = true;
        spl2.SetActive(true);
    }

    //本戦スペルカード３
    void Spl3()
    {
        bgm22.Play();
        sh.Stop();
        idou.SetActive(false);
        cc.enabled = false;
        Destroy(spl2);
        spl3.SetActive(true);
        Invoke("Last", 41f);
    }

    //ラストスペルの効果時間
    void Last()
    {
        count++;
    }

    //初期位置移動までの猶予分、void StartPos()に書いてある
    void Cool()
    {
        count++;
    }

    //ボスに弾が当たった時にHPを減らす
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("tama"))
        {
            HP -= 1;
        }
    }
}
