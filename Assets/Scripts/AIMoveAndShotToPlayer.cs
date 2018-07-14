using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMoveAndShotToPlayer : AIMoveToPlayer
{
    [SerializeField]
    private float ShotProbability = 0.5f;
    private ShotComponent Shot;

    protected override void Awake()
    {
        base.Awake();
        Shot = GetComponent<ShotComponent>();
    }

    protected override void DoAction()
    {
		if (Random.value < ShotProbability)
        {
            Shot.TryOpenFire((Target.transform.position - transform.position).normalized);
        }
        else
        {
            base.DoAction();
        }
	}
}
