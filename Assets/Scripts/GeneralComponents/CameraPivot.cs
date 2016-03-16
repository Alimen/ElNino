using UnityEngine;
using System.Collections;

public class CameraPivot : MonoBehaviour 
{
	public Camera mainCamera;
	public Renderer cameraMask;

	Vector3 originRotation;
	public Vector2 maxAngle;
	public float topRollbackSpeed;
	public float accel;

	bool mouseDown = false;
	Vector3 mouseStartPos;
	Vector3 startRotation;
	AverageTrack currenntTrack = new AverageTrack(5);
	Accelerator speed;
	Vector3 direction;

	void Start()
	{
		eulerAngles = transform.localEulerAngles;
	}

	void Update()
	{
		if (Input.GetMouseButton(0)) {
			if (!mouseDown) {
				mouseDown = true;
				mouseStartPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
				startRotation = transform.localEulerAngles;
				currenntTrack.clear();
			}
		} else {
			if (mouseDown) {
				mouseDown = false;
				direction = new Vector3(transform.localEulerAngles.x - originRotation.x, transform.localEulerAngles.y - originRotation.y, 0); 
				speed = new Accelerator(direction.magnitude, accel, topRollbackSpeed, accel, 0);
				direction = direction.normalized;
			}
		}

		if (mouseDown) {
			currenntTrack.add(Camera.main.ScreenToViewportPoint(Input.mousePosition));
			Vector3 dif = currenntTrack.value - mouseStartPos;
			float x = Mathf.Clamp(startRotation.x - dif.y * maxAngle.y, originRotation.x - maxAngle.y, originRotation.x + maxAngle.y);
			float y = Mathf.Clamp(startRotation.y + dif.x * maxAngle.x, originRotation.y - maxAngle.x, originRotation.y + maxAngle.x);
			transform.localEulerAngles = new Vector3(x, y, originRotation.z);

		} else if (Vector3.Distance(transform.localEulerAngles, originRotation) > 1e-4) {
			transform.localEulerAngles = originRotation + direction * speed.step(Time.deltaTime);
		}
	}

	public Vector3 eulerAngles {
		set {
			originRotation = value;
			transform.localEulerAngles = originRotation;
		}
		get {
			return transform.localEulerAngles;
		}
	}
}
