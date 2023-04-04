using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManager : Subject
{
    public int health;
    private int initialHealth; 
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

    public delegate void onUpdate(); 
    public static onUpdate onHealthUpdate;
    private bool exploded;
    private bool explosionDirection;
    public float disabledSeconds;

    //[SerializeField]
    //private HeartSystem healthUIObserver;

    void Start()
    {
        initialHealth = 3;
        invincible = false;
        health = initialHealth;
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
            spriteComponent.material.color = Color.Lerp(Color.clear, baseColor, Mathf.PingPong(Time.time * speed, 1));
        }
        else {
            spriteComponent.material.color = baseColor;
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
            onHealthUpdate.Invoke();
        }
    }

    public void GainHealth(int healthAmount) {

        health += healthAmount;
        onHealthUpdate.Invoke();
    }

    public void TakeDamage(int damage){
        
        if (!invincible){
            victimRigidbody.velocity = new Vector2(0, 0);
            health -= damage;
            StartCoroutine(SetInvincibilityFrames(invincibilityDuration));
            StartCoroutine(DisablePlayerController(disabledSeconds));
            StartCoroutine(ToggleDamagedEffect(damagedSeconds));
            //notify(damage);
            onHealthUpdate.Invoke();
        }
    }

    public void InstaKill() {
        health = 0;
    }

    public void ToggleInvincibility(){
        invincible = !invincible;
        //Debug.Log("setting invincibility to " + invincible.ToString());
    }

    public IEnumerator DisablePlayerController(float disabledDuration)
    {
        gameObject.GetComponent<PlayerController>().enabled = false;
        yield return new WaitForSeconds(disabledDuration);
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
