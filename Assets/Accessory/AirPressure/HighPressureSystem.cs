using UnityEngine;
using System.Collections;

public class HighPressureSystem : MonoBehaviour
{
	public Alpha high;
	public AlphaHub coldWinds;

	public void startAnim()
	{
		StopCoroutine("startCoroutine");
		StartCoroutine("startCoroutine");
	}

	IEnumerator startCoroutine()
	{
		coldWinds.gameObject.SetActive(true);
		coldWinds.startAnim();
		yield return new WaitForSeconds(2.0f);
		high.on = true;
	}

	public void endWindAnim()
	{
		coldWinds.endAnim();
	}

	public void endAnim()
	{
		StopCoroutine("endCoroutine");
		StartCoroutine("endCoroutine");
	}

	IEnumerator endCoroutine()
	{
		high.on = false;
		if (coldWinds.isOn) {
			coldWinds.endAnim();
		}
		yield return new WaitForSeconds(0.6f);
		gameObject.SetActive(false);
	}
}
