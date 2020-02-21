using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


//キー操作用スクリプト
public class wakuCTL : MonoBehaviour
{
    private int count;
    private bool ch;
    [SerializeField] private AudioSource ok;
    [SerializeField] private AudioSource ng;
    [SerializeField] private AudioSource idou;
    [SerializeField] GameObject MTKOBJ;
    [SerializeField] GameObject MTKCH;
    

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //初期位置の時で上キーが押された時に一番下へ移動
        if (transform.position.y == 0f && Input.GetKeyDown(KeyCode.UpArrow))
        {
            idou.Play();
            transform.position = new Vector2(transform.position.x, -6f);
        }
        //上キーを押された時に枠を上に移動させる
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            idou.PlayOneShot(idou.clip);
            transform.position = new Vector2(transform.position.x, transform.position.y + 3f);
        }

        //下キー押された時用(以下略
        if (transform.position.y == -6f && Input.GetKeyDown(KeyCode.DownArrow))
        {
            idou.PlayOneShot(idou.clip);
            transform.position = new Vector2(transform.position.x, 0f);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            idou.PlayOneShot(idou.clip);
            transform.position = new Vector2(transform.position.x, transform.position.y - 3f);
        }

        //キー操作をされた時
        if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            //ゲームスタート用
            if (transform.position.y == 0f)
            {
                ok.PlayOneShot(ok.clip);

                //無敵オブジェを生成するかどうか
                if (MTKCH.GetComponent<MTKCTL>().MTK==true)
                {
                    Instantiate(MTKOBJ, transform.position, Quaternion.identity);
                }
                Invoke("SecensGame", 0.6f);
            }

            //やめる用
            if (transform.position.y == -3f)
            {
                ng.PlayOneShot(ng.clip); 
                Invoke("SecensQuit", 0.6f);
            }

            //オプション画面への移動用
            if (transform.position.y == -6f)
            {
                ok.PlayOneShot(ok.clip);
                Invoke("SecensSet", 0.6f);
            }
        }

    }

    //各シーンロード
     void SecensGame()
    {
        SceneManager.LoadScene("game");
    }
     void SecensQuit()
    {
        Application.Quit();
    }
     void SecensSet()
    {
        SceneManager.LoadScene("seet");
    }
}
