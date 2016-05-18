using UnityEngine;
using System.Collections;

public class NormalYearGame : GameManagerBase
{
	public Alpha cameraFilter;
	public StringLibrary stringLibrary;
	int stageHash;
	int progressHash;

	public override void Start()
	{
		base.Start();
		stageHash = Animator.StringToHash("stage");
		progressHash = Animator.StringToHash("progress");
		anim.SetInteger(progressHash, data.normalYearGameProgress);
	}

	public TextTypingEffect clipSelectHint_MainPanel;
	public void startClipSelectHint()
	{
		clipSelectHint_MainPanel.setText(stringLibrary.get("ClipSelectHint_MainPanel"));
	}

	public TextTypingEffect mainUI_UpperPanel;
	public void startUpperPanelHint(string key)
	{
		mainUI_UpperPanel.setText(stringLibrary.get(key));
	}

	public void clearUpperPanelHint()
	{
		mainUI_UpperPanel.setText("");
	}

	public TextTypingEffect mainUI_LowerPannel;
	public void startLowerPanelHint(string key)
	{
		mainUI_LowerPannel.setText(stringLibrary.get(key));
	}

	public void clearLowerPanelHint()
	{
		mainUI_LowerPannel.setText("");
	}

	public AlphaHub surfaceWinds_Side;
	public void startSurfaceWinds_Side()
	{
		surfaceWinds_Side.gameObject.SetActive(true);
		surfaceWinds_Side.startAnim();
	}

	public void endSurfaceWinds_Side()
	{
		surfaceWinds_Side.endAnim();
	}

	public AlphaHub surfaceWinds_Top;
	public void startSurfaceWinds_Top()
	{
		surfaceWinds_Top.gameObject.SetActive(true);
		surfaceWinds_Top.startAnim();
	}

	public void endSurfaceWinds_Top()
	{
		surfaceWinds_Top.endAnim();
	}

	public LowPressureSystem lowPressureSystem;
	public void startLowPressureSystem()
	{
		lowPressureSystem.gameObject.SetActive(true);
		lowPressureSystem.startAnim();
	}

	public void endLowPressureSystemWind()
	{
		lowPressureSystem.endWindAnim();
	}

	public void endLowPressureSystem()
	{
		lowPressureSystem.endAnim();
	}

	public HighPressureSystem highPressureSystem;
	public void startHighPressureSystem()
	{
		highPressureSystem.gameObject.SetActive(true);
		highPressureSystem.startAnim();
	}

	public void endHighPressureSystemWind()
	{
		highPressureSystem.endWindAnim();
	}

	public void endHighPressureSystem()
	{
		highPressureSystem.endAnim();
	}

	public AlphaHub walkerWinds;
	public void startWalkerWinds()
	{
		walkerWinds.gameObject.SetActive(true);
		walkerWinds.startAnim();
	}

	public void endWalkWinds()
	{
		walkerWinds.endAnim();
	}

	public AlphaHub seaCurrents;
	public void startSeaCurrents()
	{
		seaCurrents.gameObject.SetActive(true);
		seaCurrents.startAnim();
	}

	public void endSeaCurrents()
	{
		seaCurrents.endAnim();
	}

	public AlphaHub seaUpCurrents;
	public void startSeaUpCurrents()
	{
		seaUpCurrents.gameObject.SetActive(true);
		seaUpCurrents.startAnim();
	}

	public void endSeaUpCurrents()
	{
		seaUpCurrents.endAnim();
	}

	public void clipSelect(int id)
	{
		if (id <= data.normalYearGameProgress) {
			if (id == data.normalYearGameProgress) {
				data.normalYearGameProgress++;
				anim.SetInteger(progressHash, data.normalYearGameProgress);
			}
			anim.SetInteger(stageHash, id);
			unpause();
		}
	}

	public void reset()
	{
		if (data.normalYearGameProgress > 0 && data.normalYearGameProgress < 4) {
			data.normalYearGameProgress--;
		}
		base.reloadScene();
	}

	public void overwriteProgress(int i)
	{
		data.normalYearGameProgress = i;
	}
}
