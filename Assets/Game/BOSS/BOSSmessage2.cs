using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*chatBOX1(1)に代入するスクリプト
 ボス会話文と本戦起動用
 やってることはBOSSmessage１と同じなので割愛*/
public class BOSSmessage2 : MonoBehaviour
{
    [SerializeField] GameObject gazo;
    [SerializeField] GameObject bosschat;
    [SerializeField] GameObject Playerchat;
    private Text Ptext;
    private Text Btext;
    private int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        Ptext = Playerchat.GetComponent<Text>();
        Btext = bosschat.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //
        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Z))
        {
            count++;
        }
        if (count == 0)
        {
            Ptext.text = "待ちなさい！！ ↵";
            count++;
        }
        if (count == 2)
        {
            count++;
            Btext.text = "あらら～追いつかれちゃったわね ↵";
        }
        if (count == 4)
        {
            count++;
            Ptext.text = "私から逃げられるわけないでしょ！ ↵";
        }
        if (count == 6)
        {
            count++;
            Btext.text = "いつも逃げられてるくせに～ ↵";
        }
        if (count == 8)
        {
            count++;
            Ptext.text = "うっさいわね！ ↵";
        }
        if (count == 10)
        {
            count++;
            Btext.text = "見つかっちゃったのは仕方ないし ↵";
        }
        if (count == 12)
        {
            count++;
            Btext.text = "ここで相手をしてあげる ↵";
        }
        if (count == 14)
        {
            GameObject.FindWithTag("boss").GetComponent<NewBehaviourScript>().enabled = true;
            GameObject.FindWithTag("boss").GetComponent<NewBehaviourScript>().ch = true;
            GameObject.FindWithTag("Player").GetComponent<playerCYL>().bl2 = false;
            GameObject.FindWithTag("Player").GetComponent<playerCYL>().bl = true;
            gazo.SetActive(true);
            Destroy(gameObject);
        }
    }
}