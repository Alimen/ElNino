using UnityEngine;
using System.Collections;

public class GameManager : GameManagerBase
{
	int stageHash;

	public override void Start()
	{
		base.Start();
		stageHash = Animator.StringToHash("stage");
	}

	public void selectStage(int id)
	{
		anim.SetInteger(stageHash, id);
		unpause();
	}
}
