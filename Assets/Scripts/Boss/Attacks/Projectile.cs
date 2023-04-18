using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    public int damage;
    protected GameObject player;
    private HealthManager healthManager;
    protected Rigidbody2D projectileRigidBody; 


    // Start is called before the first frame update
    protected virtual void Start()
    {
        projectileRigidBody = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        healthManager = player.GetComponent<HealthManager>();
    }

    // Update is called once per frame
    protected virtual void Update(){}

    protected virtual void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            healthManager.TakeDamage(damage);
            Destroy(gameObject); 
        }

        else if (collision.gameObject.CompareTag("Terreno")){
            Destroy(gameObject);
        }
    }
}
