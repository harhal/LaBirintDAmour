using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMoveToPlayer : MonoBehaviour {

	public GameObject Target;

	private MovementDiscretizator Movement;

    [SerializeField]
    private float WalkMinDelay;
    [SerializeField]
    private float WalkMaxDelay;
    [SerializeField]
    private float MinTargetDistance;
    [SerializeField]
    private float MaxTargetDistance = 10f;
    [SerializeField]
    private float DirectedMovementProbability = 0.7f;

    protected float ActionDelay;

    protected virtual void Awake ()
    {
        Movement = GetComponent<MovementDiscretizator>();
    }

    void Update()
    {
        if (Movement.IsIdle())
        {
            if (ActionDelay > 0)
            {
                ActionDelay -= Time.deltaTime;
            }
            else
            {
                DoAction();
            }

        }
    }

    protected virtual void DoAction()
    {
        Vector2 TargetDirection = Target.transform.position - transform.position;
        Vector2 NTargetDirection = TargetDirection.normalized;
        ActionDelay = Random.Range(WalkMinDelay, WalkMaxDelay);

        List<Vector2> CommonDirections = new List<Vector2>() { Vector2.up, Vector2.down, Vector2.left, Vector2.right };
        List<Vector2> TargetedDirections = new List<Vector2>();
        foreach (Vector2 d in CommonDirections)
        {
            if (Vector2.Dot(NTargetDirection, d) > 0 && Vector3.Project(NTargetDirection, d).magnitude > MinTargetDistance)
            {
                TargetedDirections.Add(d);
            }
        }
        List<Vector2> SelectedDirectionsArray = TargetedDirections.Count > 0 && (Random.value < DirectedMovementProbability || TargetDirection.magnitude >= MaxTargetDistance) ?
            TargetedDirections : CommonDirections;

        Movement.Go(SelectedDirectionsArray[Random.Range(0, (SelectedDirectionsArray.Count))]);
    }
}
