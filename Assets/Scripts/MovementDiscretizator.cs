using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovementComponent))]
public class MovementDiscretizator : MonoBehaviour
{
    private MovementComponent Movement;
    private Rigidbody2D Body;
    [SerializeField]
    private float StepSize;
    [SerializeField]
    private float Accuracy;
    private Vector2 Destination;


    // Use this for initialization
    void Awake()
    {
        Movement = GetComponent<MovementComponent>();
        Body = GetComponent<Rigidbody2D>();
        Destination = Body.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsIdle())
        {
            Body.transform.position = Destination;
            Movement.AddMovement(Vector2.zero);
        }
        else
        {
            Movement.AddMovement((Destination - (Vector2)Body.transform.position).normalized);
        }
    }

    public bool IsIdle()
    {
        return Vector2.Distance(Body.transform.position, Destination) < Accuracy;
    }

    public void Go(Vector2 Direction)
    {
        Destination = (Vector2)Body.transform.position + Direction * StepSize;
    }
}
