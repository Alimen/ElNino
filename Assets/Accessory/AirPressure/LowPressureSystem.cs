using UnityEngine;
using System.Collections;

public class LowPressureSystem : MonoBehaviour
{
	public Alpha low;
	public Alpha highlight;
	public AlphaHub hotWinds;
	public Alpha rainCloud;
	public AlphaHub rainDrops;

	public void startAnim()
	{
		StopCoroutine("startCoroutine");
		StartCoroutine("startCoroutine");
	}

	IEnumerator startCoroutine()
	{
		hotWinds.gameObject.SetActive(true);
		hotWinds.startAnim();
		yield return new WaitForSeconds(2.0f);
		low.on = true;
		highlight.on = true;
		yield return new WaitForSeconds(1.0f);
		rainCloud.on = true;
		yield return new WaitForSeconds(0.6f);
		rainDrops.gameObject.SetActive(true);
		rainDrops.startAnim();
	}

	public void endWindAnim()
	{
		hotWinds.endAnim();
	}

	public void endAnim()
	{
		StopCoroutine("endCoroutine");
		StartCoroutine("endCoroutine");
	}

	IEnumerator endCoroutine()
	{
		rainDrops.endAnim();
		rainCloud.on = false;
		if (hotWinds.isOn) {
			hotWinds.endAnim();
		}
		yield return new WaitForSeconds(0.5f);
		low.on = false;
		highlight.on = false;
		yield return new WaitForSeconds(0.6f);
		gameObject.SetActive(false);
	}
}
