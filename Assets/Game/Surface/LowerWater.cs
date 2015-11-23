using UnityEngine;
using System.Collections;

public class LowerWater : MonoBehaviour
{
	public Collider collider;
	public Alpha alpha;
	public Animator anim;
	public string targetTrigger;

	bool mouseover;

	public void turnOn()
	{
		collider.enabled = true;
	}

	public void turnOff()
	{
		collider.enabled = false;
		OnMouseExit();
	}

	void OnMouseEnter()
	{
		alpha.on = true;
		mouseover = true;
	}

	void OnMouseExit()
	{
		alpha.on = false;
		mouseover = false;
	}

	void OnMouseUp()
	{
		if (mouseover) {
			anim.SetTrigger(targetTrigger);
			turnOff();
		}
	}
}
