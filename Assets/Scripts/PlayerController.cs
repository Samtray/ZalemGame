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
    private Animator animatorPlayer;
    private float horizontalInput;
    private bool miraDerecha = true;
    // Start is called before the first frame update
    void Start()
    {
        rigidPlayer = GetComponent<Rigidbody2D>();
        //aPlayer = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        giraPlayer(horizontalInput);
        //aPlayer.SetFloat("VelocidadX", Mathf.Abs(rPlayer.velocity.x));
        //aPlayer.SetFloat("VelocidadY", rPlayer.velocity.y);
        //aPlayer.SetBool("TocarSuelo", colPies);
        // Update para crear el salto basico del personaje
        colPies = CheckGround.colPies;

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
}
