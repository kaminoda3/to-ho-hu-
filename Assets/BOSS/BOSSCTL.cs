using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSSCTL : MonoBehaviour
{
    [SerializeField] GameObject boss;
    private int con = 0;
    private float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (con == 0)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(-3f, 2.5f), step);
        }
    }
}
