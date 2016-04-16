using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Renderer))]
public class MaterialAphlaController : ControllerBase
{	
	// Component handlers
	Renderer ren;

	void Start()
	{
		ren = GetComponent<Renderer>();
	}

	protected override void Update()
	{
		base.Update();

		Color c;
		foreach (Material m in ren.materials) {
			c = m.color;
			c.a = Mathf.Clamp01(ratio);
			m.color = c;
		}
	}
}
