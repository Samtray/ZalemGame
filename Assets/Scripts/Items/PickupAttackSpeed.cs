using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupAttackSpeed : MonoBehaviour
{
    public GameObject player;
    public int durationSeconds;
    public float modifiedSpeed;

    public delegate void onPickUpAttackSpeed(string pickUpType, bool isActive); 
    public static onPickUpAttackSpeed onPickUpDelegate;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        CheckSpeedCollision(collision);
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        Collider2D collider = GetComponent<Collider2D>();
        sprite.enabled = false;
        collider.enabled = false;
    }

    private void CheckSpeedCollision(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(ToggleAttackSpeed(durationSeconds));
        }
    }


    public IEnumerator ToggleAttackSpeed(int duration)
    {
        var playerAnimator = player.GetComponent<PlayerController>().animator;

        onPickUpDelegate.Invoke("Attack_speed", true);
        playerAnimator.SetFloat("VelocidadDeAtaque", modifiedSpeed);
        yield return new WaitForSeconds(duration);
        playerAnimator.SetFloat("VelocidadDeAtaque", 1);
        onPickUpDelegate.Invoke("Attack_speed", false);

        Destroy(gameObject);
    }
}
