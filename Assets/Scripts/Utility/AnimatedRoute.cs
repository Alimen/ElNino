using UnityEngine;
using System.Collections;

public class AnimatedRoute : MonoBehaviour
{
	public Alpha alpha;
	Animator anim;
	public string clipName;
	int clipHash;
	float clipLength;
	[Range(0, 1)] public float startFrame;
	float t;
	public float disablePoint;
	public float speed = 1.0f;

	void Start()
	{
		anim = GetComponent<Animator>();
		clipHash = Animator.StringToHash(clipName);
		anim.Play(clipHash, 0, startFrame);
		clipLength = anim.GetCurrentAnimatorStateInfo(0).length;
		t = startFrame * clipLength;
		anim.speed = 0;
	}

	void Update()
	{
		t += Time.deltaTime * speed;
		if (t > clipLength) {
			t -= clipLength;
		}
		
		anim.Play(clipHash, 0, t / clipLength);
		alpha.on = (t < disablePoint);
	}
}
