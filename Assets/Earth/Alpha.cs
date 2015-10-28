using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Renderer))]
public class Alpha : MonoBehaviour
{
	Material mat;

	public float target;
	public float accel;
	public bool on;

	void Start()
	{
		mat = GetComponent<Renderer>().material;
		if (mat == null) {
			Debug.LogError("Alpha: material not found");
		}
	}

	void Update()
	{
		float t = on? target: 0;
		float a = mat.color.a;

		if (a > t) {
			a -= accel * Time.deltaTime;
			if (a < t) {
				a = t;
			}
		} else {
			a += accel * Time.deltaTime;
			if (a > t) {
				a = t;
			}
		}

		Color c = mat.color;
		c.a = a;
		mat.color = c;
	}
}
