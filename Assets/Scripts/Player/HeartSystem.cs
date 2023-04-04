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

    [SerializeField]
    private GameObject skull_icon; 
    [SerializeField]
    private GameObject knife_icon;

    private SpriteRenderer knifeColor;
    private Color baseKnifeColor;
    private SpriteRenderer skullColor;
    private Color baseSkullColor;
    private bool knifePowerupEnding;
    private bool skullPowerupEnding;

    public void Start()
    {
        knife_icon.SetActive(false);
        skull_icon.SetActive(false);
        PickupAttackSpeed.onPickUpDelegate = toggleActivePowerUpIcon;
        PickupRange.onPickUpDelegate = toggleActivePowerUpIcon;
        HealthManager.onHealthUpdate += InstantiateHearts;
        InstantiateHearts();

        knifeColor = knife_icon.GetComponent<SpriteRenderer>();
        baseKnifeColor = knifeColor.color;

        skullColor = skull_icon.GetComponent<SpriteRenderer>();
        baseSkullColor = skullColor.color;
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

    private void Update()
    {
        if (knifePowerupEnding)
        {
            knifeColor.material.color = Color.Lerp(Color.clear, baseKnifeColor, Mathf.PingPong(Time.time * 15, 1));
        }
        else
        {
            knifeColor.material.color = baseKnifeColor;
        }

        if (skullPowerupEnding)
        {
            skullColor.material.color = Color.Lerp(Color.clear, Color.red, Mathf.PingPong(Time.time * 15, 1));
        }
        else {
            skullColor.material.color = baseSkullColor;
        }
    }

    public override void update(int payload) {
        Debug.Log("Took " + payload + " damage");
    }

    public void toggleActivePowerUpIcon(string powerUpType, bool isActive, bool isEnding){
        if(powerUpType == "Attack_speed"){
            if (isEnding)
            {
                knifePowerupEnding = true;
            }
            else
            {
                knifePowerupEnding = false;
                knife_icon.SetActive(isActive);
            }
        }

        else if(powerUpType == "Range"){
            if (isEnding)
            {
                skullPowerupEnding = true;
            }
            else 
            {
                skullPowerupEnding = false;
                skull_icon.SetActive(isActive);
            }
        }
    }

}
