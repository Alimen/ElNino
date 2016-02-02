using UnityEngine;
using System.Collections;

public class WaterSurface : MonoBehaviour
{
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
