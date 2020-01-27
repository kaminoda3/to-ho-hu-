using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerCYL : MonoBehaviour
{
    //移動speed
    [SerializeField] float MAXspeed;
    [SerializeField] float MINspeed;
    [SerializeField] Rigidbody2D rb;
    //移動用の画像
    [SerializeField] GameObject D;
    [SerializeField] GameObject R;
    [SerializeField] GameObject L;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject obj1;
    [SerializeField] GameObject obj2;
    [SerializeField] GameObject hantei;
    [SerializeField] public int power;
    [SerializeField] AudioSource shotse;
    public bool shot ;
    // Start is called before the first frame update
    void Start()
    {
        shot = true;
        StartCoroutine("Tam1");
        StartCoroutine("Tam2");
        StartCoroutine("Tam3");
        StartCoroutine("Tam4");
        StartCoroutine("Tam5");
        StartCoroutine("Tam6");
        StartCoroutine("Tam7");
        StartCoroutine("Tam8");
        StartCoroutine("Tam9");
        StartCoroutine("Tam10");
        StartCoroutine("Tam11");
        StartCoroutine("Tam12");
        StartCoroutine("Tam13");
        StartCoroutine("Tam14");
        StartCoroutine("Tam15");
    }

    IEnumerator Tam1()
    {
        if (shot == true)
        {
            while (true)
            {
                //弾を生成
                var bullets = Instantiate(bullet, transform.position, Quaternion.identity);
                bullets.transform.position = new Vector3(transform.position.x, transform.position.y + 0.4f);
                yield return new WaitForSeconds(0.05f);
            }
        }

    }
    IEnumerator Tam2()
    {
        if (shot == true)
        {
            if (power >= 40)
            {
                while (true)
                {
                    //弾を生成
                    var bullets = Instantiate(bullet, transform.position, Quaternion.identity);
                    bullets.transform.position = new Vector3(transform.position.x + 0.3f, transform.position.y + 0.4f); ;
                    yield return new WaitForSeconds(0.05f);
                }
            }
        }
    }
    IEnumerator Tam3()
    {
        if (shot == true)
        {
            if (power >= 40)
            {
                while (true)
                {
                    //弾を生成
                    var bullets = Instantiate(bullet, transform.position, Quaternion.identity);
                    bullets.transform.position = new Vector3(transform.position.x - 0.3f, transform.position.y + 0.4f); ;
                    yield return new WaitForSeconds(0.05f);
                }
            }
        }
    }
    IEnumerator Tam4()
    {
        if (shot == true)
        {
            if (power >= 80)
            {
                while (true)
                {
                    //弾を生成
                    var bullets = Instantiate(bullet, transform.position, Quaternion.identity);
                    bullets.transform.position = new Vector3(transform.position.x + 0.6f, transform.position.y + 0.4f); ;
                    yield return new WaitForSeconds(0.05f);
                }
            }
        }
    }
    IEnumerator Tam5()
    {
        if (shot == true)
        {
            if (power >= 80)
            {
                while (true)
                {
                    //弾を生成
                    var bullets = Instantiate(bullet, transform.position, Quaternion.identity);
                    bullets.transform.position = new Vector3(transform.position.x - 0.6f, transform.position.y + 0.4f); ;
                    yield return new WaitForSeconds(0.05f);
                }
            }
        }
    }
    IEnumerator Tam6()
    {
        if (shot == true)
        {
            if (power >= 120)
            {
                while (true)
                {
                    //弾を生成
                    var bullets = Instantiate(bullet, transform.position, Quaternion.identity);
                    bullets.transform.position = new Vector3(transform.position.x - 0.3f, transform.position.y + 0.4f);
                    if (!Input.GetKey(KeyCode.LeftShift))
                    {
                        bullets.transform.rotation = Quaternion.Euler(0f, 0f, 10f);
                        bullets.transform.position = new Vector3(transform.position.x, transform.position.y);
                    }
                    bullets.transform.position = new Vector3(transform.position.x - 0.1f, transform.position.y + 0.4f);
                    yield return new WaitForSeconds(0.05f);
                }
            }
        }
    }
    IEnumerator Tam7()
    {
        if (shot == true)
        {
            if (power >= 120)
            {
                while (true)
                {
                    //弾を生成
                    var bullets = Instantiate(bullet, transform.position, Quaternion.Euler(-10f, 0f, 0f));
                    bullets.transform.position = new Vector3(transform.position.x + 0.3f, transform.position.y + 0.4f);
                    if (!Input.GetKey(KeyCode.LeftShift))
                    {
                        bullets.transform.rotation = Quaternion.Euler(0f, 0f, -10f);
                        bullets.transform.position = new Vector3(transform.position.x, transform.position.y);
                    }
                    bullets.transform.position = new Vector3(transform.position.x + 0.1f, transform.position.y + 0.4f);
                    yield return new WaitForSeconds(0.05f);
                }
            }
        }
    }
    IEnumerator Tam8()
    {
        if (shot == true)
        {
            if (power >= 120)
            {
                while (true)
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
                    yield return new WaitForSeconds(0.05f);
                }
            }
        }
    }
    IEnumerator Tam9()
    {
        if (shot == true)
        {
            if (power >= 120)
            {
                while (true)
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
                    yield return new WaitForSeconds(0.05f);
                }
            }
        }
    }
    IEnumerator Tam10()
    {
        if (shot == true)
        {
            if (power >= 160)
            {
                while (true)
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
                    yield return new WaitForSeconds(0.05f);
                }
            }
        }
    }
    IEnumerator Tam11()
    {
        if (shot == true)
        {
            if (power >= 160)
            {
                while (true)
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
                    yield return new WaitForSeconds(0.05f);
                }
            }
        }
    }
    IEnumerator Tam12()
    {
        if (shot == true)
        {
            if (power >= 160)
            {
                while (true)
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
                    yield return new WaitForSeconds(0.05f);
                }
            }
        }
    }
    IEnumerator Tam13()
    {
        if (shot == true)
        {
            if (power >= 160)
            {
                while (true)
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
                    yield return new WaitForSeconds(0.05f);
                }
            }
        }
    }
    IEnumerator Tam14()
    {
        if (shot == true)
        {
            if (power >= 200)
            {
                while (true)
                {
                    //弾を生成
                    var bullets = Instantiate(bullet, transform.position, Quaternion.Euler(-10f, 0f, 0f));
                    bullets.transform.position = new Vector3(transform.position.x - 0.3f, transform.position.y + 0.4f);
                    if (!Input.GetKey(KeyCode.LeftShift))
                    {
                        bullets.transform.rotation = Quaternion.Euler(0f, 0f, 30f);
                        bullets.transform.position = new Vector3(transform.position.x, transform.position.y);
                    }
                    bullets.transform.position = new Vector3(transform.position.x - 0.7f, transform.position.y + 0.4f);
                    yield return new WaitForSeconds(0.05f);
                }
            }
        }
    }
    IEnumerator Tam15()
    {
        if (shot == true)
        {
            if (power >= 200)
            {
                while (true)
                {
                    //弾を生成
                    var bullets = Instantiate(bullet, transform.position, Quaternion.Euler(-10f, 0f, 0f));
                    bullets.transform.position = new Vector3(transform.position.x + 0.3f, transform.position.y + 0.4f);
                    if (!Input.GetKey(KeyCode.LeftShift))
                    {
                        bullets.transform.rotation = Quaternion.Euler(0f, 0f, -30f);
                        bullets.transform.position = new Vector3(transform.position.x, transform.position.y);
                    }
                    bullets.transform.position = new Vector3(transform.position.x + 0.7f, transform.position.y + 0.4f);
                    yield return new WaitForSeconds(0.05f);
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log(shot);
        if (shot == true)
        {
            shotse.volume = 0.02f;
        }
        else
        {
            shotse.volume = 0;
        }

        //入力認識
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        //通常移動用
        Vector2 idou = new Vector2(x, y).normalized;
        rb.velocity = idou * MAXspeed;
        //低速移動用
        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.velocity = idou * MINspeed;
        }
        //移動制限
        transform.position = new Vector2(
            Mathf.Clamp(transform.position.x, -8.6f, 3.4f),
         Mathf.Clamp(transform.position.y, -4.8f, 4.8f));

        //オブジェクトの位置
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            hantei.SetActive(false);
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
            hantei.SetActive(true);
            obj1.transform.position = new Vector2(transform.position.x + 0.5f, transform.localPosition.y + 0.3f);
            obj2.transform.position = new Vector2(transform.position.x - 0.5f, transform.localPosition.y + 0.3f);
        }
    }
}
