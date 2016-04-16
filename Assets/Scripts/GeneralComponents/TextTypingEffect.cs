using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(UnityEngine.UI.Text))]
public class TextTypingEffect : MonoBehaviour
{
	// Component handlers
	UnityEngine.UI.Text text;

	// Parameters
	public float interval;
	float timer;
	List<string> str = new List<string>();
	string s0, s;
	int cnt = 1;

	void Start()
	{
		text = GetComponent<UnityEngine.UI.Text>();
	}

	void Update()
	{
		if (cnt >= str.Count) {
			return;
		}

		timer -= Time.deltaTime;
		if (timer < 0) {
			cnt ++;
			s += str [cnt - 1];
			text.text = s;
			timer = interval;
		}
	}

	public void setText(string input)
	{
		s0 = input;
		s = "";
		str.Clear();
		text.text = "";
		timer = interval;
		cnt = 0;

		if (string.IsNullOrEmpty(input)) {
			return;
		}

		const string colorTagHead = "<color=#";
		const string colorTagEnd = "</color>";
		string tmp = s0;
		string tag = "";
		bool tagged = false;

		while (tmp.Length > 0) {
			if (tagged) {
				if (tmp.StartsWith(colorTagEnd)) {
					tag = "";
					tmp = tmp.Remove(0, colorTagEnd.Length);
					tagged = false;
				}
			} else {
				if (tmp.StartsWith(colorTagHead) && tmp.IndexOf('>') > 0) {
					tag = tmp.Substring(0, tmp.IndexOf('>') + 1);
					tmp = tmp.Remove(0, tag.Length);
					tagged = true;
				}
			}

			if (tagged) {
				str.Add(tag + tmp [0] + colorTagEnd);
			} else {
				str.Add(tmp [0].ToString());
			}
			tmp = tmp.Remove(0, 1);
		}
	}

	public void complete()
	{
		text.text = s0;
		cnt = str.Count;
	}

	public bool isComplete {
		get {
			return (cnt >= str.Count);
		}
	}
}
