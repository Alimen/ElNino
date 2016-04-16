using UnityEngine;
using System.Collections;

public class ElNinoGame : GameManagerBase
{
	public StringLibrary stringLibrary;
	int stageHash;
	int progressHash;

	public override void Start()
	{
		base.Start();
		stageHash = Animator.StringToHash("stage");
		progressHash = Animator.StringToHash("progress");
		anim.SetInteger(progressHash, data.elNinoYearGameProgress);
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

	public AlphaHub deepfish;
	public void startDeepfish()
	{
		deepfish.gameObject.SetActive(true);
		deepfish.startAnim();
	}

	public void endDeepfish()
	{
		deepfish.endAnim();
	}

	public WalkerSystem walkerSystem;
	public void startWalkerIdle()
	{
		walkerSystem.startIdle();
	}

	public void startWalkerSystem()
	{
		walkerSystem.startSystem();
	}

	public void walkerSystemGo()
	{
		walkerSystem.go();
	}

	public void clipSelect(int id)
	{
		if (id <= data.elNinoYearGameProgress) {
			if (id == data.elNinoYearGameProgress) {
				data.elNinoYearGameProgress++;
				anim.SetInteger(progressHash, data.elNinoYearGameProgress);
			}
			anim.SetInteger(stageHash, id);
			unpause();
		}
	}
}
