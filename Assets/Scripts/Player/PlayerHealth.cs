using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100f;

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
    }


}
