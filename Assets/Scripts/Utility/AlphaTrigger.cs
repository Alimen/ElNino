using UnityEngine;
using System.Collections;

public class AlphaTrigger : MonoBehaviour
{
	public Alpha alpha;

	void OnMouseEnter()
	{
		alpha.on = true;
	}

	void OnMouseExit()
	{
		alpha.on = false;
	}

	void OnDisable()
	{
		alpha.on = false;
		alpha.setAlpha(0);
	}
}
