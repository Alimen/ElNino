using UnityEngine;
using System.Collections;

public enum Axis
{
	x, y, z
}

public class ControllerBase : MonoBehaviour
{
	[Header("---- Handler settings ----------------------------------")]
	public Transform handler;
	public Axis axis;

	[Header("---- Active Range --------------------------------------")]
	public float start;
	public float end;
	protected float ratio;

	protected virtual void Update()
	{
		if (handler == null) {
			ratio = 0;
			return;
		}

		float t = 0;
		switch (axis) {
			case Axis.x:
				t = handler.localPosition.x;
				break;
			case Axis.y:
				t = handler.localPosition.y;
				break;
			case Axis.z:
				t = handler.localPosition.z;
				break;
		}

		if (t < start) {
			ratio = 0;
		} else if (t > end) {
			ratio = 1;
		} else {
			ratio = (t - start) / (end - start);
		}
	}
}
