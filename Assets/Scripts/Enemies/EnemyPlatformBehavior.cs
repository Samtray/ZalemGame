using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlatformBehavior : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    Rigidbody2D rigidEnemy;
    BoxCollider2D colliderEnemy;
    // Start is called before the first frame update
    void Start()
    {
        rigidEnemy = GetComponent<Rigidbody2D>();
        colliderEnemy = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsFacingRight())
        {
            //Move right
            rigidEnemy.velocity = new Vector2(moveSpeed, 0f);
        }
        else {
            rigidEnemy.velocity = new Vector2(-moveSpeed, 0f);
        }
    }

    private bool IsFacingRight() {
        return transform.localScale.x > Mathf.Epsilon;
    }

    private void OnTriggerExit2D(Collider2D collision) {
        //Turn
        if (collision.gameObject.CompareTag("Player")) return;
        if (collision.gameObject.CompareTag("Demonio")) return;
        if (collision.gameObject.CompareTag("Bullet")) return;

        transform.localScale = new Vector2(
            -(Mathf.Sign(rigidEnemy.velocity.x)), 
            transform.localScale.y);
    }
}
