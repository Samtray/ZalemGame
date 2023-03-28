using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderVolumen : MonoBehaviour
{
    [SerializeField] AudioSource musicaMenu;
    public Slider sliderMusica;
    public float sliderValue;
    private void Start()
    {
        sliderMusica.value = PlayerPrefs.GetFloat("volumenMusica", 0.5f);
        musicaMenu.volume = sliderMusica.value;
        musicaMenu.Play();
    }

    public void ChangeSlider(float valor) {
        sliderValue = valor;
        PlayerPrefs.SetFloat("volumenMusica", sliderValue);
        musicaMenu.volume = sliderMusica.value;

    }
}
