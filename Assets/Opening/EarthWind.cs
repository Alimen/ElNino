using UnityEngine;
using System.Collections;

public class EarthWind : MonoBehaviour
{
	// Component handlers
	public Animator anim;
	public Alpha glow;

	// Delays
	public float maximumDelay;
	public bool on = true;
	float timer;

	void Start()
	{
		resetTimer();
	}

	void Update()
	{
		if (on) {
			timer -= Time.deltaTime;
			if (timer < 0) {
				anim.Play("EarthWind");
			}
		}
	}

	void resetTimer()
	{
		timer = Random.Range(0.1f, maximumDelay);
	}
	
	public bool mouseover {
		set {
			glow.on = value;
		}
	}
}
