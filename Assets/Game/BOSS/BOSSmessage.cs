using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*chatBOX1にアタッチするスクリプト
 会話文とボス前哨戦のオブジェクトを呼び出す*/
public class BOSSmessage : MonoBehaviour
{
    //ボスとプレイヤーのテキスト欄を取得
    [SerializeField] GameObject bosschat;
    [SerializeField] GameObject Playerchat;
    private Text Ptext;
    private Text Btext;
    //会話を進める時に使うぶっちゃけなくてもなんとかなる
    private int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        //テキストコンポーネントを取得
        Ptext = Playerchat.GetComponent<Text>();
        Btext = bosschat.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //特定のキーが押された時
        if (Input.GetKeyDown(KeyCode.KeypadEnter)|| Input.GetKeyDown(KeyCode.Z))
        {
            /*値を一つ増やす(上の分をすべてのメッセージに追加するほうが確実だけど
            気付いてから戻すのがめんどくさかったん・・・*/
            count++;
        }
        //メッセージの進行
        if (count == 0)
        {
            Btext.text = "あら？珍しいお客さんね ↵";
            count++;
        }
        if (count == 2)
        {
            count++;
            Ptext.text = "こんなところでなにしてるのよ ↵";
        }
        if (count == 4)
        {
            count++;
            Btext.text = "ただのお散歩よ？ ↵";
        }
        if (count == 6)
        {
            count++;
            Ptext.text = "信じられる訳ないでしょ・・ ↵";
        }
        if (count == 8)
        {
            count++;
            Btext.text = "これ以上追いかけてくるなら ↵";
        }
        if (count == 10)
        {
            count++;
            Btext.text = "怪我しても知らないわよ？ ↵";
        }
        //メッセージ終了
        if (count == 12)
        {
            //生成してあるボスタグを取得して各々のスクリプトを起動させる
            GameObject.FindWithTag("boss").GetComponent<NewBehaviourScript>().enabled = true;
            GameObject.FindWithTag("boss").GetComponent<NewBehaviourScript>().ch = false;
            GameObject.FindWithTag("Player").GetComponent<playerCYL>().bl2 = false;
            GameObject.FindWithTag("Player").GetComponent<playerCYL>().bl = true;
            Destroy(gameObject);
        }
    }
}
