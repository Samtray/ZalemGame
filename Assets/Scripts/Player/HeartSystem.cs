using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using UnityEngine.Events;

public class HeartSystem : Observer
{
    public HealthManager healthManager;
    public GameObject heartPrefab;
    public List<GameObject> hearts;
    public UnityEvent onPlayerDamage;

    public void Start()
    {
        HealthManager.onHealthUpdate += InstantiateHearts;
        InstantiateHearts();
    }

    private void InstantiateHearts() {

        foreach (GameObject heart in hearts) Destroy(heart);
        hearts.Clear();

        for (int i = 0; i < healthManager.health; i++)
        {

            GameObject heartInstance = Instantiate(heartPrefab, gameObject.transform);
            hearts.Add(heartInstance);
            RenderHearts();

        }
    }

    private void RenderHearts()
    {
        if (hearts.Count > 0)
        {
            //Vector2 heartPosition = heartInstance.transform.position;
            GameObject lastHeartPrefab = hearts.Last();
            RectTransform heartRect = lastHeartPrefab.GetComponent<RectTransform>();
            float heartWidth = heartRect.localScale.x * heartRect.sizeDelta.x;
            heartRect.anchoredPosition = new Vector2((heartRect.anchoredPosition.x + ((heartWidth + 10) * hearts.Count)), heartRect.anchoredPosition.y);
        }
    }

    public override void update(int payload) {
        Debug.Log("Took " + payload + " damage");
    }

}
