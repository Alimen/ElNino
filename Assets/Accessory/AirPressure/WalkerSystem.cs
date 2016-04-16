using UnityEngine;
using System.Collections;

public class WalkerSystem : MonoBehaviour
{
	Animator anim;
	public string clipName_system;
	int clipHash_system;
	public string clipName_idle;
	int clipHash_idle;
	int goHash;

	public Transform controlerLeft;
	public Transform controlerRight;
	public AlphaHub alphaLeft;
	public AlphaHub alphaRight;

	void Start()
	{
		anim = GetComponent<Animator>();
		clipHash_system = Animator.StringToHash(clipName_system);
		clipHash_idle = Animator.StringToHash(clipName_idle);
		goHash = Animator.StringToHash("go");
	}

	void Update()
	{
		alphaLeft.target = controlerLeft.localPosition.y;
		alphaRight.target = controlerRight.localPosition.y;
	}

	public void startIdle()
	{
		anim.Play(clipHash_idle);
	}

	public void startSystem()
	{
		anim.Play(clipHash_system);
	}

	public void go()
	{
		anim.SetTrigger(goHash);
	}
}
