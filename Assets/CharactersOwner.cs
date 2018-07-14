using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersOwner : MonoBehaviour {

	public InputComponent Left { get; private set; }
	public InputComponent Right { get; private set; }

	// Use this for initialization
	void Start () {
		InputComponent[] res = FindObjectsOfType<InputComponent>();
		if (res[0].transform.position.x > res[1].transform.position.x)
		{
			Right = res[0];
			Left = res[1];
		}
		else
		{
			Right = res[1];
			Left = res[0];
		}
	}
}
