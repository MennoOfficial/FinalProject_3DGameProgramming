using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int damage = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.Damage(damage);
            }
            else if (playerHealth.health <= 0)
            {
                KillPlayer();
            }
        }
    }

    private void KillPlayer()
    {
        // You can implement the logic for player death here.
        // For example, you might reload the scene, show a game over screen, etc.
        Debug.Log("Player has been killed!");
    }

}
