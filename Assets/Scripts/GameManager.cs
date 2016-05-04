using UnityEngine;
using System.Collections;

public class GameManager : GameManagerBase
{
	int stageHash;

	public override void Start()
	{
		base.Start();
		stageHash = Animator.StringToHash("stage");
		checkGameProgress();
	}

	void checkGameProgress()
	{
		GameData data = GameData.getRuntime();
		int progress;

		if (data.laNinaYearGameProgress > 0) {
			progress = 4;
		} else if (data.elNinoYearGameProgress > 2) {
			progress = 3;
		} else if (data.normalYearGameProgress > 2) {
			progress = 2;
		} else if (data.glossaryGameProgress > 0) {
			progress = 1;
		} else {
			progress = 0;
		}

		data.titleProgress = progress;
	}

	public void selectStage(int id)
	{
		anim.SetInteger(stageHash, id);
		unpause();
	}
}
