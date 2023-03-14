using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DamageManager : MonoBehaviour
{
    public int health;
    public int maxHealth; 
    private Rigidbody2D victimRigidbody;
    public Vector2 damageTakenForce;
    public float invincibilityDuration;
    private bool invincible; 
    private SpriteRenderer spriteComponent;
    public float speed;
    private Color baseColor;
    private bool damaged;
    public float damagedSeconds;
    public static Vector2 collision2DPosition;

    public delegate void onDamage(); 
    public static onDamage onDamageDelegate; 
    void Start()
    {
        maxHealth = 3;
        invincible = false;
        health = maxHealth;
        victimRigidbody = gameObject.GetComponent<Rigidbody2D>();
        spriteComponent = gameObject.GetComponent<SpriteRenderer>();
        baseColor = spriteComponent.color;
    }

    private void Update()
    {


        if (health == 0)
        {
            SceneManager.LoadScene("Moriste");
        }

        if (invincible)
        {
            spriteComponent.color = Color.Lerp(Color.clear, baseColor, Mathf.PingPong(Time.time * speed, 1));
        }
        else {
            spriteComponent.color = baseColor;
        }

    }

    private void FixedUpdate() {
        if(damaged){
            //Debug.Log(transform.position.x - collision2DPosition.x);
            victimRigidbody.AddForce(damageTakenForce * ((transform.position.x - collision2DPosition.x < 0)? -1 : 1) , ForceMode2D.Impulse);
        }
    }

    public void TakeDamage(int damage){
        
        if (!invincible){
            health -= damage;
            StartCoroutine(SetInvincibilityFrames(invincibilityDuration));
            StartCoroutine(ToggleDamagedEffect(damagedSeconds));
            onDamageDelegate.Invoke();
        }
    }

    public void InstaKill() {
        health = 0;
    }

    public void ToggleInvincibility(){
        invincible = !invincible;
        Debug.Log("setting invincibility to " + invincible.ToString());
    }

    public IEnumerator SetInvincibilityFrames(float invincibilityDuration){
        ToggleInvincibility();
        yield return new WaitForSeconds(invincibilityDuration);
        ToggleInvincibility();
    }

    public IEnumerator ToggleDamagedEffect(float damagedSeconds){
        damaged = true; 
        yield return new WaitForSeconds(damagedSeconds);
        damaged = false;
    }
}
