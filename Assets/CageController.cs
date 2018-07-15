using UnityEngine;

public class CageController : MonoBehaviour, IQuest {

	public float Duration = 10;
	public DoorsController DoorsController;

	private MovementComponent character;
	private float activateTime;
	private float oldSpeed;

	MobsFactory left;
	MobsFactory right;

	public void RunQuest()
	{
		gameObject.SetActive(true);
		character = FindObjectOfType<CharactersOwner>().Left.GetComponent<MovementComponent>();
		activateTime = Time.time;
		oldSpeed = character.MoveVelocity;
		character.MoveVelocity = 0;
		character.GetComponent<Rigidbody2D>().velocity = new Vector2();
		transform.position = character.transform.position + 0.25f * Vector3.up;
		SetAllChild(true);

		MobsFactory[] factories = FindObjectsOfType<MobsFactory>();
		left = factories[0];
		right = factories[1];
		if (left.transform.position.x > right.transform.position.x)
		{
			var temp = left;
			left = right;
			right = temp;
		}
		left.DeltaTime /= 3;
		right.DeltaTime = 1000000;
	}
	
	void Update () {
		if (activateTime + Duration < Time.time)
		{
			DoorsController.Open();
			gameObject.SetActive(false);
			character.MoveVelocity = oldSpeed;
			SetAllChild(false);

			left.DeltaTime = 10000000;
		}
	}

	public void SetAllChild(bool isActive)
	{
		foreach (Transform item in transform)
		{
			item.gameObject.SetActive(isActive);
		}
	}
}
