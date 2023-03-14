using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDetection : MonoBehaviour
{
    public GameObject player;
    public DamageManager damageManager;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        damageManager = player.GetComponent<DamageManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            damageManager.InstaKill();
        }
    }
}
