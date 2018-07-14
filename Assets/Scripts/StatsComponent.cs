﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsComponent : MonoBehaviour
{
	public const float MaxHealth = 150;
	public Text text;
	[SerializeField]
	private float Health = 100;

	private void Start()
	{
		Validate();
	}

	public void ChangeHealth(float deltaHealth)
	{
		Health += deltaHealth;
		Validate();
	}

	public void Validate()
	{
		text.text = Health.ToString();
	}
}
