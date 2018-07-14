using UnityEngine;

public class MovementComponent : MonoBehaviour {

    public Vector2 Forward { get; private set; }
	public float MoveVelocity;

	private Rigidbody2D body;

	void Awake ()
    {
        body = GetComponent<Rigidbody2D>();
        Forward = Vector2.up;
    }

    public void AddMovement(Vector2 InputVector)
    {
        if (enabled)
        {
            body.velocity = InputVector * MoveVelocity;
            if (body.velocity.magnitude > 0)
            {
                Forward = body.velocity.normalized;
            }
        }
    }
}
