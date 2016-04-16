using UnityEngine;
using System.Collections;

public class SurfaceWind : MonoBehaviour 
{
	public Alpha alpha;
	public float startX;
	public float disablePoint;
	public float endX;
	public float speed;

	void Update()
	{
		transform.localPosition += Vector3.right * speed * Time.deltaTime;

		if (transform.localPosition.x > endX) {
			transform.localPosition = new Vector3(startX, transform.localPosition.y, transform.localPosition.z);
		}
		alpha.on = (transform.localPosition.x < disablePoint);
	}
}
