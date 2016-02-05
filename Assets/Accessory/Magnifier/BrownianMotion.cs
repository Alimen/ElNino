using UnityEngine;
using System.Collections;

public class BrownianMotion : MonoBehaviour
{
	public float step;
	public Rect area;
	Vector3 startPos;

	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.white;
		Gizmos.DrawWireCube(transform.position, new Vector3(area.width * 2, area.height * 2, 0.01f));
	}

	void Start()
	{
		startPos = transform.localPosition;
	}

	void Update()
	{
		Vector2 d = new Vector2(Random.Range(-step, step), Random.Range(-step, step));
		Vector2 newPos = new Vector2(transform.localPosition.x, transform.localPosition.y);
		if (newPos.x + d.x > startPos.x + area.width / 2 || newPos.x + d.x < startPos.x - area.width / 2) {
			newPos.x -= d.x;
		} else {
			newPos.x += d.x;
		}
		if (newPos.y + d.y > startPos.y + area.height / 2 || newPos.y + d.y < startPos.y - area.height / 2) {
			newPos.y -= d.y;
		} else {
			newPos.y += d.y;
		}

		transform.localPosition = new Vector3(newPos.x, newPos.y, transform.localPosition.z);
	}
}
