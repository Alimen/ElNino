using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StringLibrary : MonoBehaviour
{	
	[System.Serializable]
	public class StringPair
	{
		public string key;
		[TextArea] public string value;

		public StringPair() {}
		public StringPair(string key, string value)
		{
			this.key = key;
			this.value = value;
		}
	}

	public List<StringPair> stringLibrary = new List<StringPair>();
	public string get(string key)
	{
		int i = stringLibrary.FindIndex(x => x.key == key);
		return i >= 0? stringLibrary [i].value: "";
	}
}
