using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneInitializer : MonoBehaviour
{
    [SerializeField] AudioSource musicaNivel;
    [SerializeField] GameObject player;
    [SerializeField] GameObject sounds;

    void Start()
    {
        PlayerPrefs.DeleteAll();

        //Music
        musicaNivel.volume = PlayerPrefs.GetFloat("volumenMusica", 0.5f);
        musicaNivel.Play();

        //Sounds
        foreach (Transform child in sounds.transform)
        {
            child.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("volumenSonido", 0.5f);
        }

        // player position
        var x = PlayerPrefs.GetFloat("x", -2f); //-2
        var y = PlayerPrefs.GetFloat("y", 2f);  //-2
        player.transform.position = new Vector3(x, y, 0);
    }
}
