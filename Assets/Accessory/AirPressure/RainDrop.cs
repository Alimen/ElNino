using UnityEngine;
using System.Collections;

public class RainDrop : MonoBehaviour
{
	public Alpha alpha;
	public float startY;
	public float disablePoint;
	public float endY;
	public float speed;

	void Update()
	{
		transform.localPosition += Vector3.down * speed * Time.deltaTime;

		if (transform.localPosition.y < endY) {
			transform.localPosition = new Vector3(transform.localPosition.x, startY, transform.localPosition.z);
		}
		alpha.on = (transform.localPosition.y > disablePoint);
	}
}
