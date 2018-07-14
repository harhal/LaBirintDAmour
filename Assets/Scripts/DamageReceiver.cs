using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReceiver : MonoBehaviour {

    StatsComponent Stats;

    // Use this for initialization
    void Awake ()
    { 
        Stats = GetComponent<StatsComponent>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ApplyDamage(float damage)
    {
        if (Stats != null)
        {
            Stats.AddHealth(-damage);
        }
    }
}
