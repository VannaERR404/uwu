using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IHealth
{
    [SerializeField] public GameObject gun;
    public GameObject player;
    private GameObject myGun;

    [field: SerializeField] public float maxHealth { get; set; }
    public float currentHealth { get; set; }
    public bool isAlive { get => currentHealth > 0; set { } }

    public event OnHealthChanged onHealthChanged;

    public void Dead()
    {
        GameObject.Destroy(myGun);
        GameObject.Destroy(gameObject);
    }

    public void TakeDamage(float damageTaken)
    { 
        float oldhp = currentHealth;
        currentHealth = Mathf.Clamp(currentHealth - damageTaken,0,maxHealth);
        if (currentHealth != oldhp)
        {
            onHealthChanged?.Invoke(this, currentHealth);
        }
        if (currentHealth == 0)
        {
            Dead();
        }
    }

    void Start()
    {
        currentHealth = maxHealth;
        player = GameObject.Find("Player");
        myGun = Instantiate(gun);
        StartFollow();
    }
    void StartFollow()
    {
        FollowTargetRotate fs = myGun.GetComponent<FollowTargetRotate>();
        fs.selfTransform = transform;
        fs.targetTransform = player.transform;
        if (transform.localScale.y > transform.localScale.x)
        { fs.offset = transform.localScale.y / 2f + 0.2f; }

        else { fs.offset = transform.localScale.x / 2f + 0.2f; }
    }
}
