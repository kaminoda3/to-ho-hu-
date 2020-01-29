using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tama1CTL : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed;
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        // rb.AddForce(Vector2.up * speed, ForceMode2D.Impulse);

        shot();
    }
    IEnumerator shot()
    {
        while (true)
        {
            var aim = transform.position - player.transform.position;
            var look = Quaternion.LookRotation(aim);
            Vector2 force = transform.forward * 10f;
            transform.localRotation = look;
            rb.AddForce(force,ForceMode2D.Impulse);
            yield return new WaitForSeconds(0.5f);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
