using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class AnimationControler : MonoBehaviour
{	
	// Component handlers
	Animator anim;	

	// Animation clips
	public AnimationClip[] clips;
	float[] length;
	float totalLength;

	void Awake()
	{
		anim = GetComponent<Animator>();
		
		length = new float [clips.Length];
		totalLength = 0;
		for (int i = 0; i < clips.Length; i++) {
			length [i] = clips [i].length;
			totalLength += clips [i].length * 0.75f;
		}
		totalLength += clips [clips.Length - 1].length * 0.25f;
	}	
	
	public void seek(float t)
	{
		t *= totalLength;
		
		int clip = 0;
		float clipTime = 0;
		
		while (t > 0) {
			if (t > length [clip]) {
				t -= length [clip];
				clip++;
			} else {
				clipTime = t / length [clip];
				t = 0;
			}
		}

		anim.Play(clips [clip].name, 0, clipTime / length [clip]);
	}
}
