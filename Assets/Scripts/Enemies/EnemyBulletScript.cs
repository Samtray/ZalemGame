using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : Projectile
{
    public float force;
    private float bulletTimer;

    protected override void Start()
    {
        base.Start();

        Vector3 direction = player.transform.position - transform.position;
        projectileRigidBody.velocity  = new Vector2(direction.x, direction.y).normalized * force;

        float rotation = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotation + 180);
    }

    protected override void Update()
    {
        bulletTimer += Time.deltaTime;

        if (bulletTimer > 10) {
            Destroy(gameObject);
        }
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }
}
