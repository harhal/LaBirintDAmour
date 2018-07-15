using UnityEngine;

public class MovementComponent : MonoBehaviour {

    public Vector2 LookDirection { get; private set; }
	public float MoveVelocity;

    private VisualController Visual;

	private Rigidbody2D body;

	void Awake ()
    {
        body = GetComponent<Rigidbody2D>();
        Visual = GetComponent<VisualController>();
        LookDirection = Vector2.up;
    }

    public void AddMovement(Vector2 InputVector)
    {
        if (enabled)
        {
            body.velocity = InputVector * MoveVelocity;
            if (InputVector.magnitude > 0.05f)
            {
                LookDirection = InputVector.normalized;
            }
            if (Visual != null)
            {
                Visual.SetMovement(LookDirection, body.velocity.magnitude);
            }
        }
    }
}
