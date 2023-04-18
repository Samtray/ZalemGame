using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private Stage stage;
    public Stage Stage {get => stage; set{stage = value;}}
    public List<Attack> attacks;
    //public List<Attack> Attacks{get => attacks; set{attacks = value;}}
    private float enemyDelayBetweenAttacks;
    public float EnemyDelayBetweenAttacks{get; set;}
    private float health;
    // Used to prevent duplicate state transitions on the Update method
    float lastStageTransitionHealthValue;
    private bool isAttacking;
    public SpriteRenderer bossSpriteRenderer;

    public List<GameObject> teleportLocations;
    public GameObject flyingBulletLocation;

    private void Start() {
        // Set First stage
        this.bossSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        this.attacks = new List<Attack>();
        this.health = 100f;
        this.lastStageTransitionHealthValue = 0f;
        this.stage = Stage1.Instance();
        this.stage.enter(this);

        teleportToRandomLocation();
        StartCoroutine(damageSleep());
    }
    


    private void FixedUpdate() {
        transform.position = Vector2.MoveTowards(transform.position, flyingBulletLocation.GetComponent<Transform>().position, 0.05f);
    }


    private void Update() {
        if (health < 100 && (health % 50 == 0) && lastStageTransitionHealthValue != health){
            // This is the last value that caused a stage transition
            lastStageTransitionHealthValue = health;
            
            // If the temporary health is equal from the current boss health
            // then the state transition is ommited.  
            // This validation is done once a frame.
            // Since the validation so often, the transition may trigger multiple times if the health is the same for more 
            // than one frame.
            setAndInitNextStage();
        }

        if (health == 0){
            StopCoroutine(damageSleep());
            Debug.Log("Dead");
            Destroy(gameObject);
        }
        
        if(!isAttacking){
            executeAttack();
        }
    }

    private void setAndInitNextStage(){
        // Set the next stage when health gets to a set amount
        this.stage.next(this);
        // Init next stage
        this.stage.enter(this);
    }

    private void executeAttack(){
        int attackIndex = getRandomAttackIndex();
        // Attack using the random index
        attacks[attackIndex].attack();
        StartCoroutine(SleepBetweenAttacks());
    }

    private int getRandomAttackIndex(){
        // Get a random integer from the attacks array
        return getRandomIndex(0, attacks.Count);
    }

    private IEnumerator SleepBetweenAttacks(){
        isAttacking = true;
        yield return new WaitForSeconds(this.enemyDelayBetweenAttacks);
        isAttacking = false;
    }

    private IEnumerator damageSleep(){
        while(health > 0){   
            health -= 5;
            yield return new WaitForSeconds(1.0f);
            Debug.Log("Health " + health.ToString());   
        }
    }

    private int getRandomIndex(int startingValue,int collectionLength){
        return (int) Random.Range(startingValue, collectionLength);
    }

    private void teleportToRandomLocation(){
        int teleportIndex = getRandomIndex(0, teleportLocations.Count);
        transform.Translate(teleportLocations[teleportIndex].GetComponent<Renderer>().bounds.center);
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.blue;

        foreach(GameObject teleSpot in teleportLocations){
            Gizmos.DrawLine(transform.position, teleSpot.GetComponent<Transform>().position);
        }

        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, flyingBulletLocation.GetComponent<Transform>().position);

    }

}
