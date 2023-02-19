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
    private float h;
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
        giraPlayer(h);
        //aPlayer.SetFloat("VelocidadX", Mathf.Abs(rPlayer.velocity.x));
        //aPlayer.SetFloat("VelocidadY", rPlayer.velocity.y);
        //aPlayer.SetBool("TocarSuelo", colPies);
        // Update para crear el salto basico del personaje
        colPies = CheckGround.colPies;

        if (Input.GetButtonDown("Jump") && colPies) {
            rigidPlayer.velocity = new Vector2(rigidPlayer.velocity.x, 0f);
            rigidPlayer.AddForce(new Vector2(0, fuerzaSalto), ForceMode2D.Impulse);
            
        }

        if (h == 0 && colPies) {
            Vector3 velocidadArreglada = rigidPlayer.velocity;
            velocidadArreglada.x *= friccionSuelo;
            rigidPlayer.velocity = velocidadArreglada;
        }

    }

    private void FixedUpdate()
    {
        h = Input.GetAxisRaw("Horizontal");
        rigidPlayer.AddForce(Vector2.right * velocidadCorrer * h);
        float limiteVelocidad = Mathf.Clamp(rigidPlayer.velocity.x, -velocidadMax, velocidadMax);
        rigidPlayer.velocity = new Vector2(limiteVelocidad, rigidPlayer.velocity.y);
    }   

    public void giraPlayer(float horizontal) {
        if (horizontal > 0 && !miraDerecha || horizontal < 0 && miraDerecha) {
            miraDerecha = !miraDerecha;
            Vector3 escalaGiro = transform.localScale;
            escalaGiro.x = escalaGiro.x * -1;
            transform.localScale = escalaGiro;
        }
    }
}
