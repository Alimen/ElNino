using UnityEngine;
using System.Collections;

public class WindSpeedHub : MonoBehaviour
{
	public SurfaceWind[] winds;
	public float target;

	void Update()
	{
		foreach (SurfaceWind w in winds) {
			w.speed = target;
		}
	}
}
