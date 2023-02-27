using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DamageManager : MonoBehaviour
{
    public int health;
    public int maxHealth = 3; 
    private int sceneBuildIndex;
    private Rigidbody2D victimRigidbody;
    public Vector2 damageTakenForce;
    public int invincibilityDuration;
    private bool invincible; 
    private SpriteRenderer spriteComponent;
    void Start()
    {
        invincible = false;
        health = maxHealth;
        victimRigidbody = gameObject.GetComponent<Rigidbody2D>();
        spriteComponent = gameObject.GetComponent<SpriteRenderer>();
    }

    public void takeDamage(int damage){
        if(health == 0){
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }
        else if (!invincible){
            health -= damage;
            victimRigidbody.AddForce(damageTakenForce);
            StartCoroutine(setInvincibilityFrames(invincibilityDuration));
        }
    }

    public void toggleInvincibility(){
        invincible = !invincible;
        Debug.Log("setting invincibility to " + invincible.ToString());
    }

    public IEnumerator setInvincibilityFrames(int invincibilityDuration){
        toggleInvincibility();
        yield return new WaitForSeconds(invincibilityDuration);
        toggleInvincibility();
    }
}
