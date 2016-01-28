using UnityEngine;
using System.Collections;

public class BillboardSprite : MonoBehaviour
{
	void Update()
	{
		transform.LookAt(transform.position - Camera.main.transform.position);
	}
}
