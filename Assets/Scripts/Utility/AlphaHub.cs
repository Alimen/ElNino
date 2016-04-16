using UnityEngine;
using System.Collections;

public class AlphaHub : MonoBehaviour
{
	public Alpha[] winds;
	public float target = 1.0f;
	public float accel;
	public bool isOn;
	float a;

	public void startAnim()
	{
		isOn = true;
	}

	public void endAnim()
	{
		isOn = false;
		StopCoroutine("endCoroutine");
		StartCoroutine("endCoroutine");
	}

	IEnumerator endCoroutine()
	{
		yield return new WaitForSeconds(1.0f / accel);
		gameObject.SetActive(false);
	}

	void Update()
	{
		float t = isOn? target: 0.0f;
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

		foreach (Alpha alpha in winds) {
			alpha.target = a;
		}
	}
}
