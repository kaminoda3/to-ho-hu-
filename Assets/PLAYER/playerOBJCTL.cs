using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerOBJCTL : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject tama2;
    private int count = 0;
    private bool bl=true;
    private bool bl2=true;
    [SerializeField] GameObject cb;
    // Start is called before the first frame update
    void Start()
    {
 
    }
    
    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindWithTag("boss")!=null&&bl2==true)
        {
            bl=false;
        }
        if (bl2 == true && cb == null)
        {
            bl = true;
            bl2 = false;
        }
        if (bl==true)
        {
            bl=false;
            StartCoroutine("Tam");
        }
    }
    IEnumerator Tam()
    {
        if (true)
        {
            //弾を生成
            Instantiate(tama2, transform.position, Quaternion.identity);
            tama2.transform.position = transform.position;
            yield return new WaitForSeconds(0.1f);
            bl=true;
        }
    }
}
