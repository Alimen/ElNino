using UnityEngine;
using System.Collections;

public class LaNinaGame : GameManagerBase
{
	public StringLibrary stringLibrary;

	public override void Start()
	{
		base.Start();
		GameData.getRuntime().laNinaYearGameProgress = 1;
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

	public LaNinaAtmosphere atmosphere;
	public void startAtmosphere()
	{
		atmosphere.gameObject.SetActive(true);
		atmosphere.startAnim();
	}

	public void endAtmosphere()
	{
		atmosphere.endAnim();
	}
}
