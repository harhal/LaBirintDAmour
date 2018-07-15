using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunComponent : MonoBehaviour {
    
    private float StunTimer;
    private MovementComponent Movement;
    private ShotComponent Shot;

    public void Awake()
    {
        Movement = GetComponent<MovementComponent>();
        Shot = GetComponent<ShotComponent>();

    }

    public void Stun (float StunTime) {
        StunTimer = StunTime;
        if (Movement != null)
        {
            Movement.enabled = StunTime == 0;
        }
        if (Shot != null)
        {
            Shot.enabled = StunTime == 0;
        }
    }
	
	void Update () {
		if (StunTimer > 0)
        {
            StunTimer -= Time.deltaTime;
        }
        else
        {
            Stun(0);
        }
	}
}
