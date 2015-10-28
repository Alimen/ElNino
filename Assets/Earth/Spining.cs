using UnityEngine;
using System.Collections;

public class Spining : MonoBehaviour
{
	public Vector3 speed;

	void Update() 
	{
		transform.Rotate(speed * Time.deltaTime);
	}
}
