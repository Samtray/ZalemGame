using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerAndExplode : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;

    private Transform target;
    private Animator animator;
    private Rigidbody2D rigidEnemy;
    private SpriteRenderer spriteRenderer;
    public DamageManager damageManager;
    public float reachDistance;
    public int damage;
    private bool canMove = true;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        animator = GetComponent<Animator>();
        rigidEnemy = GetComponent<Rigidbody2D>();
    }

    public void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Vector3 escalaGiro = transform.localScale;

        if (target.transform.position.x < transform.position.x)
        {
            escalaGiro.x = 1;
        }
        else { 
            escalaGiro.x = -1;

        }

        transform.localScale = escalaGiro;

        var targetPosition = new Vector2(target.position.x, transform.position.y);
        int followLimit = 8;
        float distanceBetweenPlayerAndEnemy = Vector2.Distance(transform.position, target.transform.position);

        if (distanceBetweenPlayerAndEnemy < followLimit) {
            CalculateDistance(targetPosition);
        }

    }

    public void CalculateDistance(Vector2 targetPosition) {
        var stopMovementValue = 999f;


        if ((Vector2.Distance(transform.position, target.position) > stoppingDistance) && canMove)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                targetPosition,
                speed * Time.deltaTime
            );
        }
        else
        {
            stoppingDistance = stopMovementValue;
            animator.SetBool("Explosion", true);
            StartCoroutine(SetAnimation());
            StartCoroutine(ExplodeEnemy());

        }
    }

    public IEnumerator ExplodeEnemy() {
        var animationTime = 1;
        yield return new WaitForSeconds(animationTime);
        DestroyGameObject();
    }

    public IEnumerator SetAnimation() {
        var explosionWindow = 0.75f;
        yield return new WaitForSeconds(explosionWindow);
        CheckForDamage();
    }

    void CheckForDamage() {


        if (Vector2.Distance(transform.position, target.position) < reachDistance) {
            damageManager.TakeDamage(damage);
        }
    }

    void DestroyGameObject()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Terreno")){
            canMove = false;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canMove = true;
    }
}
