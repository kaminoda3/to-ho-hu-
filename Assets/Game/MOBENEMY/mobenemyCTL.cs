using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*道中進行用のスクリプト*/

public class mobenemyCTL : MonoBehaviour
{
    //各オブジェクト取得
    [SerializeField] GameObject mobA1;
    [SerializeField] GameObject mobA2;
    [SerializeField] GameObject mobA3;
    [SerializeField] GameObject mobB1;
    [SerializeField] GameObject mobB2;
    [SerializeField] GameObject mob2;
    [SerializeField] GameObject boss;
    [SerializeField] GameObject player;

    //ゲーム進行用
    public int count = 0;

    //
    public bool check = true;

    //弾幕図鑑
    [SerializeField] GameObject dnmk1;
    [SerializeField] GameObject cb;
    [SerializeField] GameObject cb2;
    [SerializeField] GameObject CLEARtext;

    //一時停止用
    [SerializeField] GameObject pause;
    [SerializeField] AudioSource pauseSE;
    //ポーズしているかどうかの判定
    public bool ch = true;

    /*メモ　X:(外)-8f or -6f or (中)-2f or 2f or (外)4f
            Y:(外)6f or 4f */

    // Update is called once per frame
    void Update()
    {
        if (count == 0)
        {
            count++;
            Invoke("pop1", 3f);
        }
        if (count == 2)
        {
            count++;
            Invoke("pop2", 1f);
        }
        if (count == 4)
        {
            count++;
            Invoke("pop3", 1f);
            Invoke("pop4", 1.5f);
        }
        if (count == 6)
        {
            count++;
            Invoke("pop5", 4f);
            Invoke("pop6", 5.5f);
            Invoke("pop7", 7f);
        }
        if (count == 8)
        {
            count++;
            Invoke("Boss1", 9f);
            Invoke("Bc", 12f);
        }
        if (count == 11)
        {
            count++;
            Invoke("pop8", 3f);
        }
        if (count == 13)
        {
            count++;
            Invoke("pop9", 4f);
            Invoke("pop10", 4f);
            Invoke("pop11", 4f);
        }
        if (count == 16)
        {
            count++;
            Invoke("Boss2", 20f);
            Invoke("Bc2", 22f);
        }
        if (count == 19)
        {
            Invoke("CR", 2f);
        }

        //ボーズ画面用
        if (Input.GetKeyDown(KeyCode.Escape) && ch == true)
        {
            //ポーズメニュー表示
            pause.SetActive(true);
            //ポーズ用SE起動
            pauseSE.PlayOneShot(pauseSE.clip);
            ch = false;
            //プレイヤーの弾発射SEとBGMを停止
            GameObject.FindWithTag("Player").GetComponent<playerCYL>().shotse.Pause();
            GameObject.FindWithTag("bgm").GetComponent<AudioSource>().Pause();
            Time.timeScale = 0;
        }

        //ポーズ画面解除用
        else if (Input.GetKeyDown(KeyCode.Escape) && ch == false)
        {
            ch = true;
            GameObject.FindWithTag("Player").GetComponent<playerCYL>().shotse.UnPause();
            GameObject.FindWithTag("bgm").GetComponent<AudioSource>().UnPause();
            Time.timeScale = 1;
            pause.SetActive(false);
        }
    }

    void pop1()
    {
        StartCoroutine("Ins1");
    }
    IEnumerator Ins1()
    {
        var cou = 0;
        while (true)
        {
            if (cou < 5)
            {
                var mob1 = Instantiate(mobA1, new Vector2(2f, 6f), Quaternion.identity);
                mob1.AddComponent<MOBfab1CTL>();
                yield return new WaitForSeconds(1f);
                cou++;
            }
            else
            {
                count++;
                break;
            }
        }
    }

    void pop2()
    {
        StartCoroutine("Ins2");
    }
    IEnumerator Ins2()
    {
        var cou = 0;
        while (true)
        {
            if (cou < 5)
            {
                var mob1 = Instantiate(mobA1, new Vector2(-7f, 6f), Quaternion.identity);

                mob1.AddComponent<MOBfab1CTL>();
                yield return new WaitForSeconds(1f);
                cou++;
            }
            else
            {
                count++;
                break;
            }
        }
    }

    void pop3()
    {
        StartCoroutine("Ins3");
    }
    IEnumerator Ins3()
    {
        var cou = 0;
        while (true)
        {
            if (cou < 5)
            {
                var mob1 = Instantiate(mobA2, new Vector2(-10f, 4f), Quaternion.identity);
                yield return new WaitForSeconds(1f);
                mob1.AddComponent<MOBfab2CTL>();
                cou++;
            }
            else
            {
                break;
            }
        }
    }

    void pop4()
    {
        StartCoroutine("Ins4");
    }
    IEnumerator Ins4()
    {
        var cou = 0;
        while (true)
        {
            if (cou < 5)
            {
                var mob1 = Instantiate(mobA2, new Vector2(4f, 4f), Quaternion.identity);
                yield return new WaitForSeconds(1f);
                mob1.AddComponent<MOBfab3CTL>();
                cou++;
            }
            else
            {
                count++;
                break;
            }
        }
    }

    void pop5()
    {
        StartCoroutine("Ins5");
    }
    IEnumerator Ins5()
    {
        var mob1 = Instantiate(mobB1, new Vector2(-3f, 6f), Quaternion.identity);
        yield return new WaitForSeconds(1f);
        mob1.AddComponent<MOBfab4CTL>();
    }

    void pop6()
    {
        StartCoroutine("Ins6");
    }
    IEnumerator Ins6()
    {
        var mob1 = Instantiate(mobB1, new Vector2(2f, 6f), Quaternion.identity);
        yield return new WaitForSeconds(1f);
        mob1.AddComponent<MOBfab4CTL>();
    }

    void pop7()
    {
        StartCoroutine("Ins7");
    }
    IEnumerator Ins7()
    {
        var mob1 = Instantiate(mobB1, new Vector2(-7f, 6f), Quaternion.identity);
        yield return new WaitForSeconds(1f);
        mob1.AddComponent<MOBfab4CTL>();
        count++;
    }

    void Boss1()
    {
        StartCoroutine("BossIns1");
    }
    IEnumerator BossIns1()
    {
        Instantiate(boss, new Vector2(0f, 6f), Quaternion.identity);
        yield return new WaitForSeconds(1f);

        count++;
    }
    void Bc()
    {
        cb.SetActive(true);
    }

    void pop8()
    {
        StartCoroutine("Ins8");

    }
    IEnumerator Ins8()
    {
        var cou = 0;
        while (true)
        {
            if (cou < 50)
            {
                var i = Random.Range(-6, 2);
                var s = Random.Range(-0.5f, 5f);
                var mob1 = Instantiate(mobA3, new Vector2((float)i, 6f + s), Quaternion.Euler(new Vector3(0, 0, Random.Range(-5f, 5f))));
                yield return new WaitForSeconds(0.2f);
                cou++;
            }
            else
            {
                count++;
                break;
            }
        }
    }

    void pop9()
    {
        StartCoroutine("Ins9");
    }
    IEnumerator Ins9()
    {
        var mob1 = Instantiate(mobB2, new Vector2(-3f, 6f), Quaternion.identity);
        yield return new WaitForSeconds(1f);
    }

    void pop10()
    {
        StartCoroutine("Ins10");
    }
    IEnumerator Ins10()
    {
        var mob1 = Instantiate(mobB2, new Vector2(2f, 6f), Quaternion.identity);
        yield return new WaitForSeconds(1f);
        count++;
    }

    void pop11()
    {
        StartCoroutine("Ins11");
    }
    IEnumerator Ins11()
    {
        var mob1 = Instantiate(mobB2, new Vector2(-7f, 6f), Quaternion.identity);
        yield return new WaitForSeconds(1f);
        count++;
    }

    void Boss2()
    {
        StartCoroutine("BossIns2");
    }
    IEnumerator BossIns2()
    {
        Instantiate(boss, new Vector2(0f, 6f), Quaternion.identity);
        player.GetComponent<playerCYL>().bl2 = true;
        yield return new WaitForSeconds(1f);
        count++;
    }
    void Bc2()
    {
        cb2.SetActive(true);
    }

    void CR()
    {
        CLEARtext.SetActive(true);
    }

}

