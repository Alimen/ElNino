using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
public class ClickTrigger : MonoBehaviour
{
	public UnityEngine.Events.UnityEvent action;

	void OnMouseDown()
	{
		action.Invoke();
	}
}
