using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(1 * Time.deltaTime, 0);
    }
}
