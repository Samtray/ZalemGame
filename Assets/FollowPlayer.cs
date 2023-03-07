using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;

    private Transform target;
    private bool isLookingRight = false;
    private bool isLookingLeft = true;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per 
    void Update()
    {
        var targetPosition = new Vector2(target.position.x, transform.position.y);

        if (Vector2.Distance(transform.position, target.position) > stoppingDistance) {
            transform.position = Vector2.MoveTowards(
                transform.position, 
                targetPosition, 
                speed * Time.deltaTime);
        }

        GiraEnemigo();
    }

    public void GiraEnemigo()
    {   
        if (PlayerController.miraDerecha && !isLookingLeft)
        {
            FlipFlags();
            ApplyTransform();

        } else if (PlayerController.miraDerecha && !isLookingRight) {

            FlipFlags();
            ApplyTransform();

        }
    }

    private void FlipFlags() {
        isLookingLeft = !isLookingLeft;
        isLookingRight = !isLookingRight;
    }

    private void ApplyTransform() {
        Vector3 escalaGiro = transform.localScale;
        escalaGiro.x *= -1;
        transform.localScale = escalaGiro;
    }
}