using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDetection : MonoBehaviour
{
    public GameObject player;
    public HealthManager healthManager;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        healthManager = player.GetComponent<HealthManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            healthManager.InstaKill();
        }
    }
}
