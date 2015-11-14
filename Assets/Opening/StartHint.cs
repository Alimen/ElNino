using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartHint : MonoBehaviour
{
	// Component handlers
	public Image text;

	// Start delay
	public float delay;
	public bool on = true;
	float delayTimer;

	// Breath animation
	float breathTimer = Mathf.PI / -2f;

	void Start()
	{
		delayTimer = delay;
	}

	void Update()
	{
		if (delayTimer > 0) {
			delayTimer -= Time.deltaTime;
			return;
		}

		Color c = text.color;
		if (on) {
			c.a = Mathf.Clamp01(Mathf.Sin(breathTimer) * 0.5f + 0.5f);
			breathTimer += Time.deltaTime * 1.2f;
		} else {
			c.a = 0;
		}
		text.color = c;
	}
}
