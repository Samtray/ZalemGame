using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleFireBallSpawner : MonoBehaviour
{
    public GameObject projectile;
    public float projectileVelocity;
    [SerializeField] private float delayBetweenProjectiles;
    private float lastAttackedAt; 
    private float currentBulletCount;

    private int shotCount; 
    void Start()
    {
        lastAttackedAt = -999f;
        gameObject.SetActive(true);
        currentBulletCount = 0;
        shotCount = 0;
    }

    private void Update() {
        if(Time.time > lastAttackedAt + delayBetweenProjectiles){
            lastAttackedAt = Time.time;
            spawnProjectiles();
            
            shotCount++; 
        }

        if (shotCount == 3){
            gameObject.SetActive(false);
        }
    }

    private void OnEnable() {
        Start();
    }

    private void spawnProjectiles() {
        // 0 degs in Unity starts from the top and advances clockwise. 
        //Spacing between projectiles
        float angleStep = 180f / 5;
        // The first projectile spawns at a non-zero degree.
        float angle = 90f;
        float radius = (transform.position.x / 2) + (transform.position.y / 2);

        for(int i = 0; i <= 5; i++){
            float projectileDirectionX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
            float projectileDirectionY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

            Vector2 projectileVector = new Vector2(projectileDirectionX, projectileDirectionY);
            Vector2 projectileMoveDirection = (projectileVector - (Vector2)transform.position).normalized;
            float rotation = Mathf.Atan2(-projectileMoveDirection.y, -projectileMoveDirection.x) * Mathf.Rad2Deg;

            GameObject projectileInstance = Instantiate(projectile, transform.position, Quaternion.identity);

            projectileInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileMoveDirection.x, projectileMoveDirection.y) * projectileVelocity;
            projectileInstance.GetComponent<Transform>().rotation = Quaternion.Euler(0,0, rotation + 180);

            angle += angleStep;
        }
    }


    IEnumerator sleepBetweenInstances (float delayBetweenProjectiles){
        yield return new WaitForSeconds(delayBetweenProjectiles);
    }
}
