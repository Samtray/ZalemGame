using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupHealth : MonoBehaviour
{
    public HealthManager healthManager;
    public int healthAmount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CheckHealthCollision(collision);
        Destroy(gameObject);
    }

    private void CheckHealthCollision(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GainHealth(healthAmount);
        }
    }

    private void GainHealth(int health)
    {
        healthManager.GainHealth(health);
    }
}
