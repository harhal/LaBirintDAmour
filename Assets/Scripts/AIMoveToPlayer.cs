using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovementDiscretizator))]
public class AIMoveToPlayer : MonoBehaviour {

    private MovementDiscretizator Movement;
    private WorldSideComponent Side;
    private GameObject Target;

    [SerializeField]
    private float WalkMinDelay;
    [SerializeField]
    private float WalkMaxDelay;
    [SerializeField]
    private float MinTargetDistance;
    [SerializeField]
    private float TargetSideFactor;

    private float WalkDelay;

    void Awake ()
    {
        Movement = GetComponent<MovementDiscretizator>();
        Side = transform.parent.GetComponent<WorldSideComponent>();
        Target = Side.LocalPlayer;
    }

    void Update()
    {
        if (Movement.IsIdle())
        {
            if (WalkDelay > 0)
            {
                WalkDelay -= Time.deltaTime;
            }
            else
            {
                Vector2 TargetDirection = Target.transform.position - transform.position;
                Vector2 NTargetDirection = TargetDirection.normalized;
                if (TargetDirection.magnitude > MinTargetDistance)
                {
                    WalkDelay = Random.Range(WalkMinDelay, WalkMaxDelay);
                    float left, right, up, down;
                    left = right = up = down = 0.25f;
                    if (Vector2.Dot(NTargetDirection, Vector2.up) > 0)
                    {
                        up *= TargetSideFactor;
                        print("up");
                    }
                    if (Vector2.Dot(NTargetDirection, Vector2.down) > 0)
                    {
                        down *= TargetSideFactor;
                        print("down");
                    }
                    if (Vector2.Dot(NTargetDirection, Vector2.left) > 0)
                    {
                        left *= TargetSideFactor;
                        print("left");
                    }
                    if (Vector2.Dot(NTargetDirection, Vector2.right) > 0)
                    {
                        right *= TargetSideFactor;
                        print("right");
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
        }
    }
}
