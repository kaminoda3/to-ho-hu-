using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BOSSmessage : MonoBehaviour
{

    [SerializeField] GameObject bosschat;
    [SerializeField] GameObject Playerchat;
    private Text Ptext;
    private Text Btext;
    private int count = 0;
    [SerializeField] GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Ptext = Playerchat.GetComponent<Text>();
         Btext = bosschat.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(count);
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            count++;
        }
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
            Btext.text = "まぁまぁ～そんなことより ↵";
        }
        if (count == 10)
        {
            count++;
            Btext.text = "たまには少し遊びましょ ↵";
        }
        if (count == 12)
        {
            Destroy(gameObject);
        }
    }
}
