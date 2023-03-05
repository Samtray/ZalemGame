using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocidadCorrer;
    public float velocidadMax;
    public float fuerzaSalto;
    public bool colPies = false;
    public float friccionSuelo;

    private Rigidbody2D rigidPlayer;
    private Animator animator;
    private float horizontalInput;
    private bool miraDerecha = true;
    private string currentAnimaton;
    private bool isJumpPressed;
    const string PLAYER_IDLE = "Idle";
    const string PLAYER_WALK = "Caminar";
    const string PLAYER_JUMP = "Salto";

    // Start is called before the first frame update
    void Start()
    {
        rigidPlayer = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("VelocidadX", Mathf.Abs(rigidPlayer.velocity.x));
        animator.SetFloat("VelocidadY", rigidPlayer.velocity.y);
        animator.SetBool("TocarSuelo", colPies);

        giraPlayer(horizontalInput);
        colPies = CheckGround.colPies;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumpPressed = true;
        }

        if (Input.GetButtonDown("Jump") && colPies) {
            jump();
        }
    }

    private void FixedUpdate()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        moveCharacter(horizontalInput);
    }   

    public void giraPlayer(float horizontal) {
        if (horizontal > 0 && !miraDerecha || horizontal < 0 && miraDerecha) {
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

    void ChangeAnimationState(string newAnimation)
    {
        if (currentAnimaton == newAnimation) return;

        animator.Play(newAnimation);
        currentAnimaton = newAnimation;
    }
}
