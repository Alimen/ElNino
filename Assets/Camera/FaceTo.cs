using UnityEngine;
using System.Collections;

public class FaceTo : MonoBehaviour
{
	public Vector3 direction;

	void Update()
	{
		transform.LookAt(transform.position + direction);
	}
}
