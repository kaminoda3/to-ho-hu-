using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tst : MonoBehaviour
{
    [SerializeField] GameObject chatbox;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (chatbox!=null)
        {
            if (GameObject.FindWithTag("boss") != null)
            {
                Invoke("Bc", 3f);
            }
        }
    }
    void Bc()
    {
        chatbox.SetActive(true);
    }
}
