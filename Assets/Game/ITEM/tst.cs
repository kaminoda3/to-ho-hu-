using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tst : MonoBehaviour
{
    [SerializeField] GameObject item1;
    [SerializeField] GameObject item2;
    [SerializeField] GameObject item3;
    private float s = 0.7f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            int im1 = Random.Range(1, 2);
            for (int i = 0; i <= im1; i++)
            {
                Instantiate(item1, new Vector2(transform.position.x + Random.Range(-s, s), transform.position.y), Quaternion.identity);
            }
            int im2 = Random.Range(0, 5);
            if (im2 == 5)
            {
                Instantiate(item2, new Vector2(transform.position.x + Random.Range(-s, s), transform.position.y), Quaternion.identity);
            }
            int im3 = Random.Range(0, 2);
            for (int i = 0; i <= 4 + im3; i++)
            {
                Instantiate(item3, new Vector2(transform.position.x + Random.Range(-s, s), transform.position.y), Quaternion.identity);
            }
        }
    }
}
