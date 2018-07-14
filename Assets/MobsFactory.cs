using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MobsFactory : MonoBehaviour {

	System.Random random = new System.Random();

	[System.Serializable]
	public class Pair
	{
		public AIMoveToPlayer gameObject;
		public float probability;
	}

	public float DeltaTime = 5;
	public float MinDelta = 1;
	public float MaxDelta = 5;

	public Pair[] mobs;
	public Transform Character;

	private Transform[] spawners;
	private List<Transform> cache;
	private float lastSpawnTime;
	float sumProba;

	private void Awake()
	{
		spawners = GetComponentsInChildren<Transform>().Where(s => s != transform).ToArray();
		sumProba = 0;
		for (int i = 0; i < mobs.Length; i++)
		{
			sumProba += mobs[i].probability;
		}
		cache = new List<Transform>();
	}

	void Update ()
	{
		if (lastSpawnTime + DeltaTime < Time.time)
		{
			float value = UnityEngine.Random.Range(0, sumProba);
			float accum = 0;
			AIMoveToPlayer mobType = null;
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

	private void InstantiateType(AIMoveToPlayer mobPrototype)
	{
		for (int i = 0; i < spawners.Length; i++)
		{
			Vector3 delta = spawners[i].position - Character.position;
			if (delta.magnitude > MinDelta && delta.magnitude < MaxDelta)
				cache.Add(spawners[i]);
		}

		if (cache.Count == 0)
			return;

		AIMoveToPlayer newOne = Instantiate(mobPrototype, cache[random.Next(cache.Count)].transform);
		newOne.transform.localPosition = new Vector3();
		newOne.Target = Character.gameObject;
		newOne.gameObject.SetActive(true);
		cache.Clear();
	}
}
