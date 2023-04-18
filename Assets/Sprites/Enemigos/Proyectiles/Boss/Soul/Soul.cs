using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soul : Projectile
{
    SpriteRenderer soulSpriteRenderer;
    [SerializeField] float amplitude; 
    [SerializeField] float crest; 
    [SerializeField] float projectileSpeed; 
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        soulSpriteRenderer = GetComponent<SpriteRenderer>();

        if(transform.parent != null){
            transform.position = transform.parent.position;
        }
    }

    // Update is called once per frame
    protected override void Update()
    {
        projectileRigidBody.velocity = new Vector2(projectileSpeed, Mathf.Sin(Time.time * amplitude) * crest);
        
        if(projectileRigidBody.velocity.y > 0){
            soulSpriteRenderer.color = Color.gray;
        } 
        else{
            soulSpriteRenderer.color = Color.white;
        }
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }
}
