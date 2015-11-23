using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	public Transform stageRollinControler;
	public Animator stage;

	public Transform surfaceWindControler;
	public SeaWaveLauncher surfaceWindLauncher;

	public Transform seaWaveControler;
	public SeaWaveLauncher seaWaveLauncher;

	public Transform seaLevelControler;
	public WaterSurface waterSurface;

	void Update()
	{
		stage.Play("Stage - Rollin", 0, Mathf.Clamp01(stageRollinControler.localPosition.y));
		surfaceWindLauncher.level = Mathf.Clamp01(surfaceWindControler.localPosition.y);
		seaWaveLauncher.level = Mathf.Clamp01(seaWaveControler.localPosition.y);
		waterSurface.level = Mathf.Clamp01(seaLevelControler.localPosition.y);
	}
}
