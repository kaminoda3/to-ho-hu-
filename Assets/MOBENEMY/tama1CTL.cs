﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tama1CTL : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {/*
        //画面外に出たら削除
        if (!GetComponent<Renderer>().isVisible)
        {
            Destroy(gameObject);
        }*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

}
