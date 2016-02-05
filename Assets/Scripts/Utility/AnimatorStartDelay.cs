using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class AnimatorStartDelay : MonoBehaviour
{
	Animator anim;
	public string trigger;
	int triggerHash;

	public float delay;
	float timer;

	void Start()
	{
		anim = GetComponent<Animator>();
		triggerHash = Animator.StringToHash(trigger);
		timer = delay;
	}

	void Update()
	{
		if (timer >= 0) {
			timer -= Time.deltaTime;
			if (timer <= 0) {
				anim.SetTrigger(triggerHash);
			}
		}
	}
}
