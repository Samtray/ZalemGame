using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_2 : MonoBehaviour
{
    // there will be three boses. Each boss is a prefab with a set of attacks 
    // Once an attack is done, the object itself is disabled and another one from 
    // the collection is enabled

    public float health;
    public List<GameObject> bossInstances;
    public List<GameObject> bossPositions;
    void Start()
    {
        //DISABLE ALL BOSSES
        disableAllBossInstances();
        //ENABLE ONE
        enableRandomBossInstance();
    }

    // Update is called once per frame
    void Update()
    {
        if(noActiveBosses()){
            enableRandomBossInstance();
        } 
    }

    // get a random index
    private int getRandomIndex(int startingValue,int collectionLength){
        return (int) Random.Range(startingValue, collectionLength);
    }

    // enable a boss instance
    void enableRandomBossInstance(){
        int randomIndex = getRandomIndex(0, bossInstances.Count);
        bossInstances[randomIndex].SetActive(true);
    }

    // disable all bosses
    void disableAllBossInstances(){
        foreach(GameObject boss in bossInstances){boss.SetActive(false);}
    } 

    bool noActiveBosses(){
        foreach(GameObject boss in bossInstances){
            if(!boss.activeSelf){
                return true;
            }
        }
        return false;
    }
}
