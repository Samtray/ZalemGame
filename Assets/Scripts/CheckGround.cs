using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{

    public static bool terreno;
    public static bool platform;


    private void Start()
    {
        terreno = false;
        platform = false;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Terreno")) terreno = true;
        if (collision.gameObject.CompareTag("Platform")) platform = true;
    }

    private void OnTriggerExit2D(Collider2D collision){
        if (collision.gameObject.CompareTag("Terreno")) terreno = false;
        if (collision.gameObject.CompareTag("Platform")) platform = false;
    }

}
