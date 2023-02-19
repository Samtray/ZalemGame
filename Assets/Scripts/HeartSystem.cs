using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeartSystem : MonoBehaviour
{
    public GameObject[] hearts;
    private  int life;
    public bool dead = false;
    public int sceneBuildIndex;

    public void Start()
    {
        life = hearts.Length;
    }

    void Update()
    {
        if (dead) {
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }
    }

    public void TakeDamage(int damage) {

        if (life >= 1) return;

        life = -damage;
        Destroy(hearts[life].gameObject);
        
        if (life < 1) {
            dead = false;
        }
    }
}
