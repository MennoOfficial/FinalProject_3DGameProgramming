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
        //Debug.Log(damage);
        health -= damage;
        Debug.Log("Object hit!");

        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        // Assuming health is in the range [0, 100], adjust accordingly if it's a different range
        float healthNormalized = health / 100f;
        healthBar.transform.localScale = new Vector3(healthNormalized, 1, 1);
    }
}



