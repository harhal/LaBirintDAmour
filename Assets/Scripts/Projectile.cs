using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    [SerializeField]
    private float Velocity;

    [SerializeField]
    private float LifeTime = 1;
        
    [SerializeField]
    private float Damage;

    private Rigidbody2D Body;

	// Use this for initialization
	void Awake ()
    {
        Body = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        LifeTime -= Time.deltaTime;
        if (LifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        var victim = collision.otherCollider.GetComponent<DamageReceiver>();
        if (victim != null)
        {
            victim.ApplyDamage(Damage);
        }
        Destroy(gameObject);
    }

    public void Launch(Vector2 position, Vector2 direction)
    {
        transform.position = position;
        Body.velocity = direction * Velocity;
    }
}
