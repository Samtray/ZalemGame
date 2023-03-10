using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerAndExplode : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;

    private Transform target;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    public DamageManager damageManager;
    private bool isPlayerInRange = false;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        animator = GetComponent<Animator>();
    }

    public void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }

    void Update()
    {

        spriteRenderer.flipX = target.transform.position.x < transform.position.x;
        var targetPosition = new Vector2(target.position.x, transform.position.y);

        if (isPlayerInRange) {
            CalculateDistance(targetPosition);
        }

    }

    public void CalculateDistance(Vector2 targetPosition) {
        var stopMovementValue = 999f;

        if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
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

        var reachDistance = 2;
        var damage = 2;

        if (Vector2.Distance(transform.position, target.position) < reachDistance){
            damageManager.takeDamage(damage);
        }
    }

    void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
