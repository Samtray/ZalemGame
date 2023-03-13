using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPosition;

    private float timer;
    private GameObject player;
    public int attackDistance;
    private Transform target;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {

        float distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance > attackDistance) return;
        
        timer += Time.deltaTime;

        if (timer > 2) {
            timer = 0;
            Shoot();
        }
    }

    void Shoot() {
        Instantiate(bullet, bulletPosition.position, Quaternion.identity);
    }
}
