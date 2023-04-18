using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoader : MonoBehaviour
{
    private void OnEnable()
    {
        PlayerPrefs.SetString("introCutscene", "true");
        SceneManager.LoadScene("PrimerNivel", LoadSceneMode.Single);
    }
}
