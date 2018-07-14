using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputComponent : MonoBehaviour
{
	public float Delta = 10;

	protected MovementComponent Movement;
	protected ShotComponent Shot;
	protected StatsComponent Stats;
	private StatsComponent OtherStats;

	public string HorisontalAxis;
	public string VerticalAxis;
	public string ShotButton;
	public string ShareButton;

	// Use this for initialization
	void Awake()
	{
		Movement = GetComponent<MovementComponent>();
		Shot = GetComponent<ShotComponent>();
		Stats = GetComponent<StatsComponent>();
		StatsComponent[] characters = FindObjectsOfType<StatsComponent>();
		if (characters[0] != Stats)
			OtherStats = characters[0];
		else
			OtherStats = characters[1];
	}

	private void FixedUpdate()
	{
		Movement.AddMovement(new Vector2(Input.GetAxis(HorisontalAxis), Input.GetAxis(VerticalAxis)));
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetButtonDown(ShotButton))
		{
			Shot.TryOpenFire(Movement.Forward);
		}
		if (Input.GetButtonDown(ShareButton))
		{
			OtherStats.ChangeHealth(Delta);
			Stats.ChangeHealth(-Delta);
		}
	}
}