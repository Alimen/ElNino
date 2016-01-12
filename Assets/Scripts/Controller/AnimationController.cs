using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class AnimationController : ControllerBase 
{
	// Component handlers
	Animator anim;

	[Header("---- Parameters ----------------------------------------")]
	public string clipName;
	int clipHash;

	void Start()
	{
		anim = GetComponent<Animator>();
		clipHash = Animator.StringToHash(clipName);
	}

	protected override void Update()
	{
		base.Update();
		anim.Play(clipHash, 0, ratio);
	}
}