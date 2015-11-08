using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Renderer))]
public class Alpha : MonoBehaviour
{
	Material[] mat;

	public float target;
	public float accel;
	public bool on;

	void Start()
	{
		mat = GetComponent<Renderer>().materials;
		if (mat == null) {
			Debug.LogError("Alpha: material not found");
		}
	}

	void Update()
	{
		target = Mathf.Clamp01(target);
		foreach (Material m in mat) {
			updateMaterial(m);
		}
	}

	void updateMaterial(Material m)
	{
		float t = on? target: 0;
		float a = m.color.a;
		
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
		
		Color c = m.color;
		c.a = a;
		m.color = c;
	}
}
