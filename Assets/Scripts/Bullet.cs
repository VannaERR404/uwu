using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    // Use this for initialization
    void Start()
    {
        rb.AddForce(transform.up * 1f, ForceMode2D.Impulse);
        Destroy(gameObject, 2.5f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);

    }
}
