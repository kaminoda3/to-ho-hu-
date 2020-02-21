using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*ポーズ自ボタン用スクリプト*/
public class pauseCTL : MonoBehaviour
{
    //ポーズ用SE取得
    [SerializeField] AudioSource pause;

    public void tudukeru()
    {
        pause.PlayOneShot(pause.clip);
        GameObject.FindWithTag("bgm").GetComponent<AudioSource>().UnPause();
        GameObject.FindWithTag("EPO").GetComponent<mobenemyCTL>().ch = true;
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
    
    public void yameru()
    {
        //生成された弾を削除
        var clones = GameObject.FindGameObjectsWithTag("enemytama");
        foreach (var clone in clones)
        {
            Destroy(clone);
        }

        //無敵オブジェクトを削除
        Destroy(GameObject.FindWithTag("muteki"));

        //停止していたものをすべて動かして初期の状態へ戻す
        GameObject.FindWithTag("bgm").GetComponent<AudioSource>().UnPause();
        GameObject.FindWithTag("EPO").GetComponent<mobenemyCTL>().ch = true;
        Time.timeScale = 1;
        gameObject.SetActive(false);
        SceneManager.LoadScene("top");
    }
}
