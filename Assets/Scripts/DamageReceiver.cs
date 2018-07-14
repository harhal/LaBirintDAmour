using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReceiver : MonoBehaviour {

    StatsComponent Stats;
    Rigidbody2D Body;

    // Use this for initialization
    void Awake ()
    { 
        Stats = GetComponent<StatsComponent>();
        Body = GetComponent<Rigidbody2D>();
    }

    public void ApplyDamage(float damage)
    {
        if (Stats != null)
        {
            Stats.ChangeHealth(-damage);
        }
    }

    public void ApplyDamageWithImpulse(float damage, Vector3 impulse)
    {
        ApplyDamage(damage);
        Body.AddForce(impulse);
        Debug.DrawRay(transform.position, transform.position + impulse);
    }
}
