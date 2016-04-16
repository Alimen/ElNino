using UnityEngine;
using System.Collections;

public class Campass : MonoBehaviour
{
	Animator anim;
	public string trigger;
	int triggerHash;

	void Start()
	{
		anim = GetComponent<Animator>();
		triggerHash = Animator.StringToHash(trigger);
	}

	void OnMouseDown()
	{
		anim.SetTrigger(triggerHash);
	}
}
