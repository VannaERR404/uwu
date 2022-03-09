using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public delegate void OnHealthChanged(IHealth changed, float newHP);
public interface IHealth 
{
    float maxHealth { get; set; }
    float currentHealth { get; set; }
    bool isAlive { get; set; }
    void TakeDamage(float damageTaken);
    void Dead();

    event OnHealthChanged onHealthChanged;
    
}