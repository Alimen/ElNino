using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class ScreenSplitter : MonoBehaviour
{
	public Camera cam1;
	public Camera cam2;
	float prv = 0.5f;

	void Update()
	{
		float x = transform.localPosition.x;
		if (x == prv) {
			return;
		}
		prv = x;

		Rect r;
		if (x > 0) {
			cam1.enabled = true;
			r = cam1.rect;
			r.width = x;
			cam1.rect = r;
		} else {
			cam1.enabled = false;
		}

		if (x < 1) {
			cam2.enabled = true;
			r = cam2.rect;
			r.x = x;
			r.width = 1.0f - x;
			cam2.rect = r;
		} else {
			cam2.enabled = false;
		}
	}
}
