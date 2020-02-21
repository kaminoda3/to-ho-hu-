using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*クリアしたときにトップに戻るためのスクリプト*/
public class CLEARCTL : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //キー操作用
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Destroy(GameObject.FindWithTag("muteki"));
            SceneManager.LoadScene("top");
        }
    }

    //ボタン操作用
    public void onclick()
    {
        Destroy(GameObject.FindWithTag("muteki"));
        SceneManager.LoadScene("top");
    }
}
