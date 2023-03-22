using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    public GameObject player;
    private Rigidbody2D rigidBody;
    public float force;
    private float bulletTimer;
    public HealthManager healthManager;
    public int damage;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        healthManager = player.GetComponent<HealthManager>();

        Vector3 direction = player.transform.position - transform.position;
        rigidBody.velocity  = new Vector2(direction.x, direction.y).normalized * force;

        float rotation = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotation + 180);
    }

    void Update()
    {
        bulletTimer += Time.deltaTime;

        if (bulletTimer > 10) {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            healthManager.TakeDamage(damage);
            Destroy(gameObject); 
        }
    }
}
