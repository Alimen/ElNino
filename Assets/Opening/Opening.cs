using UnityEngine;
using System.Collections;

public class Opening : MonoBehaviour 
{
	// Component handlers
	public Earth earth;
	public StartHint startHint;
	public Alpha skybox;
	public Camera mainCamera;

	// Cutscene parameters
	public Color finalSkyColor;

	// Status flags
	bool isPlayingCutscene = false;
	bool earthCutsceneEnds = false;

	public void startCutscene()
	{
		if (!isPlayingCutscene) {
			StartCoroutine(playCutscene());
		}
	}

	IEnumerator playCutscene()
	{
		isPlayingCutscene = true;
		
		earthCutsceneEnds = false;
		startHint.on = false;
		while (!earthCutsceneEnds) {
			yield return null;
		}
		mainCamera.backgroundColor = finalSkyColor;
		skybox.on = false;

		print("ha");
		yield return new WaitForSeconds(20);

		Destroy(gameObject);
		isPlayingCutscene = false;
	}

	public void endEarthCutscene()
	{
		earthCutsceneEnds = true;
	}
}
