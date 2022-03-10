using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;

    void Start()
    {
        rb.AddForce(transform.up * 17f, ForceMode2D.Impulse);
        Destroy(gameObject, 5f);
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.TryGetComponent<IHealth>(out IHealth hit))
        {
            hit.TakeDamage(1);
        }
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
