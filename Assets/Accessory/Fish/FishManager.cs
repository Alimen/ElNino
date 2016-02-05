using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FishManager : MonoBehaviour
{
	int currentArea = -1;
	public Bounds[] areas;
	public List<Fish> fishes;

	void OnDrawGizmosSelected()
	{		
		Gizmos.color = Color.cyan;
		Gizmos.DrawWireCube(transform.position + areas [0].center, areas [0].size);
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireCube(transform.position + areas [1].center, areas [1].size);
	}

	public void toggleArea()
	{
		currentArea = (currentArea + 1) % areas.Length;
		foreach (Fish f in fishes) {
			f.setArea(areas [currentArea]);
		}
	}
}
