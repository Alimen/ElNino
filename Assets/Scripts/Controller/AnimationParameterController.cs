using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class AnimationParameterController : ControllerBase 
{
	// Component handlers
	Animator anim;

	[Header("---- Parameters ----------------------------------------")]
	public string targetParameter;
	int paramHash;

	void Start()
	{
		anim = GetComponent<Animator>();
		paramHash = Animator.StringToHash(targetParameter);
	}

	protected override void Update()
	{
		base.Update();
		anim.SetFloat(paramHash, ratio);
	}
}