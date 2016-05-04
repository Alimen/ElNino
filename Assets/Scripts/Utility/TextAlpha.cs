using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TextMesh))]
public class TextAlpha : Alpha
{
	TextMesh text;

	void Start()
	{
		text = GetComponent<TextMesh>();
	}
	
	void Update()
	{
		target = Mathf.Clamp01(target);
		
		float t = on? target: 0;
		float a = text.color.a;
		
		if (a > t) {
			a -= accel * Time.deltaTime;
			if (a < t) {
				a = t;
			}
		} else {
			a += accel * Time.deltaTime;
			if (a > t) {
				a = t;
			}
		}
		
		Color c = text.color;
		c.a = a;
		text.color = c;
	}
	
	public new void setAlpha(float a)
	{
		Color c = text.color;
		c.a = a;
		text.color = c;
	}
}
