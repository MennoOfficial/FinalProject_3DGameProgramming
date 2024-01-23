using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public static float health = 100f;
    public Image healthBar;
    public void TakeDamage(float damage)
    {
        health -= damage;
        UpdateHealthBar();

        if (health <= 0)
        {
            KillPlayer();
        }
    }

    private void KillPlayer()
    {
        // You can implement the logic for player death here.
        // For example, you might reload the scene, show a game over screen, etc.

        UIManager.Instance.ShowDeathdUI();
        Debug.Log("Player has been killed!");
    }

    public void ResetHealth()
    {
        health = 100;
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        float healthNormalized = Mathf.Clamp01(health / 100f);
        healthBar.transform.localScale = new Vector3(healthNormalized, 1, 1);
    }
}
