using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageApplier : MonoBehaviour
{

    public int entityDamage;
    public DamageManager damageManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CheckDamageCollision(collision);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        CheckDamageCollision(collision);
    }

    private void CheckDamageCollision(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Colisioné");
            ApplyDamage(entityDamage);
            DamageManager.collision2DPosition = transform.position;
        }
    }
    private void ApplyDamage(int damage){
        damageManager.TakeDamage(damage);
    }
}
