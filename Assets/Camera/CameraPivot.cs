﻿using UnityEngine;
using System.Collections;

public class CameraPivot : MonoBehaviour 
{
	public Camera mainCamera;
	public Renderer cameraMask;

	Vector3 originRotation;
	public Vector2 maxAngle;
	public Vector2 topRollbackSpeed;
	public Vector2 accel;

	bool mouseDown = false;
	Vector3 mouseStartPos;
	Vector3 startRotation;
	AverageTrack currenntTrack = new AverageTrack(10);
	Accelerator speedX, speedY;

	void Start()
	{
		eulerAngles = transform.eulerAngles;
	}

	void OnMouseDown()
	{
		if (!mouseDown) {
			mouseDown = true;
			mouseStartPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
			startRotation = transform.eulerAngles;
			currenntTrack.clear();
		}
	}

	void OnMouseUp()
	{
		if (mouseDown) {
			mouseDown = false;
			speedX = new Accelerator(transform.eulerAngles.x, accel.x, topRollbackSpeed.x, accel.x, originRotation.x);
			speedY = new Accelerator(transform.eulerAngles.y, accel.y, topRollbackSpeed.y, accel.y, originRotation.y);
		}
	}

	void Update()
	{
		if (mouseDown) {
			currenntTrack.add(Camera.main.ScreenToViewportPoint(Input.mousePosition));
			Vector3 dif = currenntTrack.value - mouseStartPos;
			float x = Mathf.Clamp(startRotation.x - dif.y * maxAngle.y, originRotation.x - maxAngle.y, originRotation.x + maxAngle.y);
			float y = Mathf.Clamp(startRotation.y + dif.x * maxAngle.x, originRotation.y - maxAngle.x, originRotation.y + maxAngle.x);
			transform.eulerAngles = new Vector3(x, y, originRotation.z);

		} else if (transform.eulerAngles != originRotation) {
			transform.eulerAngles = new Vector3(speedX.step(Time.deltaTime), speedY.step(Time.deltaTime));
		}
	}

	public Vector3 eulerAngles {
		set {
			originRotation = value;
			transform.eulerAngles = originRotation;
		}
		get {
			return transform.localEulerAngles;
		}
	}

	bool _enableMouseMove = true;
	public bool enableMouseMove {
		set {
			if (value != _enableMouseMove) {
				if (_enableMouseMove) {
					OnMouseUp();
				}
				_enableMouseMove = value;
				GetComponent<Collider>().enabled = value;
			}
		}
		get {
			return _enableMouseMove;
		}
	}
}
