using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mobenemyCTL : MonoBehaviour
{
    [SerializeField] GameObject mob;
    [SerializeField] GameObject mob2;
    [SerializeField] GameObject boss;
    [SerializeField] GameObject player;
    private int count=0;
    private bool check = false;
    /*メモ　X:(外)-8f or -6f or (中)-2f or 2f or (外)4f
            Y:(外)6f or 4f */
    // Start is called before the first frame update
    void Start()
    {

    }

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
            Invoke("pop4", 1f);
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
            Invoke("Shotcheck", 5f);
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
                var mob1 = Instantiate(mob, new Vector2(2f,6f), Quaternion.identity);
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
                var mob1 = Instantiate(mob, new Vector2(-7f,6f), Quaternion.identity);
                yield return new WaitForSeconds(1f);
                mob1.AddComponent<MOBfab1CTL>();
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
                var mob1 = Instantiate(mob, new Vector2(-10f, 4f), Quaternion.identity);
                yield return new WaitForSeconds(1f);
                mob1.AddComponent<MOBfab2CTL>();
                cou++;
            }
            else
            {
                //count++;
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
                var mob1 = Instantiate(mob, new Vector2(4f, 4f), Quaternion.identity);
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
        var mob1 = Instantiate(mob2, new Vector2(-3f, 6f), Quaternion.identity);
        yield return new WaitForSeconds(1f);
        mob1.AddComponent<MOBfab4CTL>();
    }
    void pop6()
    {
        StartCoroutine("Ins6");
    }
    IEnumerator Ins6()
    {
        var mob1 = Instantiate(mob2, new Vector2(2f, 6f), Quaternion.identity);
        yield return new WaitForSeconds(1f);
        mob1.AddComponent<MOBfab4CTL>();
    }
    void pop7()
    {
        StartCoroutine("Ins7");
    }
    IEnumerator Ins7()
    {
        var mob1 = Instantiate(mob2, new Vector2(-7f, 6f), Quaternion.identity);
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
        var mob1 = Instantiate(boss, new Vector2(0f, 6f), Quaternion.identity);
        yield return new WaitForSeconds(1f);
        mob1.AddComponent<BOSSCTL>();
        count++;
    }
    IEnumerator Shotcheck()
    {
player.GetComponent<playerCYL>().shot=false;

        yield return new WaitForSeconds(1f);
    }
}

