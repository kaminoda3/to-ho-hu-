using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*プレイヤーの中心点に居るアイテム獲得時に使用するオブジェクト*/
public class pointct : MonoBehaviour
{
    [SerializeField] GameObject p;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        transform.position = p.transform.position;
    }
}
