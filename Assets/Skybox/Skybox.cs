using UnityEngine;
using System.Collections;

public class Skybox : MonoBehaviour
{
	public Renderer rend;

	public float alpha {
		set {
			Color c;
			foreach (Material m in rend.materials) {
				c = m.color;
				c.a = Mathf.Clamp01(value);
				m.color = c;
			}
		}
	}
}
