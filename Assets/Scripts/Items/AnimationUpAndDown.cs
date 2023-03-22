using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationUpAndDown : MonoBehaviour
{
    public float amplitude;
    public float frequency;
    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
       transform.position = new Vector3(initialPosition.x, Mathf.Sin(Time.time * frequency) * amplitude + initialPosition.y, 0);
    }
}
