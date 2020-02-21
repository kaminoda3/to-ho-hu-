using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*スコアを表示するためのスクリプト*/
public class scoreCTL : MonoBehaviour
{
   [SerializeField] Text text;
    public int score = 0;

    // Update is called once per frame
    void Update()
    {
        text.text =""+ score;
    }
}
