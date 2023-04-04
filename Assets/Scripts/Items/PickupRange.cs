using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupRange : MonoBehaviour
{
    public GameObject player;
    public int durationSeconds;
    public int modifiedRange;

      public delegate void onPickUpRange(string pickUpType, bool isActive, bool isEnding); 
    public static onPickUpRange onPickUpDelegate;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        CheckRangeCollision(collision);
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        Collider2D collider = GetComponent<Collider2D>();
        sprite.enabled = false;
        collider.enabled = false;
    }

    private void CheckRangeCollision(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(ToggleRangeDistance(durationSeconds));
        }
    }


    public IEnumerator ToggleRangeDistance(int duration)
    {
        int animation = 1;
        duration -= animation;

        onPickUpDelegate.Invoke("Range", true, false);
        player.GetComponent<PlayerController>().radius = modifiedRange;

        yield return new WaitForSeconds(duration);
        onPickUpDelegate.Invoke("Range", true, true);

        yield return new WaitForSeconds(animation);
        player.GetComponent<PlayerController>().radius = 1;
        Destroy(gameObject);
        onPickUpDelegate.Invoke("Range", false, false);
    }
}
