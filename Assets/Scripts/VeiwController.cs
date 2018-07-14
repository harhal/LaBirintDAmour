using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VeiwController : MonoBehaviour {

	Transform[] characters;

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
		Vector3 position = new Vector3();
		for (int i = 0; i < characters.Length; i++)
		{
			position += characters[i].position;
		}
		position /= characters.Length;
		Vector3 cameraPosition = transform.position;
		cameraPosition.y = position.y;
		transform.position = cameraPosition;
	}
}
