using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
	Animator anim;
	int nextHash;

	public StringLibrary stringLibrary;
	public TextTypingEffect textTypingEffect;

	void Start()
	{
		anim = GetComponent<Animator>();
		nextHash = Animator.StringToHash("next");
	}

	public void next()
	{
		if (!textTypingEffect.isComplete) {
			textTypingEffect.complete();
		} else {
			anim.SetTrigger(nextHash);
		}
	}

	public void setText(string key)
	{
		textTypingEffect.setText(stringLibrary.get(key));
	}
}
