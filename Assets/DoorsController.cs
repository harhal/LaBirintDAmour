using System;
using UnityEngine;

public class DoorsController : MonoBehaviour {

	private const float speed = 3;
	
	public float SideSize = 20;
	public GameObject Quest;

    [SerializeField]
	private Transform left;
    [SerializeField]
    private Transform right;
	private bool isOpening = false;
	private VeiwController viewController;

	private void Awake()
	{
		/*Transform[] doors1 = GetComponentsInChildren<Transform>();
		Transform[] doors = new Transform[2];
		int i = 0;
		if (doors1[0] != transform)
			doors[i++] = doors1[0];
		if (doors1[1] != transform)
			doors[i++] = doors1[1];
		if (doors1[2] != transform)
			doors[i++] = doors1[2];

		if (doors[0].transform.position.x > doors[1].transform.position.x)
		{
			left = doors[1].transform;
			right = doors[0].transform;
		}
		else
		{
			left = doors[0].transform;
			right = doors[1].transform;
		}*/
	}

	void Update () {
		if (!isOpening)
			return;

		left.transform.position += speed * Time.deltaTime * Vector3.left;
		right.transform.position += speed * Time.deltaTime * Vector3.right;

		if ((right.transform.position - left.transform.position).magnitude > 2 * SideSize)
		{
			isOpening = false;
			GetComponent<Collider>().enabled = false;
			if (viewController != null)
			{
				viewController.IsCaptured = false;
				viewController = null;
			}
		}
	}

	public void Open()
	{
		isOpening = true;
	}

	private void OnTriggerEnter(Collider other)
	{
		viewController = other.GetComponent<VeiwController>();
		if (viewController != null)
		{
			viewController.IsCaptured = true;

			var quest = Quest.GetComponent<IQuest>();
			if (quest != null)
				quest.RunQuest();
		}
	}

	private void OnTriggerExit(Collider other)
	{
		viewController = other.GetComponent<VeiwController>();
		if (viewController != null)
		{
			viewController.IsCaptured = false;
			viewController = null;
		}
	}
}

public interface IQuest
{
	void RunQuest();
}
