using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputComponent : MonoBehaviour {

    protected MovementComponent Movement;
    protected ShotComponent Shot;

    public GameObject Pawn;

    public string HorisontalAxis;
    public string VerticalAxis;
    public string ShotButton;

    public void Possess(GameObject Pawn)
    {
        this.Pawn = Pawn;
        Movement = Pawn.GetComponent<MovementComponent>();
        Shot = Pawn.GetComponent<ShotComponent>();
    }

	// Use this for initialization
	void Awake ()
    {
        if (Pawn != null)
        {
            Possess(Pawn);
        }
        else
        {
            var ComponentFindResult = GetComponentInChildren<MovementComponent>();
            if (ComponentFindResult != null)
            {
                Possess(ComponentFindResult.gameObject);
            }
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Movement != null)
        {
            Movement.AddMovement(new Vector2(Input.GetAxis(HorisontalAxis), Input.GetAxis(VerticalAxis)));
        }
        if (Shot != null)
        {
            if (Input.GetButtonDown(ShotButton))
            {
                Shot.TryOpenFire(Movement.GetForwardVector());
            }
        }
    }
}
