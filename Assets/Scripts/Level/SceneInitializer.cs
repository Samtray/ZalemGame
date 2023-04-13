using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneInitializer : MonoBehaviour
{
    [SerializeField] AudioSource musicaNivel;
    [SerializeField] GameObject player;

    void Start()
    {
        //PlayerPrefs.DeleteAll();

        musicaNivel.volume = PlayerPrefs.GetFloat("volumenMusica", 0.5f);
        musicaNivel.Play();

        // player position
        var x = PlayerPrefs.GetFloat("x", 163f);
        var y = PlayerPrefs.GetFloat("y", -1f);

        player.transform.position = new Vector3(x, y, 0);
    }
}
