using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public bool death = false;
    public AudioSource deathSound;
    private Animator parentAnimator;
    private EnemyPlatformBehavior parentMovement;
    private Collider2D hitbox;

    private void Start()
    {
        parentAnimator = transform.parent.gameObject.GetComponent<Animator>();
        parentMovement = transform.parent.gameObject.GetComponent<EnemyPlatformBehavior>();
        hitbox = GetComponent<Collider2D>();
    }
    void Update()
    {
        if (death) {
            hitbox.enabled = false;
            if (parentMovement.IsFacingRight())
            {
                parentAnimator.SetBool("isDeadRight", true);
            }
            else
            {
                parentAnimator.SetBool("isDeadLeft", true);
            }
        }
    }
}
