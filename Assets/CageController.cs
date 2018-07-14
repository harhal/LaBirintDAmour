using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageController : MonoBehaviour {

	public float Duration = 20;
	private InputComponent character;
	private float activateTime;

	void Start () {
		character = FindObjectOfType<CharactersOwner>().Left;
		activateTime = Time.time;
		//character.GetComponent<Mo>
	}
	
	void Update () {
		if (activateTime + Duration > Time.time)
		{
			gameObject.SetActive(false);
		}
	}
}
