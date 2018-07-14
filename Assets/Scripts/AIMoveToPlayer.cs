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
    private float TargetSideFactor;

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
        float left, right, up, down;
        left = right = up = down = 0.25f;
        if (Vector2.Dot(NTargetDirection, Vector2.up) > 0 && Vector3.Project(NTargetDirection, Vector3.up).magnitude > MinTargetDistance)
        {
            up *= up * TargetSideFactor * Vector2.Dot(NTargetDirection, Vector2.up);
        }
        if (Vector2.Dot(NTargetDirection, Vector2.down) > 0 && Vector3.Project(NTargetDirection, Vector3.down).magnitude > MinTargetDistance)
        {
            down *= down * TargetSideFactor * Vector2.Dot(NTargetDirection, Vector2.down);
        }
        if (Vector2.Dot(NTargetDirection, Vector2.left) > 0 && Vector3.Project(NTargetDirection, Vector3.left).magnitude > MinTargetDistance)
        {
            left *= left * TargetSideFactor * Vector2.Dot(NTargetDirection, Vector2.left); ;
        }
        if (Vector2.Dot(NTargetDirection, Vector2.right) > 0 && Vector3.Project(NTargetDirection, Vector3.right).magnitude > MinTargetDistance)
        {
            right *= right * TargetSideFactor * Vector2.Dot(NTargetDirection, Vector2.right); ;
        }
        float sum = left + right + up + down;
        up /= sum;
        down /= sum;
        left /= sum;
        right /= sum;
        float dice = Random.value;
        Vector2 direction = Vector2.right;
        if (dice < up)
        {
            direction = Vector2.up;
        }
        else if (dice < up + down)
        {
            direction = Vector2.down;
        }
        else if (dice < up + down + left)
        {
            direction = Vector2.left;
        }
        Movement.Go(direction);
    }
}
