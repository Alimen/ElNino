using UnityEngine;
using System.Collections;

public class CameraPivot : MonoBehaviour 
{
	public Camera mainCamera;
	public Renderer cameraMask;

	Quaternion originRotation;
	public Vector2 maxAngle;
	public float topRollbackSpeed;
	public float accel;

	bool mouseDown = false;
	Vector3 mouseStartPos;
	AverageTrack currenntTrack = new AverageTrack(5);

	Quaternion startRotation;
	Accelerator speed;
	float angle;

	void Start()
	{
		originRotation = transform.localRotation;
		speed = new Accelerator();
	}

	void Update()
	{
		if (Input.GetMouseButton(0)) {
			if (!mouseDown) {
				mouseDown = true;
				mouseStartPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
				startRotation = transform.localRotation;
				currenntTrack.clear();
			}
		} else {
			if (mouseDown) {
				mouseDown = false;
				startRotation = transform.localRotation;
				angle = Quaternion.Angle(startRotation, originRotation);
				if (angle != 0) {
					speed = new Accelerator(angle, accel, topRollbackSpeed, accel, 0);
				}
			}
		}

		if (mouseDown) {
			currenntTrack.add(Camera.main.ScreenToViewportPoint(Input.mousePosition));

			Vector3 dif = mouseStartPos - currenntTrack.value;
			Quaternion r = new Quaternion();
			r.eulerAngles = new Vector3(dif.y * maxAngle.y, dif.x * -maxAngle.x, 0);
			transform.localRotation = startRotation * r;

		} else if (angle != 0) {
			transform.localRotation = Quaternion.Lerp(originRotation, startRotation, speed.step(Time.deltaTime) / angle);
		}
	}
}
