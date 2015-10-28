using UnityEngine;
using System.Collections;

public class EarthWind : MonoBehaviour
{
	// Component handlers
	public Alpha glow;

	// Animation parameters
	public float start, end;
	public float z;

	void Start()
	{
		GetComponent<Animator>().Play("EarthWind", 0, Random.Range(0f, 1f));
	}

	void Update()
	{
		transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, Mathf.Lerp(start, end, z));
	}
	
	public bool on {
		set {
			glow.on = value;
		}
	}
}
