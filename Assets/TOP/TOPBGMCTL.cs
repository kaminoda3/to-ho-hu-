using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//トップ画面でのBGM
public class TOPBGMCTL : MonoBehaviour
{
    //BGM用オブジェクトが破壊されない様にし、被った場合に片方を削除する
    private void Awake()
    {
        int numBGM = FindObjectsOfType<TOPBGMCTL>().Length;
        if (numBGM > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //ゲーム画面に移動したらBGMオブジェクトを破壊
        if (SceneManager.GetActiveScene().name == "game")
        {
            Destroy(gameObject);
        }
    }
}
