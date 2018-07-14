using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsComponent : MonoBehaviour
{
    [SerializeField]
    private float maxHealth = 150;
    public float MaxHealth { get { return maxHealth; } private set { maxHealth = value; } }
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
        Health = Mathf.Clamp(Health, 0, MaxHealth);
		Validate();
        if (Health <= 0)
        {
            Death();
        }
	}

    private void Death()
    {
        Destroy(gameObject);
    }

	public void Validate()
	{
		if (text != null)
			text.text = Health.ToString();
	}
}
