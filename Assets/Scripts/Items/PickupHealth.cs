using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupHealth : MonoBehaviour
{
    public HealthManager healthManager;
    public int healthAmount;
    public AudioSource pickupSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            GainHealth(healthAmount);
            pickupSound.Play();
            Destroy(gameObject);
        }

    }

    private void GainHealth(int health)
    {
        healthManager.GainHealth(health);
    }
}
