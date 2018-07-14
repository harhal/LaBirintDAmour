using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobsFactory : MonoBehaviour {

	System.Random random = new System.Random();

	[System.Serializable]
	public class Pair
	{
		public GameObject gameObject;
		public float probability;
	}

	public float DeltaTime = 5;
	public float MinDelta = 1;
	public float MaxDelta = 5;

	public Pair[] mobs;
	public Transform Player;

	private Transform[] spawners;
	private List<Transform> cache;
	private float lastSpawnTime;
	float sumProba;

	private void Awake()
	{
		spawners = GetComponentsInChildren<Transform>();
		sumProba = 0;
		for (int i = 0; i < mobs.Length; i++)
		{
			sumProba += mobs[i].probability;
		}
		cache = new List<Transform>();
	}

	void Update ()
	{
		if (lastSpawnTime + DeltaTime > Time.time)
		{
			float value = UnityEngine.Random.Range(0, sumProba);
			float accum = 0;
			GameObject mobType = null;
			for (int i = 0; i < mobs.Length; i++)
			{
				if (value > accum)
				{
					accum += mobs[i].probability;
					if (value < accum)
					{
						mobType = mobs[i].gameObject;
						break;
					}
				}
			}
			if (mobType == null)
				return;

			InstantiateType(mobType);

			lastSpawnTime = Time.time;
		}
	}

	private void InstantiateType(GameObject mobType)
	{
		for (int i = 0; i < spawners.Length; i++)
		{
			Vector3 delta = spawners[i].position - Player.position;
			if (delta.magnitude > MinDelta && delta.magnitude < MaxDelta)
				cache.Add(spawners[i]);
		}
		Instantiate(mobType, cache[random.Next(cache.Count)].transform);
		cache.Clear();
	}
}
