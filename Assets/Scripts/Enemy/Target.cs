using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour, IDamageable
{
    public float health = 50f;

    public void Damage(float damage)
    {
        health -= damage;
        Debug.Log("Object hit!");
        if (health <= 0)
            Die();
            
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
