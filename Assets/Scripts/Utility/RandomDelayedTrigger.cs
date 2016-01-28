using UnityEngine;
using System.Collections;

public class RandomDelayedTrigger : StateMachineBehaviour
{
	public string triggerName;
	public float min, max;
	float timeLeft;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		timeLeft = Random.Range(min, max);
	}

	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		timeLeft -= Time.deltaTime;
		if (timeLeft < 0) {
			animator.SetTrigger(triggerName);
		}
	}
}
