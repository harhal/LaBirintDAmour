using UnityEngine;

public class MovementComponent : MonoBehaviour {

    public Vector2 LookDirection { get; private set; }
	public float MoveVelocity;

	private Rigidbody2D body;

	void Awake ()
    {
        body = GetComponent<Rigidbody2D>();
        LookDirection = Vector2.up;
    }

    public void AddMovement(Vector2 InputVector)
    {
        if (enabled)
        {
            body.velocity = InputVector * MoveVelocity;
            if (InputVector.magnitude > 0.05f)
            {
				Debug.Log(InputVector);
				InputVector.Normalize();
                LookDirection = InputVector;
            }
        }
    }
}
