using UnityEngine;
using System.Collections;

[RequireComponent(typeof(UnityEngine.UI.Text))]
public class TextAlphaController : ControllerBase
{	
	// Component handlers
	UnityEngine.UI.Text text;
	
	void Start()
	{
		text = GetComponent<UnityEngine.UI.Text>();
	}

	protected override void Update()
	{
		base.Update();
		Color c = text.color;
		c.a = Mathf.Clamp01(ratio);
		text.color = c;
	}
}
