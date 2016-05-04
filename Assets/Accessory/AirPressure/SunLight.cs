using UnityEngine;
using System.Collections;

public class SunLight : MonoBehaviour 
{
	public float speed;

	void Update()
	{
		transform.localRotation *= Quaternion.AngleAxis(speed * Time.deltaTime, Vector3.back);
	}
}
