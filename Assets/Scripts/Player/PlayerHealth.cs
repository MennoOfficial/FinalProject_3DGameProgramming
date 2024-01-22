using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100f;
    public Image healthBar;
    
    public void Damage(float damage)
    {
        if(health < damage)
        {
            health = 0;
        }else
        {
            health -= damage;
        }
        Debug.Log("Object hit!");

        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        // Assuming health is in the range [0, 100], adjust accordingly if it's a different range
        float healthNormalized = health / 100f;
        healthBar.fillAmount = healthNormalized;
    }
}



