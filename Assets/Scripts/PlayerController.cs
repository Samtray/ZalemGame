using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocidadCorrer;
    public float velocidadMax;
    public float fuerzaSalto;
    public bool terrenoCheck = false;
    private bool platformCheck = false;
    public float friccionSuelo;

    private Rigidbody2D rigidPlayer;
    private Animator animator;
    private float horizontalInput;
    public static bool miraDerecha = false;
    public GameObject attackPoint;
    public float radius;
    public LayerMask enemies;
    // Start is called before the first frame update
    void Start()
    {
        rigidPlayer = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        giraPlayer(0);
        miraDerecha = false;
    }

    // Update is called once per frame
    void Update()
    {

        giraPlayer(horizontalInput);
        terrenoCheck = CheckGround.terreno;
        platformCheck = CheckGround.platform;

        animator.SetFloat("VelocidadX", Mathf.Abs(rigidPlayer.velocity.x));
        animator.SetFloat("VelocidadY", rigidPlayer.velocity.y);
        animator.SetBool("TocarSuelo", terrenoCheck);
        animator.SetBool("TocarPlataforma",  platformCheck);


        if (Input.GetButtonDown("Jump") && (terrenoCheck || platformCheck)) {
            jump();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            animator.SetBool("Ataque", true);
        }


    }

    private void FixedUpdate()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        moveCharacter(horizontalInput);
    }   

    public void giraPlayer(float horizontal) {
        if (horizontal > 0 && miraDerecha || horizontal < 0 && !miraDerecha) {
            miraDerecha = !miraDerecha;
            Vector3 escalaGiro = transform.localScale;
            escalaGiro.x = escalaGiro.x * -1;
            transform.localScale = escalaGiro;
        }
    }


    private void jump(){
        rigidPlayer.velocity = new Vector2(rigidPlayer.velocity.x, fuerzaSalto);
    }

    private void moveCharacter(float horizontalInput){
        rigidPlayer.velocity = new Vector2(horizontalInput * velocidadCorrer, rigidPlayer.velocity.y);
    }

    public void EndAttackAnimation() { 
        animator.SetBool("Ataque", false);
    }

    public void Attack()
    {
        Collider2D[] enemy = Physics2D.OverlapCircleAll(attackPoint.transform.position, radius, enemies);

        foreach (Collider2D enemyGameEnemy in enemy)
        {
            Debug.Log("Enemy Hit");
            enemyGameEnemy.GetComponent<EnemyDeath>().death = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.transform.position, radius);
    }
}
