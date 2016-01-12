using UnityEngine;
using System.Collections;

[RequireComponent(typeof(UnityEngine.UI.Text))]
public class TextTypingEffect : MonoBehaviour
{
	// Component handlers
	UnityEngine.UI.Text text;

	// Parameters
	public float interval;
	float timer;
	string str = "";
	int cnt = 1;

	void Start()
	{
		text = GetComponent<UnityEngine.UI.Text>();
	}

	void Update()
	{
		if (cnt >= str.Length) {
			return;
		}

		timer -= Time.deltaTime;
		if (timer < 0) {
			cnt ++;
			text.text = str.Substring(0, cnt);
			timer = interval;
		}
	}

	public void setText(string str)
	{
		text.text = "";
		timer = interval;
		this.str = str;
		cnt = 0;
	}

	public void complete()
	{
		text.text = str;
		cnt = str.Length;
	}

	public bool isComplete {
		get {
			return (cnt >= str.Length);
		}
	}
}
