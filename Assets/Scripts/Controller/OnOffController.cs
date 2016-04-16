using UnityEngine;
using System.Collections;

public class OnOffController : ControllerBase
{
	[Header("---- Parameters ----------------------------------------")]
	public GameObject target;
	public bool offWhanActivated;
	bool curState;

	void Start()
	{
		curState = (0 < ratio && ratio < 1)? !offWhanActivated: offWhanActivated;
		target.SetActive(curState);
	}

	protected override void Update()
	{
		base.Update();
		bool tmp = (0 < ratio && ratio < 1)? !offWhanActivated: offWhanActivated;
		if (curState != tmp) {
			target.SetActive(tmp);
			curState = tmp;
		}
	}
}
