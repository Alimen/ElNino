using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SeaWaveLauncher : MonoBehaviour
{	
	// Controler
	public float level;

	// Sea waves
	public Transform[] seaWavePrefabs;
	public Rect seaWaveStartOffset;
	public float seaWaveOffset;
	public float seaWaveDelayTime;
	float seaWaveCurrentOffset;
	float seaWaveTimer;
	List<Transform> seaWaves = new List<Transform>();
		
	void Update()
	{
		level = Mathf.Clamp01(level);
		float currentSpeedFactor = 1 + level * 1.5f;
		seaWaveTimer -= Time.deltaTime;
		
		if (seaWaveTimer < 0 && level > 0) {
			float x = Random.Range(seaWaveStartOffset.xMin, seaWaveStartOffset.xMax);
			float y = Random.Range(seaWaveStartOffset.yMin, seaWaveStartOffset.yMax);
			for (int i = 0; i < seaWavePrefabs.Length; i++) {				
				Transform w = Instantiate(seaWavePrefabs [Random.Range(0, seaWavePrefabs.Length)]) as Transform;
				w.parent = transform;
				w.localPosition = new Vector3(x, 0.1f, y - seaWaveOffset * (float)i);
				seaWaves.Add(w);
			}			
			seaWaveTimer = seaWaveDelayTime * Random.Range(0.7f, 1.0f) / currentSpeedFactor;
		}
		
		seaWaves.RemoveAll(x => x == null);
		foreach (Transform w in seaWaves) {
			w.GetComponent<Animator>().speed = currentSpeedFactor;
		}
	}

	void OnDrawGizmos()
	{
		Vector3 lt = transform.position + new Vector3(seaWaveStartOffset.xMin, 0, seaWaveStartOffset.yMax);
		Vector3 rt = transform.position + new Vector3(seaWaveStartOffset.xMax, 0, seaWaveStartOffset.yMax);
		Vector3 lb = transform.position + new Vector3(seaWaveStartOffset.xMin, 0, seaWaveStartOffset.yMin);
		Vector3 rb = transform.position + new Vector3(seaWaveStartOffset.xMax, 0, seaWaveStartOffset.yMin);

		Debug.DrawLine(lt, rt, Color.cyan);
		Debug.DrawLine(rt, rb, Color.cyan);
		Debug.DrawLine(rb, lb, Color.cyan);
		Debug.DrawLine(lb, lt, Color.cyan);
	}
}
