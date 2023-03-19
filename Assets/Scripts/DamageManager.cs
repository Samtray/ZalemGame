using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DamageManager : Subject
{
    public int health;
    private int maxHealth; 
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
    private bool exploded;
    private bool explosionDirection;
    public float disabledSeconds;

    //[SerializeField]
    //private HeartSystem healthUIObserver;

    void Start()
    {
        maxHealth = 3;
        invincible = false;
        health = maxHealth;
        victimRigidbody = gameObject.GetComponent<Rigidbody2D>();
        spriteComponent = gameObject.GetComponent<SpriteRenderer>();
        baseColor = spriteComponent.color;

        //attach(healthUIObserver);
        //Debug.Log("Attached " + healthUIObserver.ToString());
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

        if (damaged){
            victimRigidbody.AddForce(damageTakenForce * ((transform.position.x - collision2DPosition.x < 0)? -1 : 1) , ForceMode2D.Impulse);
        }

        if (exploded && explosionDirection)
        {
            victimRigidbody.AddForce(damageTakenForce * -1, ForceMode2D.Impulse);
        }
        else if (exploded && !explosionDirection) { 
            victimRigidbody.AddForce(damageTakenForce * 1, ForceMode2D.Impulse);
        }
    }

    public void TakeDamageByExplosion(int damage, bool direction) {
        if (!invincible)
        {
            explosionDirection = direction;
            health -= damage;
            StartCoroutine(SetInvincibilityFrames(invincibilityDuration));
            StartCoroutine(ToggleDamagedEffectExplosion(damagedSeconds));
            onDamageDelegate.Invoke();
        }
    }

    public void TakeDamage(int damage){
        
        if (!invincible){
            victimRigidbody.velocity = new Vector2(0, 0);
            health -= damage;
            StartCoroutine(SetInvincibilityFrames(invincibilityDuration));
            StartCoroutine(basura(disabledSeconds));
            StartCoroutine(ToggleDamagedEffect(damagedSeconds));
            //notify(damage);
            onDamageDelegate.Invoke();
        }
    }

    public void InstaKill() {
        health = 0;
    }

    public void ToggleInvincibility(){
        invincible = !invincible;
        //Debug.Log("setting invincibility to " + invincible.ToString());
    }

    public IEnumerator basura(float caca)
    {
        gameObject.GetComponent<PlayerController>().enabled = false;
        yield return new WaitForSeconds(caca);
        gameObject.GetComponent<PlayerController>().enabled = true; 
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

    public IEnumerator ToggleDamagedEffectExplosion(float damagedSeconds)
    {
        exploded = true;
        yield return new WaitForSeconds(damagedSeconds);
        exploded = false;
    }
}
