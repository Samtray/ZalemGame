using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] AudioSource musicaNivel;

    void Start()
    {
        musicaNivel.volume = PlayerPrefs.GetFloat("volumenMusica", 0.5f);
        musicaNivel.Play();
    }
}
