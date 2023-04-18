using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoader : MonoBehaviour
{
    private void OnEnable()
    {
        SceneManager.LoadScene("PrimerNivel", LoadSceneMode.Single);
    }
}
