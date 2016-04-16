using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteAlphaController : ControllerBase
{
	// Component handlers
	SpriteRenderer spriteRenderer;

	void Start()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	protected override void Update()
	{
		base.Update();
		Color c = spriteRenderer.color;
		c.a = Mathf.Clamp01(ratio);
		spriteRenderer.color = c;
	}
}
