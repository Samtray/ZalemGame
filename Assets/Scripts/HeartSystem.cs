using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeartSystem : MonoBehaviour
{
    public GameObject[] hearts;
    private int life;
    public bool dead = false;
    public bool da�o = false;
    public int sceneBuildIndex;

    public void Start()
    {
        life = hearts.Length;
    }

    void Update()
    {
        if (dead) SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        
        da�o = AplicarDa�o.da�oRecibido;
        Debug.Log(da�o);
        if (da�o) TakeDamage(1);
    }

    public void TakeDamage(int damage) {

        if (life == 0) return;

        if (life >= 1)
        {
            life -= damage;
            Destroy(hearts[life].gameObject);

            if (life < 1)
            {
                dead = true;
            }
        }
    }
}
