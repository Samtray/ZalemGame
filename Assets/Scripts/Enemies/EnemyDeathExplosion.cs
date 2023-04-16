using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathExplosion : MonoBehaviour
{
    public bool death = false;
    public AudioSource deathSound;
    private Animator animator;
    public FollowPlayerAndExplode explosionMovement;
    private Collider2D hitbox;

    private void Start()
    {
        animator = transform.GetComponent<Animator>();
        explosionMovement = transform.GetComponent<FollowPlayerAndExplode>();
        hitbox = GetComponent<Collider2D>();
    }
    void Update()
    {
        if (death && !explosionMovement.isExploding)
        {
            hitbox.enabled = false;
            animator.SetBool("isDead", true);
        }
    }
}
