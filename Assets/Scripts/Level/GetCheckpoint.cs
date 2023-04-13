using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCheckpoint : MonoBehaviour
{
    public GameObject player;
    public GameObject flag;

    private void Start()
    {
        if (PlayerPrefs.GetString("CurrentCheckpoint") == flag.name) {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")){
            PlayerPrefs.SetString("CurrentCheckpoint", flag.name);
            PlayerPrefs.SetFloat("x", player.transform.position.x);
            PlayerPrefs.SetFloat("y", player.transform.position.y);
            Destroy(gameObject);
        }
    }
}
