using UnityEngine;
using System.Collections;

public class AtmosphereCollider : MonoBehaviour
{
	public GameManager gm;
	public Alpha alpha;

	void OnMouseEnter()
	{
		alpha.on = true;
	}

	void OnMouseExit()
	{
		alpha.on = false;
	}

	void OnMouseUp()
	{
		gm.next();
	}
}
