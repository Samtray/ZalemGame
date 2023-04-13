using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class HiddenZone : MonoBehaviour
{

    [SerializeField] Tilemap secreto;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            StartCoroutine(nameof(Show));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(nameof(Hide));
        }
    }

    IEnumerator Show() {
        for (float f = 1; f >= 0; f -= 0.02f) {
            Color color = secreto.color;
            color.a = f;
            secreto.color = color;
            yield return (0.05f);
        }
    }
    IEnumerator Hide()
    {
        for (float f = 0f; f <= 1; f += 0.02f)
        {
            Color color = secreto.color;
            color.a = f;
            secreto.color = color;
            yield return (0.05f);
        }
    }
}
