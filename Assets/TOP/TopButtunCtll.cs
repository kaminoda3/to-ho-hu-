using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//トップ画面でのボタン操作用スクリプト
public class TopButtunCtll : MonoBehaviour
{
    //各SE
    [SerializeField] private AudioSource ok;
    [SerializeField] private AudioSource ng;
    [SerializeField] private AudioSource idou;

    //無敵オブジェ用
    [SerializeField] GameObject MTKOBJ;
    [SerializeField] GameObject MTKCH;

    //ゲーム開始ボタン用
    public void Game()
    {
        ok.PlayOneShot(ok.clip);
        Invoke("SecensGame", 0.6f);

        //もし無敵判定がオンの時に無敵オブジェを生成
        if (MTKCH.GetComponent<MTKCTL>().MTK == true)
        {
            Instantiate(MTKOBJ, transform.position, Quaternion.identity);
        }
    }

    //やめるボタン用
    public void Quit()
    {
        ng.PlayOneShot(ng.clip);
        Invoke("SecensQuit", 0.6f);
    }

    //オプションボタン用
    public void Set()
    {
        ok.PlayOneShot(ok.clip);
        Invoke("SecensSet", 0.6f);
    }

    //各シーンをロード
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
