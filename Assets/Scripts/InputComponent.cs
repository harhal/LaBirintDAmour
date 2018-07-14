using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputComponent : MonoBehaviour
{
    protected MovementComponent Movement;
    protected ShotComponent Shot;

    public string HorisontalAxis;
    public string VerticalAxis;
    public string ShotButton;
	public string ShareButton;

	// Use this for initialization
	void Awake ()
    {
		Movement = GetComponent<MovementComponent>();
		Shot = GetComponent<ShotComponent>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        Movement.AddMovement(new Vector2(Input.GetAxis(HorisontalAxis), Input.GetAxis(VerticalAxis)));
        if (Input.GetButtonDown(ShotButton))
        {
            Shot.TryOpenFire(Movement.Forward);
        }
		if (Input.GetButtonDown(ShareButton))
		{
			
		}
	}
}
