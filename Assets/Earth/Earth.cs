using UnityEngine;
using System.Collections;

public class Earth : MonoBehaviour
{
	// Component handlers
	public Spining spining;
	public EarthWind[] earthWinds;
	public StartHint startHint;

	// Rotation parameters
	bool mouseover = false;
	public float topSpeed;
	public float normalSpeed;
	public float accel;
	public float pacificMiddleLine;
	public float pacificWidth;

	void Update()
	{
		Vector3 speed = spining.speed;
		if (mouseover && !(Mathf.Abs(Mathf.DeltaAngle(transform.localEulerAngles.y, pacificMiddleLine)) < pacificWidth)) {
			if (speed.z > topSpeed) {
				speed.z += accel * Time.deltaTime;
				if (speed.z < topSpeed) {
					speed.z = topSpeed;
				}
			}
		} else {
			if (speed.z < normalSpeed) {
				speed.z -= accel * Time.deltaTime;
				if (speed.z > normalSpeed) {
					speed.z = normalSpeed;
				}
			}
		}
		spining.speed = speed; 
	}

	void OnMouseEnter()
	{
		mouseover = true;
		foreach (EarthWind e in earthWinds) {
			e.on = true;
		}
	}

	void OnMouseExit()
	{
		mouseover = false;
		foreach (EarthWind e in earthWinds) {
			e.on = false;
		}
	}

	void OnMouseUp()
	{
		startHint.on = false;
	}
}
