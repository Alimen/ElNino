using UnityEngine;
using System.Collections;

public class PositionController : ControllerBase 
{
	[Header("---- Parameters ----------------------------------------")]
	public Vector3 startPos;
	public Vector3 endPos;

	protected override void Update()
	{
		base.Update();
		transform.localPosition = startPos + (endPos - startPos) * ratio;
	}
}
