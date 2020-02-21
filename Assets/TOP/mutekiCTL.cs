using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//無敵オブジェクト用

public class mutekiCTL : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
