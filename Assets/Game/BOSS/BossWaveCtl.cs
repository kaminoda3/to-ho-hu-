using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*NewBehaviourScriptへ移行したため使用していない詳細をそっちを見てね*/
public class BossWaveCtl : MonoBehaviour
{
    private int HP=200;
    [SerializeField] GameObject normal;
    [SerializeField] GameObject spltst1;
    [SerializeField] GameObject spl1;
    [SerializeField] GameObject spl2;
    [SerializeField] GameObject spl3;
    [SerializeField] GameObject bosspop;
    private int count = 0;
    [SerializeField] CapsuleCollider2D cc;
    [SerializeField] GameObject idou;
    [SerializeField] GameObject SplCard;
    [SerializeField] GameObject BossBr;
    [SerializeField] GameObject brSE;
    [SerializeField] GameObject SplGazo;
    public bool ch;
    [SerializeField] GameObject item1;
    [SerializeField] GameObject item2;
    [SerializeField] GameObject item3;
    private float s = 0.7f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //HP回復
        if (HP < 0)
        {
            brSE.GetComponent<AudioSource>().Play();
            count++;
            HP = 100;

        }
        //初動
        if (count == 0)
        {
            Normal();
        }
        //位置初期化
        if (count == 2)
        {
            StartPos();
            SplCard.GetComponent<AudioSource>().Play();
            Instantiate(SplGazo, new Vector2(5f, 1f), Quaternion.identity);
        }
        if (ch == false)
        {  //スペカ１
            if (count == 4)
            {
                Spltst1();
            }
            if (count == 6)
            {
                Item();
                Des();
            }
        }

        if (ch == true)
        {
            //スペカ１
            if (count == 4)
            {
                Spl1();
            }
            if (count == 6)
            {
                spl1.SetActive(false);
                StartPos();
            }
            if (count == 8)
            {
                Normal();
            }
            if (count == 10)
            {
                StartPos();
                SplCard.GetComponent<AudioSource>().Play();
                Instantiate(SplGazo, new Vector2(5f, 1f), Quaternion.identity);

            }
            if (count == 12)
            {
                Spl2();
            }
            if (count == 14)
            {
                GameObject.FindWithTag("bgm").GetComponent<AudioSource>().Stop();

                Spl3();
            }
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
    void Item()
    {
        int im1 = Random.Range(3, 4);
        for (int i = 0; i <= im1; i++)
        {
            Instantiate(item1, new Vector2(transform.position.x + Random.Range(-s, s), transform.position.y), Quaternion.identity);
        }
        int im2 = Random.Range(0, 5);
        if (im2 == 5)
        {
            Instantiate(item2, new Vector2(transform.position.x + Random.Range(-s, s), transform.position.y), Quaternion.identity);
        }
        int im3 = Random.Range(0, 1);
        for (int i = 0; i <= 2 + im2; i++)
        {
            Instantiate(item3, new Vector2(transform.position.x + Random.Range(-s, s), transform.position.y), Quaternion.identity);
        }
    }
    void Sou()
    {
        BossBr.GetComponent<AudioSource>().Play();
    }
    private void Des()
    {
        GameObject.FindGameObjectWithTag("EPO").GetComponent<mobenemyCTL>().count++;
        var clones = GameObject.FindGameObjectsWithTag("enemytama");
        foreach (var clone in clones)
        {
            Destroy(clone);
        }
        Destroy(gameObject);
        Time.timeScale = 1;
    }
    void Normal()
    {
        bosspop.SetActive(false);
        idou.SetActive(true);
        idou.GetComponent<BOSSCTL>().bl = true;
        cc.enabled = true;
        normal.SetActive(true);
        count++;
    }
    void StartPos()
    {
        idou.SetActive(false);
        cc.enabled = false;
        normal.SetActive(false);
        bosspop.SetActive(true);
        Invoke("Cool", 2f);
        count++;
    }

    void Spltst1()
    {

        bosspop.SetActive(false);
        idou.SetActive(true);
idou.GetComponent<BOSSCTL>().bl = true;
        cc.enabled = true;
        spltst1.SetActive(true);
        count++;
    }
    void Spl1()
    {
        bosspop.SetActive(false);
        idou.SetActive(true);
        idou.GetComponent<BOSSCTL>().bl = true;
        cc.enabled = true;
        spl1.SetActive(true);
        count++;
    }
    void Spl2()
    {

        bosspop.SetActive(false);
        idou.SetActive(true);
        idou.GetComponent<BOSSCTL>().bl = true;
        cc.enabled = true;
        spl2.SetActive(true);
        count++;
    }
    void Spl3()
    {
        GameObject.FindWithTag("bgm2").GetComponent<AudioSource>().Play();
        GameObject.FindWithTag("Player").GetComponent<playerCYL>().ch2 = false;
        GameObject.FindWithTag("shotse").GetComponent<AudioSource>().Stop();
        idou.SetActive(false);
        cc.enabled = false;
        spl2.SetActive(false); ;
        bosspop.SetActive(true);
        idou.GetComponent<BOSSCTL>().bl = true;
        spl3.SetActive(true);
        Invoke("Last", 40f);
        count++;

    }
    void Last()
    {
        count++;
    }
    void Cool()
    {
        count++;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("tama"))
        {
            HP -= 1;
        }
    }
}
