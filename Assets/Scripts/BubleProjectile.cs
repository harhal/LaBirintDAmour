using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubleProjectile : Projectile {

    [SerializeField]
    private float CrossAmplitude;
    [SerializeField]
    private float CrossPhase = 1;
    private Vector2 ForwardVector;
	
	void Update ()
    {
        base.Update();
        Vector2 CrossDirection = Vector3.Cross(ForwardVector, Vector3.forward);
        float PhaseFactor = (LifeTime % CrossPhase) / CrossPhase;
        float CrossVelocityScale = (Mathf.Abs(PhaseFactor - 0.5f) - 0.25f) * 4;
        Vector2 CrossVelocity = CrossDirection * CrossVelocityScale * CrossAmplitude;
        Body.velocity = ForwardVector * Velocity + CrossVelocity;
    }

    public override void Launch(Vector2 position, Vector2 direction)
    {
        base.Launch(position, direction);
        ForwardVector = direction;
    }
}
