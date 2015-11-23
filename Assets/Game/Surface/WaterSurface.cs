using UnityEngine;
using System.Collections;

public class WaterSurface : MonoBehaviour
{
	// Component handlers
	Animation anim;

	// Controler
	public float level;

	// Surface
	public Transform surface;
	public float surfaceStartAngel;
	public float surfaceEndAngel;

	void Start()
	{
		anim = GetComponent<Animation>();
	}

	void Update()
	{
		level = Mathf.Clamp01(level);
		
		anim ["Take 001"].time = level * anim ["Take 001"].length;
		anim ["Take 001"].speed = 0.0f;
		anim.Play("Take 001");
		
		float r = surfaceStartAngel + (surfaceEndAngel - surfaceStartAngel) * level;
		surface.rotation = Quaternion.Euler(0, 0, r);
	}

	public static float seaLevelAt(Vector3 pos)
	{
		RaycastHit[] hits;
		hits = Physics.RaycastAll(new Vector3(pos.x, 25, pos.z), Vector3.down, 50);

		float output = -25;
		foreach (RaycastHit h in hits) {
			if (h.collider.tag == "Surface") {
				output = h.point.y;
				break;
			}
		}

		return output;
	}
}
