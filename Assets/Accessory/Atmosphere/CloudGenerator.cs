using UnityEngine;
using System.Collections;

public class CloudGenerator : MonoBehaviour
{
	public Transform cloudPrefab;
	public float spawnTime;
	public Rect xzPlane;
	public float y;
	float timer;

	void Start()
	{
		timer = spawnTime;
	}

	void Update()
	{
		timer -= Time.deltaTime;
		if (timer < 0) {
			Vector3 pos = new Vector3(Random.Range(xzPlane.xMin, xzPlane.xMax), y, Random.Range(xzPlane.yMin, xzPlane.yMax));
			Transform p = Instantiate(cloudPrefab, transform.position + pos, Quaternion.identity) as Transform;
			p.parent = transform;
			timer = spawnTime;
		}
	}
}
