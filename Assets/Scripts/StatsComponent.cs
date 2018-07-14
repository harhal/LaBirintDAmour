using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsComponent : MonoBehaviour
{
	public const float MaxHealth = 150;
	[SerializeField]
	private float Health = 100;

	public void ChangeHealth(float deltaHealth)
	{
		Health += deltaHealth;
	}
}
