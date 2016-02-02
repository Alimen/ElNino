using UnityEngine;
using System.Collections;

public class TangentLine : MonoBehaviour
{
	Vector3 lastPos = Vector3.zero;

	void Update()
	{
		float t = Mathf.Atan2(transform.localPosition.y - lastPos.y, transform.localPosition.x - lastPos.x) / Mathf.PI * 180;
		transform.localRotation = Quaternion.Euler(new Vector3(0, 0, t));
		lastPos = transform.localPosition;
	}
}
