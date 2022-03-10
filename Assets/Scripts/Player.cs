using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IHealth
{
    [field: SerializeField] public float maxHealth { get; set; }
    public float currentHealth { get; set; }
    public bool isAlive { get => currentHealth > 0; set { } }

    public event OnHealthChanged onHealthChanged;

    public void Dead()
    {
        GameObject.Destroy(gameObject);
    }

    public void TakeDamage(float damageTaken)
    {
        float oldhp = currentHealth;
        currentHealth = Mathf.Clamp(currentHealth - damageTaken, 0, maxHealth);
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
    }
}
