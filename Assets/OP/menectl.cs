using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//オプション画面からトップページに戻るためのスクリプト
public class menectl : MonoBehaviour
{
    //SE取得
    [SerializeField] public AudioSource ok;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //キー操作用
        if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            ok.PlayOneShot(ok.clip);
            Invoke("SecensTop", 1f);
        }
    }

    //clickされた時用
    public void click()
    {
        ok.PlayOneShot(ok.clip);
        Invoke("SecensTop", 1f);
    }

    //トップへ移動
    void SecensTop()
    {
        SceneManager.LoadScene("top");
    }
}
