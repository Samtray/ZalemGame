using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using UnityEngine.Events;

public class HeartSystem : Observer
{
    public DamageManager damageManager;
    public GameObject heartPrefab; 
    public List<GameObject> hearts;
    public UnityEvent onPlayerDamage;

    public void Start()
    {
        DamageManager.onDamageDelegate += removeLastHeart;

        for (int i = 0; i < damageManager.health; i++){

            GameObject heartInstance = Instantiate(heartPrefab, gameObject.transform);
            hearts.Add(heartInstance);
            
            if(hearts.Count > 0){

                Vector2 heartPosition = heartInstance.transform.position;
                GameObject lastHeartPrefab = hearts.Last(); 
                RectTransform heartRect = lastHeartPrefab.GetComponent<RectTransform>();
                float heartWidth = heartRect.localScale.x * heartRect.sizeDelta.x;

                heartRect.anchoredPosition = new Vector2((heartRect.anchoredPosition.x + ((heartWidth + 10) * hearts.Count)), heartRect.anchoredPosition.y);                
            }
        }
    }

    public void removeLastHeart(){
        if (hearts.Count > 0){
            Destroy(hearts[hearts.Count - 1]);
            hearts.RemoveAt(hearts.Count - 1);
        }
    }

    public override void update(int payload) {
        Debug.Log("Took " + payload + " damage");
    }

}
