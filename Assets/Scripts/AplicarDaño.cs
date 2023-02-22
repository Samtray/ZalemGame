using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AplicarDaño : MonoBehaviour
{

    public static bool dañoRecibido;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Demonio") {
            Debug.Log("Colisioné");
            dañoRecibido = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Demonio") { 
            Debug.Log("Descolisioné");

            dañoRecibido = false; }
    }
}
