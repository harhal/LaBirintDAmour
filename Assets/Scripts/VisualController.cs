using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualController : MonoBehaviour {

    public virtual void SetMovement(Vector2 Rotation, float Velocity)
    {

    }

    public virtual IEnumerator PlayDeath()
    {
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(0.1f);
            SwitchVisualVisibility();
        }
        Destroy(gameObject);
    }

    protected virtual void SwitchVisualVisibility()
    {
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
