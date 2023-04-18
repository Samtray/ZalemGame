using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireballSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject projectile; 
    [SerializeField] private float delayBetweenProjectiles;
    [SerializeField] private float maxBulletAmount;
    private float lastAttackedAt; 
    private float currentBulletCount;
    void Start()
    {
        lastAttackedAt = -999f;
        gameObject.SetActive(true);
        currentBulletCount = 0;

    }

    private void OnEnable() {
        Start();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > lastAttackedAt + delayBetweenProjectiles){
            Instantiate(projectile, transform.position, transform.rotation);
            lastAttackedAt = Time.time;
            //update amount bullets fired
            currentBulletCount++;
        }
        else if(currentBulletCount >= maxBulletAmount){
            gameObject.SetActive(false);
        }
    }
}