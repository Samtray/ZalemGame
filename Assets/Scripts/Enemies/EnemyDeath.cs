using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public bool death = false;
    void Update()
    {
        if (death) {
            Destroy(transform.parent.gameObject);
        }
    }
}
