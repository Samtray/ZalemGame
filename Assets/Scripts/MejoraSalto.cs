using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MejoraSalto : MonoBehaviour
{
    public float saltoLargo = 0f;
    public float saltoCorto = 0f;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.y < 0) {
            rb.velocity += Vector2.up * Physics2D.gravity.y * saltoLargo * Time.deltaTime;

        }else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * saltoCorto * Time.deltaTime;
        }
    }
}
