using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotComponent : MonoBehaviour {

    [SerializeField]
    private Projectile BulletPrefub;

    [SerializeField]
    private float ShotRate;
    
    private float NextShotDelay;

    public void TryOpenFire(Vector2 Direction)
    {
        if (NextShotDelay <= 0)
        {
            Projectile NewBullet = Instantiate(BulletPrefub);
            NewBullet.Launch(transform.position, Direction);
            NextShotDelay = 1 / ShotRate;
        }
    }

    private void Update()
    {
        if (NextShotDelay > 0)
        {
            NextShotDelay -= Time.deltaTime;
        }
        else
        {
            NextShotDelay = 0;
        }
    }
}
