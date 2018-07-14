using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackComponent : MonoBehaviour
{
    [SerializeField]
    private float Damage;
    [SerializeField]
    private float Impulse;
    [SerializeField]
    private float StunTime;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var victim = collision.collider.GetComponent<DamageReceiver>();
        if (victim != null)
        {
            var Stun = victim.GetComponent<StunComponent>();
            if (Stun != null)
            {
                Stun.Stun(StunTime);
            }
            Vector2 impulse = (victim.transform.position - transform.position).normalized * Impulse;
            victim.ApplyDamageWithImpulse(Damage, impulse);
        }
    }
}