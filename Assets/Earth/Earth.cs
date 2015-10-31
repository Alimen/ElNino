using UnityEngine;
using System.Collections;

public class Earth : MonoBehaviour
{
	// Component handlers
	public Spining spining;
	public Animator anim;
	public StartHint startHint;
	public EarthWind[] earthWinds;

	// Animation control
	public float skyboxAlpha;
	public Skybox skybox;
	public Color cameraColorControl;
	public Camera mainCamera;

	// Rotation parameters
	bool mouseover = false;
	public float topSpeed;
	public float normalSpeed;
	public float accel;
	public float pacificMiddleLine;
	public float pacificWidth;
	public float animStartLine;

	// State parameters
	public bool clickAvaialble;
	public enum state { idle, transiting, animating, stopped };
	public state currentState;

	void Start()
	{
		currentState = state.idle;
		StartCoroutine(update());
	}

	IEnumerator update()
	{
		yield return StartCoroutine(idle());
		yield return StartCoroutine(transit());
		yield return StartCoroutine(rolloutAnimation());
	}

	///////////////////////////////////////////////////////////////////////////////
	//
	// Idle
	//
	///////////////////////////////////////////////////////////////////////////////

	IEnumerator idle()
	{
		while (currentState == state.idle) {
			idleStep();
			yield return null;
		}
	}

	void idleStep()
	{
		Vector3 speed = spining.speed;
		clickAvaialble = (Mathf.Abs(Mathf.DeltaAngle(transform.localEulerAngles.y, pacificMiddleLine)) < pacificWidth);

		if (mouseover && !clickAvaialble) {
			if (speed.z > topSpeed) {
				speed.z += accel * Time.deltaTime;
				if (speed.z < topSpeed) {
					speed.z = topSpeed;
				}
			}
		} else {
			if (speed.z < normalSpeed) {
				speed.z -= accel * Time.deltaTime;
				if (speed.z > normalSpeed) {
					speed.z = normalSpeed;
				}
			}
		}
		spining.speed = speed; 
	}
	
	///////////////////////////////////////////////////////////////////////////////
	//
	// Transit
	//
	///////////////////////////////////////////////////////////////////////////////

	IEnumerator transit()
	{
		while (Mathf.Abs(Mathf.DeltaAngle(transform.localEulerAngles.y, animStartLine)) > Mathf.Abs(topSpeed * Time.deltaTime)) {
			transitStep();
			yield return null;
		}

		anim.enabled = true;
		foreach (EarthWind e in earthWinds) {
			e.gameObject.SetActive(false);
		}
		currentState = state.animating;
	}

	void transitStep()
	{
		Vector3 speed = spining.speed;
		if (speed.z > topSpeed) {
			speed.z += accel * Time.deltaTime;
			if (speed.z < topSpeed) {
				speed.z = topSpeed;
			}
		}
		spining.speed = speed; 
	}
	
	///////////////////////////////////////////////////////////////////////////////
	//
	// Roll-out animation
	//
	///////////////////////////////////////////////////////////////////////////////

	IEnumerator rolloutAnimation()
	{
		while (currentState == state.animating) {
			skybox.alpha = skyboxAlpha;
			mainCamera.backgroundColor = cameraColorControl;
			yield return null;
		}
	}

	public void animationEnds()
	{
		currentState = state.stopped;
		Destroy(gameObject);
		Destroy(skybox.gameObject);
	}

	///////////////////////////////////////////////////////////////////////////////
	//
	// Mouse events
	//
	///////////////////////////////////////////////////////////////////////////////

	void OnMouseEnter()
	{
		if (currentState == state.idle) {
			mouseover = true;
			foreach (EarthWind e in earthWinds) {
				e.on = true;
			}
		}
	}

	void OnMouseExit()
	{
		if (currentState == state.idle) {
			mouseover = false;
			foreach (EarthWind e in earthWinds) {
				e.on = false;
			}
		}
	}

	void OnMouseUp()
	{
		if (clickAvaialble && currentState == state.idle) {
			OnMouseExit();
			startHint.on = false;
			clickAvaialble = false;
			currentState = state.transiting;
		}
	}
}
