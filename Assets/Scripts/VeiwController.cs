using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VeiwController : MonoBehaviour {

	private const float lenCoeff = 10f;
	private Transform[] characters;

	public bool IsCaptured { get; set; }

	void Start () {
		var components = FindObjectsOfType<InputComponent>();
		characters = new Transform[components.Length];
		for (int i = 0; i < characters.Length; i++)
		{
			characters[i] = components[i].gameObject.transform;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (IsCaptured)
			return;

		Vector3 cameraPosition = transform.position;
		float realMiddleY = GetY();

		float currentDelta = Mathf.Max(0, realMiddleY - cameraPosition.y);

		float delta = Mathf.Min(lenCoeff * Time.deltaTime, currentDelta);
		cameraPosition.y += delta;
		transform.position = cameraPosition;
	}

	private float GetY()
	{
		Vector3 position = new Vector3();
		for (int i = 0; i < characters.Length; i++)
		{
			position += characters[i].position;
		}
		position /= characters.Length;
		return position.y;
	}
}
