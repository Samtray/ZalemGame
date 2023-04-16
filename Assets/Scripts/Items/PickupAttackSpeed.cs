using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupAttackSpeed : MonoBehaviour
{
    public GameObject player;
    public int durationSeconds;
    public float modifiedSpeed;
    public AudioSource pickupSound;

    public delegate void onPickUpAttackSpeed(string pickUpType, bool isActive, bool isEnding);
    public static onPickUpAttackSpeed onPickUpDelegate;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            StartCoroutine(ToggleAttackSpeed(durationSeconds));
            pickupSound.Play();
            SpriteRenderer sprite = GetComponent<SpriteRenderer>();
            Collider2D collider = GetComponent<Collider2D>();
            sprite.enabled = false;
            collider.enabled = false;
        }

            
    }


    public IEnumerator ToggleAttackSpeed(int duration)
    {
        int animation = 1;
        duration -= animation;

        var playerAnimator = player.GetComponent<PlayerController>().animator;

        onPickUpDelegate.Invoke("Attack_speed", true, false);
        playerAnimator.SetFloat("VelocidadDeAtaque", modifiedSpeed);

        yield return new WaitForSeconds(duration);
        onPickUpDelegate.Invoke("Attack_speed", true, true);

        yield return new WaitForSeconds(animation);
        playerAnimator.SetFloat("VelocidadDeAtaque", 1);
        onPickUpDelegate.Invoke("Attack_speed", false, false);

        Destroy(gameObject);
    }
}
