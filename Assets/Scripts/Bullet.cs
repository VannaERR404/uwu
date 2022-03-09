using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;

    void Start()
    {
        rb.AddForce(transform.up * 1f, ForceMode2D.Impulse);
        Destroy(gameObject, 2.5f);
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.TryGetComponent<IHealth>(out IHealth hit))
        {
            hit.TakeDamage(9000000000000000000);
        }
        Destroy(gameObject);
    }
}
