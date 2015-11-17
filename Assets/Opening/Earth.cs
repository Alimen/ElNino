using UnityEngine;
using System.Collections;

public class Earth : MonoBehaviour
{
	// Manager handlers
	public Opening openingCutscene;

	// Component handlers
	public Rotor rotorX, rotorY;
	public EarthWind[] earthWinds;
	
	// Idle animation parameters
	public float topSpeed;
	public float normalSpeed;
	public float accel;
	public float pacificMiddleLine;
	public float pacificWidth;

	// Cutscene animation paramters
	public float targetScale;
	public Vector3 targetEularAngle;
	
	// State parameters
	bool mouseover = false;
	bool clickAvaialble = false;
	bool isPlayingCutscene = false;	
	
	///////////////////////////////////////////////////////////////////////////////
	//
	// Idle animation
	//
	///////////////////////////////////////////////////////////////////////////////

	void Update()
	{
		if (!isPlayingCutscene) {
			idleStep();
		}
	}

	void idleStep()
	{
		Vector3 speed = rotorY.speed;
		clickAvaialble = (Mathf.Abs(Mathf.DeltaAngle(rotorY.transform.localEulerAngles.y, pacificMiddleLine)) < pacificWidth);

		if (mouseover && !clickAvaialble) {
			if (speed.y > topSpeed) {
				speed.y += accel * Time.deltaTime;
				if (speed.y < topSpeed) {
					speed.y = topSpeed;
				}
			}
		} else {
			if (speed.y < normalSpeed) {
				speed.y -= accel * Time.deltaTime;
				if (speed.y > normalSpeed) {
					speed.y = normalSpeed;
				}
			}
		}
		rotorY.speed = speed;
	}	
	
	///////////////////////////////////////////////////////////////////////////////
	//
	// Cutscene animation
	//
	///////////////////////////////////////////////////////////////////////////////

	IEnumerator cutsceneAnim()
	{
		foreach (EarthWind e in earthWinds) {
			e.on = false;
		}

		while (Mathf.Abs(Mathf.DeltaAngle(rotorY.transform.localEulerAngles.y, 200.0f)) > Mathf.Abs(topSpeed * Time.deltaTime)) {
			speedup();
			yield return null;
		}
		
		Accelerator scaleAccel = new Accelerator(1, 0.6f, 2, 0.6f, 2.1f);
		Accelerator xAccel = new Accelerator(0, 30f, 60.0f, 30f, 30.0f);
		openingCutscene.checkEarthCutscene();

		while (Mathf.Abs(Mathf.DeltaAngle(rotorY.transform.localEulerAngles.y, 340.0f)) > Mathf.Abs(topSpeed * Time.deltaTime)) {
			speedup();			
			float s = scaleAccel.step(Time.deltaTime);
			rotorX.transform.localScale = new Vector3(s, s, s);
			rotorX.transform.localEulerAngles = new Vector3(xAccel.step(Time.deltaTime), 0, 0);
			yield return null;
		}

		rotorY.speed = Vector3.zero;
		openingCutscene.endEarthCutscene();
	}
	
	void speedup()
	{
		Vector3 speed = rotorY.speed;
		if (speed.y > topSpeed) {
			speed.y += accel * Time.deltaTime;
			if (speed.y < topSpeed) {
				speed.y = topSpeed;
			}
		}
		rotorY.speed = speed;
	}

	///////////////////////////////////////////////////////////////////////////////
	//
	// Mouse events
	//
	///////////////////////////////////////////////////////////////////////////////
	
	void OnMouseEnter()
	{
		if (!isPlayingCutscene) {
			mouseover = true;
			applyMouseoverToWinds();
		}
	}
	
	void OnMouseExit()
	{
		if (!isPlayingCutscene) {
			mouseover = false;
			applyMouseoverToWinds();
		}
	}
	
	void OnMouseUp()
	{
		if (openingCutscene.startCutscene()) {
			mouseover = false;
			clickAvaialble = false;
			isPlayingCutscene = true;

			applyMouseoverToWinds();
			StartCoroutine(cutsceneAnim());
		}
	}

	void applyMouseoverToWinds()
	{
		foreach (EarthWind e in earthWinds) {
			e.mouseover = mouseover;
		}
	}
}
