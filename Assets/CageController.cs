using UnityEngine;

public class CageController : MonoBehaviour, IQuest {

	public float Duration = 10;
	public DoorsController DoorsController;

	private MovementComponent character;
	private float activateTime;
	private float oldSpeed;

	public void RunQuest()
	{
		gameObject.SetActive(true);
		character = FindObjectOfType<CharactersOwner>().Left.GetComponent<MovementComponent>();
		activateTime = Time.time;
		oldSpeed = character.MoveVelocity;
		character.MoveVelocity = 0;
		transform.position = character.transform.position + Vector3.forward;
		SetAllChild(true);
	}
	
	void Update () {
		if (activateTime + Duration < Time.time)
		{
			DoorsController.Open();
			gameObject.SetActive(false);
			character.MoveVelocity = oldSpeed;
			SetAllChild(false);
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
