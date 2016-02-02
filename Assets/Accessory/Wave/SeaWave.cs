using UnityEngine;
using System.Collections;

public class SeaWave : MonoBehaviour
{
	public Transform wave;

	void Update()
	{
		Vector3 pos = transform.position;
		pos.y = WaterSurface.seaLevelAt(wave.position + Vector3.forward * 0.5f);
		transform.position = pos;	
	}

	public void endAnim()
	{
		Destroy(gameObject);
	}
}
