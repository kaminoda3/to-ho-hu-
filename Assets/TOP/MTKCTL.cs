using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*無敵用*/
public class MTKCTL : MonoBehaviour
{
    //無敵にしても良いかの判定
    public bool MTK = false;
    //その文章表示用
    [SerializeField] Text text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //キー操作された時
        if (Input.GetKeyDown(KeyCode.E) && MTK == false)
        {
            MTK = true;
        }
       else if (Input.GetKeyDown(KeyCode.E)&&MTK==true)
        {
            MTK = false;
        }

        if (MTK == true)
        {
            text.text = "ON";
        }
        if (MTK == false)
        {
            text.text = "     OFF";
        }
    }
}
