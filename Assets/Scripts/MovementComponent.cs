using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent : MonoBehaviour {

    private Rigidbody2D Body;

    public Vector2 Forward { get; private set; }

    [SerializeField]
    private float MoveVelocity;

	void Awake ()
    {
        Body = GetComponent<Rigidbody2D>();
        Forward = Vector2.up;
    }

    public void AddMovement(Vector2 InputVector)
    {
        if (enabled)
        {
            Body.velocity = InputVector * MoveVelocity;
            if (Body.velocity.magnitude > 0)
            {
                Forward = Body.velocity.normalized;
            }
        }
    }
}
