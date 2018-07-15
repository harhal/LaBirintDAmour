using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollisionComponent : MonoBehaviour
{
    private bool DestroyByStatic = true;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (DestroyByStatic || collision.collider.GetComponent<DamageReceiver>() != null)
            Destroy(gameObject);
    }
}
