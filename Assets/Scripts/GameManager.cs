using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
	Animator anim;
	int nextHash;
	public bool wait;

	public UnityEngine.UI.Text fullscreenText;
	public StringLibrary stringLibrary;
	public TextTypingEffect textTypingEffect;
	public FishManager fishManager;

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
			if (wait) {
				if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1) {
					anim.SetTrigger(nextHash);
				}
			} else {
				anim.SetTrigger(nextHash);
			}
		}
	}

	public void setText(string key)
	{
		textTypingEffect.setText(stringLibrary.get(key));
	}

	public void toggleFishingArea()
	{
		fishManager.toggleArea();
	}

	public void setFullscreenText(string text)
	{
		fullscreenText.text = text;
	}

	public void reset()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("Reset");
	}
}
