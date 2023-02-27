using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageApplier : MonoBehaviour
{

    public int entityDamage;
    public DamageManager damageManager;


    private void Start() {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            Debug.Log("Colisioné");
            applyDamage(entityDamage);
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
