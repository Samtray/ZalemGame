using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reintentar : MonoBehaviour
{
    [Header("Elementos de Menu")]
    [SerializeField] SpriteRenderer reintentar;
    [SerializeField] SpriteRenderer salir;

    [Header("Sprites de Menu")]
    [SerializeField] Sprite reintentar_off;
    [SerializeField] Sprite reintentar_on;
    [SerializeField] Sprite salir_off;
    [SerializeField] Sprite salir_on;
    private bool selection = false;

    void Update()
    {

        if (Direction() == 1)
        {
            reintentar.sprite = reintentar_off;
            salir.sprite = salir_on;
            selection = false;
        }
        else if (Direction() == -1) {
            reintentar.sprite = reintentar_on;
            salir.sprite = salir_off;
            selection = true;
        }

        if (Input.GetButtonDown("Submit")) {
            if (selection)
            {
                SceneManager.LoadScene("PrimerNivel");
            }
            else {
                Application.Quit();
            }
        }
    }


    public float Direction() { 
        return Input.GetAxisRaw("Horizontal");
    }
}
