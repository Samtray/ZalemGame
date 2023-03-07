using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageApplier : MonoBehaviour
{

    public int entityDamage;
    public DamageManager damageManager;


    private void Start() {
    }

    private void Update()
    {
        
    }

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
            applyDamage(entityDamage);
            DamageManager.collision2DPosition = transform.position;
        }
    }

    /*private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Demonio") { 
            Debug.Log("Descolisioné");
        }
    }*/

    private void applyDamage(int damage){
        damageManager.takeDamage(damage);
    }
}
