using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMoveAndShotToPlayer : AIMoveToPlayer
{
    [SerializeField]
    private float ShotProbability = 0.5f;
    private ShotComponent Shot;

    [SerializeField]
    private float ShotMaxDistance = 6;

    protected override void Awake()
    {
        base.Awake();
        Shot = GetComponent<ShotComponent>();
    }

    protected override void DoAction()
    {
		if (Random.value < ShotProbability && (Target.transform.position - transform.position).magnitude <= ShotMaxDistance)
        {
            Shot.TryOpenFire((Target.transform.position - transform.position).normalized);
        }
        else
        {
            base.DoAction();
        }
	}
}
