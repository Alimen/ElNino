using UnityEngine;
using System.Collections;

public class BillboardSprite : MonoBehaviour
{
	public Camera target;

	void Start()
	{
		if (target == null) {
			Debug.LogError("no camera " + gameObject.name);
		}
	}

	void Update()
	{
		transform.LookAt(transform.position - target.transform.position);
	}
}
