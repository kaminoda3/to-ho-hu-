using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mobAHP : MonoBehaviour
{
    [SerializeField] int HP;
    public AudioClip desse;
    AudioSource audioso;
    GameObject tst;
    [SerializeField] GameObject item1;
    [SerializeField] GameObject item2;
    [SerializeField] GameObject item3;
    private float s = 0.7f;
    // Start is called before the first frame update
    void Start()
    {
        tst = GameObject.FindWithTag("br");
        audioso = tst.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (HP < 0)
        {
            audioso.Play();
            int im1 = Random.Range(0, 1);
            for (int i = 0; i <= im1; i++)
            {
                Instantiate(item1, new Vector2(transform.position.x + Random.Range(-s, s), transform.position.y), Quaternion.identity);
            }
            int im2 = Random.Range(0, 5);
            if (im2 == 5)
            {
                Instantiate(item2, new Vector2(transform.position.x + Random.Range(-s, s), transform.position.y), Quaternion.identity);
            }
            int im3 = Random.Range(1, 2);
            for (int i = 0; i <= 2 + im2; i++)
            {
                Instantiate(item3, new Vector2(transform.position.x + Random.Range(-s, s), transform.position.y), Quaternion.identity);
            }
            Destroy(gameObject);
        }
        if (transform.position.y < Random.Range(-6f, -8f))
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("tama"))
        {
            HP -= 1;
        }
    }
}
