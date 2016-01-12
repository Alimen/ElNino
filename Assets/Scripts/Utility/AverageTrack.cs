using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AverageTrack
{
	int count;
	List<Vector3> queue = new List<Vector3>();

	public AverageTrack(int count)
	{
		this.count = count;
	}

	public void add(Vector3 input)
	{
		queue.Add(input);
		if (queue.Count > count) {
			queue.RemoveAt(0);
		}
	}

	public void clear()
	{
		queue.Clear();
	}

	public Vector3 value {
		get {
			if (queue.Count == 0) {
				return Vector3.zero;
			}

			Vector3 output = new Vector3();
			foreach (Vector3 v in queue) {
				output += v;
			}
			return output / queue.Count;
		}
	}
}
