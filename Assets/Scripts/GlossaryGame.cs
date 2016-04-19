using UnityEngine;
using System.Collections;

public class GlossaryGame : GameManagerBase
{
	public StringLibrary stringLibrary;
	int stageHash;

	public override void Start()
	{
		base.Start();
		stageHash = Animator.StringToHash("stage");
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

	public void clipSelect(int id)
	{
		anim.SetInteger(stageHash, id);
		unpause();
	}
}
