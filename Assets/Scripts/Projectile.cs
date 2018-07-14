using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    [SerializeField]
    protected float Velocity;

    [SerializeField]
    protected float LifeTime = 1;
        
    [SerializeField]
    protected float Damage;

    protected Rigidbody2D Body;

	// Use this for initialization
	void Awake ()
    {
        Body = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	protected void Update () {
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

    public virtual void Launch(Vector2 position, Vector2 direction)
    {
        transform.position = position;
        Body.velocity = direction * Velocity;
    }
}
