using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour, IDamageable
{
    public float health = 50f;
    public GameObject CollectionBox;
    private int score = 0;
    static int maxScore = 10;
    public void Damage(float damage)
    {
        health -= damage;
        Debug.Log("Object hit!");
        Debug.Log("Score: " + score);
        if (health <= 0)
            Die();
    }
    void Die()
    {
        score++;
        Destroy(gameObject);
        CollectionBox.SetActive(true);
    }
}