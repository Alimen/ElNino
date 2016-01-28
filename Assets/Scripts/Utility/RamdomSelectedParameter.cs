using UnityEngine;
using System.Collections;

public class RamdomSelectedParameter : StateMachineBehaviour 
{
	public string integerName;
	public int min, max;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{		
		animator.SetInteger(integerName, Random.Range(min, max));
	}
}
