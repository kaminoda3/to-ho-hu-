using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerOBJCTL : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject tama2;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Tam");
    }
    IEnumerator Tam()
    {
        while (true)
        {
            //弾を生成
            Instantiate(tama2, transform.position, Quaternion.identity);
            tama2.transform.position = transform.position;
            yield return new WaitForSeconds(0.1f);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
