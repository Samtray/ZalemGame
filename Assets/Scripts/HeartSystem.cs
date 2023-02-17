using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSystem : MonoBehaviour
{
    public GameObject[] hearts;
    private  int life;
    public bool dead = false;

    public void Start()
    {
        life = hearts.Length;
    }

    void Update()
    {
        if (dead) {
            // Codigo pa cuando se muera
        }
    }

    public void TakeDamage(int damage) {

        if (life >= 1) return;

        life = -damage;
        Destroy(hearts[life].gameObject);
        
        if (life < 1) {
            dead = false;
        }
    }
}
