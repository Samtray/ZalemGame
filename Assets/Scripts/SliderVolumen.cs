using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderVolumen : MonoBehaviour
{
    [SerializeField] AudioSource musicaMenu;
    public Slider sliderMusica;
    public Slider sliderSonidos;
    public float sliderValue;
    private void Start()
    {
        sliderMusica.value = PlayerPrefs.GetFloat("volumenMusica", 0.5f);
        sliderSonidos.value = PlayerPrefs.GetFloat("volumenSonido", 0.5f);
        musicaMenu.volume = sliderMusica.value;
        musicaMenu.Play();
    }

    public void ChangeSliderMusic(float valor) {
        sliderValue = valor;
        PlayerPrefs.SetFloat("volumenMusica", sliderValue);
        musicaMenu.volume = sliderMusica.value;

    }

    public void ChangeSliderSound(float valor)
    {
        sliderValue = valor;
        PlayerPrefs.SetFloat("volumenSonido", sliderValue);
        //musicaMenu.volume = sliderMusica.value;

    }
}
