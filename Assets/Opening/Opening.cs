using UnityEngine;
using System.Collections;

public class Opening : MonoBehaviour 
{
	// Component handlers
	public Earth earth;
	public StartHint startHint;
	public Alpha skybox;
	public CameraPivot cameraPivot;
	public Alpha cameraMask;
	public Transform lightPivot;

	// Cutscene parameters
	public Color finalSkyColor;

	// Status flags
	bool isWaitingDialogBubble = true;
	bool isWaitingStartHint = true;
	bool isPlayingCutscene = false;
	bool earthCutsceneCheckpoint = false;
	bool earthCutsceneEnds = false;

	void Start()
	{
		StartCoroutine(waitDailogBubble());
	}

	IEnumerator waitDailogBubble()
	{
		while (isWaitingDialogBubble) {
			yield return null;
		}
		startHint.on = true;
		yield return new WaitForSeconds(startHint.delay);
		isWaitingStartHint = false;
	}

	public bool startCutscene()
	{
		if (!isPlayingCutscene && !isWaitingStartHint) {
			StartCoroutine(playCutscene());
			return true;
		} else {
			return false;
		}
	}

	IEnumerator playCutscene()
	{
		isPlayingCutscene = true;

		earthCutsceneEnds = false;
		earthCutsceneCheckpoint = false;
		startHint.on = false;
		cameraPivot.enableMouseMove = false;

		while (!earthCutsceneCheckpoint) {
			yield return null;
		}
		yield return new WaitForSeconds(2.0f);
		cameraMask.on = true;

		while (!earthCutsceneEnds) {
			yield return null;
		}
		cameraPivot.mainCamera.backgroundColor = finalSkyColor;
		skybox.on = false;

		cameraPivot.eulerAngles = new Vector3(25, 340, 0);
		lightPivot.eulerAngles = new Vector3(45, 0, 0);
		yield return new WaitForSeconds(0.2f);
		yield return Application.LoadLevelAdditiveAsync("Cut1");
		yield return null;
		cameraMask.on = false;
		cameraMask.setAlpha(0);
		cameraPivot.enableMouseMove = true;

		Destroy(gameObject);
		isPlayingCutscene = false;
	}

	public void stopWaitingDialog()
	{
		isWaitingDialogBubble = false;
	}

	public void endEarthCutscene()
	{
		earthCutsceneEnds = true;
	}

	public void checkEarthCutscene()
	{
		earthCutsceneCheckpoint = true;
	}
}
