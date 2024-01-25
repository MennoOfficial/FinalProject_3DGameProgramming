using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour, IDamageable
{
    public float health = 50f;
    public GameObject CollectionBox;
    private static int score = 0;
    private int maxScore = 10;

    public int Score
    {
        get
        {
            return score;
        }

        set
        {
            score = value;
        }
    }

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
        //Debug.Log("Score:" + score);
        Destroy(gameObject);
        CollectionBox.SetActive(true);

        if (score == maxScore)
        {
            addProgress();
        }
    }

    void addProgress()
    {
        ProgressManager.Instance.UpdateProgressBar();
    }
}