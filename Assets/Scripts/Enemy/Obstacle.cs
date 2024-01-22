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

            //Debug.Log("Contact");

            if (playerHealth != null)
            {
                if (playerHealth.health - damage > 0)
                {
                    playerHealth.Damage(damage);
                }
                else 
                {
                    playerHealth.Damage(playerHealth.health);
                    KillPlayer();
                }
            }

        }

        // Testing damage + HP
/*        if (other.CompareTag("Target"))
        {
            Target target = other.GetComponent<Target>();

            if (target != null)
            {
                if (target.health > 0)
                {
                    target.Damage(damage);
                }
                else
                {
                    Debug.Log("Target has been killed");
                }
            }
        }*/
    }

    private void KillPlayer()
    {
        // You can implement the logic for player death here.
        // For example, you might reload the scene, show a game over screen, etc.
        Debug.Log("Player has been killed!");
    }

}
