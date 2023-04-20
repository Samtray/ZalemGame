using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [Header("Opciones Generales")]
    [SerializeField] int volumenMusica;
    [SerializeField] int volumenSonido;
    [SerializeField] GameObject pantallaMenu;
    [SerializeField] GameObject pantallaOpciones;
    [SerializeField] float tiempoCambiaOpcion;

    [Header("Elementos de Menu")]
    [SerializeField] SpriteRenderer comenzar;
    [SerializeField] SpriteRenderer opciones;
    [SerializeField] SpriteRenderer salir;

    [Header("Sprites de Menu")]
    [SerializeField] Sprite comenzar_off;
    [SerializeField] Sprite comenzar_on;
    [SerializeField] Sprite opciones_off;
    [SerializeField] Sprite opciones_on;
    [SerializeField] Sprite salir_off;
    [SerializeField] Sprite salir_on;

    [Header("Sonido")]
    [SerializeField] AudioSource musicaMenu;

    [SerializeField] AudioSource sonido_opcion;
    [SerializeField] AudioSource sonido_seleccion;

    int pantalla;
    int opcionMenu, opcionMenuAnterior;
    int opcionOpciones, opcionOpcionAnterior;
    bool submitPulsado;
    float vertical, horizontal;
    float tiempoVertical, tiempoHorizontal;

    void Awake()
    {
        pantalla = 0;
        tiempoVertical = tiempoHorizontal = 0;
        opcionMenu = opcionMenuAnterior = 1;
        opcionOpciones = opcionOpcionAnterior = 1;
        PlayerPrefs.DeleteAll();
    }


    void Update()
    {
        vertical = Input.GetAxisRaw("Vertical");
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonUp("Submit")) submitPulsado = false;
        if (vertical == 0) tiempoVertical = 0;
        if (pantalla == 0) MenuPrincipal();
        if (pantalla == 1) MenuOpciones();
    }

    void MenuPrincipal()
    {
        if (vertical != 0)
        {
            if (tiempoVertical == 0 || tiempoVertical > tiempoCambiaOpcion)
            {
                if (vertical >0 && opcionMenu > 1) SeleccionaMenu(opcionMenu - 1);
                if (vertical <0 && opcionMenu < 3) SeleccionaMenu(opcionMenu + 1);
                if (tiempoVertical > tiempoCambiaOpcion) tiempoVertical = 0;
            }

            tiempoVertical += Time.deltaTime;
        }

        if (Input.GetButtonDown("Submit") && !submitPulsado)
        {
            if (opcionMenu == 1)
            {
                if (PlayerPrefs.GetString("introCutscene", "false") == "false")
                {
                    SceneManager.LoadScene("Cutscene", LoadSceneMode.Single);
                }
                else
                {
                    SceneManager.LoadScene("PrimerNivel", LoadSceneMode.Single);
                }
            }
            if (opcionMenu == 2) CargaPantallaOpciones();
            if (opcionMenu == 3) Application.Quit();
        }
    }

    void MenuOpciones()
    {
        if (Input.GetButtonDown("Submit") && !submitPulsado) CargaPantallaMenu();
    }

    void CargaPantallaMenu()
    {
        submitPulsado = true;
        pantalla = 0;
        pantallaOpciones.SetActive(false);
        pantallaMenu.SetActive(true);
    }

    void CargaPantallaOpciones()
    {
        submitPulsado = true;
        pantallaMenu.SetActive(false);
        pantalla = 1;
        opcionOpciones = opcionOpciones = 1;
        pantallaOpciones.SetActive(true);
        pantallaMenu.SetActive(false);
    }

    void SeleccionaMenu(int opcion)
    {
        //sonido_opcion.Play();
        opcionMenu = opcion;
        if (opcion == 1) comenzar.sprite = comenzar_on;
        if (opcion == 2) opciones.sprite = opciones_on;
        if (opcion == 3) salir.sprite = salir_on;
        if (opcionMenuAnterior == 1) comenzar.sprite = comenzar_off;
        if (opcionMenuAnterior == 2) opciones.sprite = opciones_off;
        if (opcionMenuAnterior == 3) salir.sprite = salir_off;
        opcionMenuAnterior = opcion;
    }
}
