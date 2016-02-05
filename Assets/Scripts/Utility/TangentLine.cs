using UnityEngine;
using System.Collections;

public class TangentLine : MonoBehaviour
{
	Vector3 lastPos = Vector3.zero;
	public Axis rotationAxis = Axis.z;

	void Update()
	{
		Vector3 delta = transform.localPosition - lastPos;
		Vector3 newRotation = transform.localRotation.eulerAngles;
		switch (rotationAxis) {
			case Axis.x:
				newRotation.x = Mathf.Atan2(delta.z, delta.y) / Mathf.PI * 180;
				break;
			case Axis.y:
				newRotation.y = Mathf.Atan2(delta.x, delta.z) / Mathf.PI * 180 - 90;
				break;
			case Axis.z:
				newRotation.z = Mathf.Atan2(delta.y, delta.x) / Mathf.PI * 180;
				break;
		}
		transform.localRotation = Quaternion.Euler(newRotation);
		lastPos = transform.localPosition;
	}
}
